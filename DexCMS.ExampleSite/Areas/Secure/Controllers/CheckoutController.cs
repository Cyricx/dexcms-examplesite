using DexCMS.Core.Infrastructure;
using DexCMS.Core.Infrastructure.Enums;
using DexCMS.Tickets.Orders.Interfaces;
using DexCMS.Tickets.Orders.Models;
using DexCMS.Tickets.Tickets.Interfaces;
using DexCMS.Tickets.WebApi.Payments;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DexCMS.ExampleSite.Areas.Secure.Controllers
{
    public class CheckoutController : Controller
    {
        private IOrderRepository repository;
        private ITicketSeatRepository seatRepository;

        public CheckoutController(IOrderRepository repo, ITicketSeatRepository seatRepo)
        {
            repository = repo;
            seatRepository = seatRepo;
        }

        public async Task<ActionResult> ProcessPayment(string paymentId, string token, string PayerID)
        {
            var apiContext = PaypalConfiguration.GetAPIContext();
            PayPal.Api.Payment payment = null;
            try
            {
                payment = PayPal.Api.Payment.Execute(apiContext, paymentId, new PayPal.Api.PaymentExecution
                {
                    payer_id = PayerID
                });
            }
            catch (Exception e)
            {
                await Logger.WriteLog(LogType.Error, e.Message);
            }

            var transaction = payment.transactions.ToArray()[0];
            var sale = transaction.related_resources.ToArray()[0].sale;
            string invoiceNumber = transaction.invoice_number;
            if (string.IsNullOrEmpty(invoiceNumber))
            {
                string sub = transaction.description.Substring(transaction.description.IndexOf("#") + 1);
                sub = sub.Substring(0, sub.IndexOf(" "));
                invoiceNumber = sub;
            }

            int orderID = int.Parse(invoiceNumber);

            if (payment.state == "approved")
            {
                Order order = await repository.RetrieveAsync(orderID);
                if (order.Payments == null)
                {
                    order.Payments = new List<DexCMS.Tickets.Orders.Models.Payment>();
                }

                decimal transFee = 0;
                if (sale.transaction_fee != null && !string.IsNullOrEmpty(sale.transaction_fee.value))
                {
                    transFee = decimal.Parse(sale.transaction_fee.value);
                }

                order.Payments.Add(new DexCMS.Tickets.Orders.Models.Payment
                {
                    GrossPaid = decimal.Parse(transaction.amount.total),
                    NetPaid = decimal.Parse(transaction.amount.total) - transFee,
                    OrderID = order.OrderID,
                    PaidOn = DateTime.Now,
                    PaymentDetails = payment.ConvertToJson(),
                    PaymentFee = transFee,
                    PaymentType = PaymentType.Paypal
                });

                order.OrderStatus =
                    order.OrderTotal == decimal.Parse(transaction.amount.total) ? OrderStatus.Complete : OrderStatus.Partial;

                await repository.UpdateAsync(order, order.OrderID);

                return Redirect("~/secure/complete/" + order.OrderID);
            }
            else
            {
               return await CancelPayment(int.Parse(transaction.invoice_number));
            }
        }

        public async Task<ActionResult> CancelPayment(int orderID)
        {
            Order order = await repository.RetrieveAsync(orderID);

            await repository.DeleteAsync(order);

            return Redirect("~/secure/checkout");

        }


        public async Task<ActionResult> Print(int orderID)
        {
            var order = await repository.RetrieveAsync(orderID);
            if (order == null || order.UserName != User.Identity.Name)
            {
                return HttpNotFound();
            }
            return View(order);
        }
    }
}
