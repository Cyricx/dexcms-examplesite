namespace DexCMS.ExampleSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alerts",
                c => new
                    {
                        AlertID = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        AlertText = c.String(nullable: false, maxLength: 250),
                        DisplayOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlertID);
            
            CreateTable(
                "dbo.CalendarEventLocations",
                c => new
                    {
                        CalendarEventLocationID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        AdditionalDetails = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(),
                        MapIconImage = c.String(maxLength: 250),
                        MapXCoordinate = c.Int(),
                        MapYCoordinate = c.Int(),
                    })
                .PrimaryKey(t => t.CalendarEventLocationID);
            
            CreateTable(
                "dbo.CalendarEvents",
                c => new
                    {
                        CalendarEventID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 250),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        Location = c.String(maxLength: 250),
                        CalendarEventLocationID = c.Int(),
                        Details = c.String(),
                        CalendarEventTypeID = c.Int(nullable: false),
                        CalendarEventStatusID = c.Int(nullable: false),
                        IsRepeating = c.Boolean(nullable: false),
                        IsAllDay = c.Boolean(nullable: false),
                        CssClass = c.String(maxLength: 50),
                        EventURL = c.String(maxLength: 250),
                        CalendarRepeatTypeID = c.Int(),
                        RepeatCount = c.Int(),
                        RepeatCountEnd = c.Int(),
                        RepeatEndDate = c.DateTime(),
                        CalendarID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CalendarEventID)
                .ForeignKey("dbo.Calendars", t => t.CalendarID)
                .ForeignKey("dbo.CalendarEventLocations", t => t.CalendarEventLocationID)
                .ForeignKey("dbo.CalendarEventStatus", t => t.CalendarEventStatusID)
                .ForeignKey("dbo.CalendarEventTypes", t => t.CalendarEventTypeID)
                .ForeignKey("dbo.CalendarRepeatTypes", t => t.CalendarRepeatTypeID)
                .Index(t => t.CalendarEventLocationID)
                .Index(t => t.CalendarEventTypeID)
                .Index(t => t.CalendarEventStatusID)
                .Index(t => t.CalendarRepeatTypeID)
                .Index(t => t.CalendarID);
            
            CreateTable(
                "dbo.Calendars",
                c => new
                    {
                        CalendarID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CalendarID);
            
            CreateTable(
                "dbo.CalendarEventStatus",
                c => new
                    {
                        CalendarEventStatusID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        CssClass = c.String(maxLength: 25),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CalendarEventStatusID);
            
            CreateTable(
                "dbo.CalendarEventTypes",
                c => new
                    {
                        CalendarEventTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        CssClass = c.String(maxLength: 25),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CalendarEventTypeID);
            
            CreateTable(
                "dbo.CalendarRepeatDays",
                c => new
                    {
                        CalendarRepeatDayID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CalendarRepeatDayID);
            
            CreateTable(
                "dbo.CalendarRepeatTypes",
                c => new
                    {
                        CalendarRepeatTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CalendarRepeatTypeID);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Phone = c.String(maxLength: 250),
                        Email = c.String(nullable: false, maxLength: 250),
                        Message = c.String(nullable: false, maxLength: 2000),
                        OtherSubject = c.String(maxLength: 250),
                        SubmitDate = c.DateTime(nullable: false),
                        Referrer = c.String(maxLength: 400),
                        ContactTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContactID)
                .ForeignKey("dbo.ContactTypes", t => t.ContactTypeID)
                .Index(t => t.ContactTypeID);
            
            CreateTable(
                "dbo.ContactTypes",
                c => new
                    {
                        ContactTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        DisplayOrder = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ContactTypeID);
            
            CreateTable(
                "dbo.VisitedPages",
                c => new
                    {
                        VisitedPageID = c.Int(nullable: false, identity: true),
                        URL = c.String(nullable: false, maxLength: 4000),
                        VisitOrder = c.Int(nullable: false),
                        ContactID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VisitedPageID)
                .ForeignKey("dbo.Contacts", t => t.ContactID)
                .Index(t => t.ContactID);
            
            CreateTable(
                "dbo.ContentAreas",
                c => new
                    {
                        ContentAreaID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        UrlSegment = c.String(maxLength: 150),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ContentAreaID);
            
            CreateTable(
                "dbo.PageContents",
                c => new
                    {
                        PageContentID = c.Int(nullable: false, identity: true),
                        Heading = c.String(nullable: false, maxLength: 250),
                        PageTitle = c.String(nullable: false, maxLength: 50),
                        MetaKeywords = c.String(maxLength: 500),
                        MetaDescription = c.String(maxLength: 500),
                        ContentAreaID = c.Int(nullable: false),
                        ContentCategoryID = c.Int(),
                        ContentSubCategoryID = c.Int(),
                        UrlSegment = c.String(nullable: false, maxLength: 150),
                        Body = c.String(),
                        MaximumImages = c.Int(),
                        ChangeFrequency = c.Int(nullable: false),
                        LastModified = c.DateTime(),
                        LastModifiedBy = c.String(),
                        Priority = c.Double(),
                        AddToSitemap = c.Boolean(nullable: false),
                        LayoutTypeID = c.Int(),
                        PageTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PageContentID)
                .ForeignKey("dbo.ContentAreas", t => t.ContentAreaID)
                .ForeignKey("dbo.ContentCategories", t => t.ContentCategoryID)
                .ForeignKey("dbo.ContentSubCategories", t => t.ContentSubCategoryID)
                .ForeignKey("dbo.LayoutTypes", t => t.LayoutTypeID)
                .ForeignKey("dbo.PageTypes", t => t.PageTypeID)
                .Index(t => t.ContentAreaID)
                .Index(t => t.ContentCategoryID)
                .Index(t => t.ContentSubCategoryID)
                .Index(t => t.LayoutTypeID)
                .Index(t => t.PageTypeID);
            
            CreateTable(
                "dbo.ContentBlocks",
                c => new
                    {
                        ContentBlockID = c.Int(nullable: false, identity: true),
                        BlockTitle = c.String(nullable: false, maxLength: 150),
                        ShowTitle = c.Boolean(nullable: false),
                        BlockBody = c.String(nullable: false),
                        PageContentID = c.Int(nullable: false),
                        CssClass = c.String(maxLength: 100),
                        DisplayOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContentBlockID)
                .ForeignKey("dbo.PageContents", t => t.PageContentID)
                .Index(t => t.PageContentID);
            
            CreateTable(
                "dbo.ContentCategories",
                c => new
                    {
                        ContentCategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        UrlSegment = c.String(nullable: false, maxLength: 150),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ContentCategoryID);
            
            CreateTable(
                "dbo.ContentScripts",
                c => new
                    {
                        ContentScriptID = c.Int(nullable: false, identity: true),
                        PageContentID = c.Int(nullable: false),
                        Path = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ContentScriptID)
                .ForeignKey("dbo.PageContents", t => t.PageContentID)
                .Index(t => t.PageContentID);
            
            CreateTable(
                "dbo.ContentStyles",
                c => new
                    {
                        ContentStyleID = c.Int(nullable: false, identity: true),
                        PageContentID = c.Int(nullable: false),
                        Path = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ContentStyleID)
                .ForeignKey("dbo.PageContents", t => t.PageContentID)
                .Index(t => t.PageContentID);
            
            CreateTable(
                "dbo.ContentSubCategories",
                c => new
                    {
                        ContentSubCategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        UrlSegment = c.String(nullable: false, maxLength: 150),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ContentSubCategoryID);
            
            CreateTable(
                "dbo.LayoutTypes",
                c => new
                    {
                        LayoutTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        CssClass = c.String(nullable: false, maxLength: 50),
                        ExampleImage = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.LayoutTypeID);
            
            CreateTable(
                "dbo.PageContentImages",
                c => new
                    {
                        PageContentID = c.Int(nullable: false),
                        ImageID = c.Int(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PageContentID, t.ImageID })
                .ForeignKey("dbo.Images", t => t.ImageID)
                .ForeignKey("dbo.PageContents", t => t.PageContentID)
                .Index(t => t.PageContentID)
                .Index(t => t.ImageID);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageID = c.Int(nullable: false, identity: true),
                        Alt = c.String(nullable: false, maxLength: 250),
                        Credit = c.String(maxLength: 250),
                        Caption = c.String(maxLength: 250),
                        Thumbnail = c.String(maxLength: 250),
                        Slider = c.String(maxLength: 250),
                        Gallery = c.String(maxLength: 250),
                        Original = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ImageID);
            
            CreateTable(
                "dbo.PageTypes",
                c => new
                    {
                        PageTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PageTypeID);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.CountryID);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        StateID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        CountryID = c.Int(nullable: false),
                        Abbreviation = c.String(nullable: false, maxLength: 3),
                    })
                .PrimaryKey(t => t.StateID)
                .ForeignKey("dbo.Countries", t => t.CountryID)
                .Index(t => t.CountryID);
            
            CreateTable(
                "dbo.EventAgeGroups",
                c => new
                    {
                        EventAgeGroupID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        MinimumAge = c.Int(nullable: false),
                        MaximumAge = c.Int(),
                        EventID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventAgeGroupID)
                .ForeignKey("dbo.Events", t => t.EventID)
                .Index(t => t.EventID);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventID = c.Int(nullable: false),
                        EventStart = c.DateTime(nullable: false),
                        EventEnd = c.DateTime(nullable: false),
                        VenueID = c.Int(nullable: false),
                        EventSeriesID = c.Int(),
                        EventUrlSegment = c.String(),
                        IsPublic = c.Boolean(nullable: false),
                        LastViewedRegistration = c.DateTime(),
                        ForceDisableRegistration = c.Boolean(nullable: false),
                        DisablePublicRegistration = c.DateTime(),
                        RegistrationDisabledMessage = c.String(),
                    })
                .PrimaryKey(t => t.EventID)
                .ForeignKey("dbo.EventSeries", t => t.EventSeriesID)
                .ForeignKey("dbo.PageContents", t => t.EventID)
                .ForeignKey("dbo.Venues", t => t.VenueID)
                .Index(t => t.EventID)
                .Index(t => t.VenueID)
                .Index(t => t.EventSeriesID);
            
            CreateTable(
                "dbo.EventFaqCategories",
                c => new
                    {
                        EventFaqCategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                        EventID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventFaqCategoryID)
                .ForeignKey("dbo.Events", t => t.EventID)
                .Index(t => t.EventID);
            
            CreateTable(
                "dbo.EventFaqItems",
                c => new
                    {
                        EventFaqItemID = c.Int(nullable: false, identity: true),
                        Question = c.String(nullable: false, maxLength: 500),
                        Answer = c.String(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                        HelpfulMarks = c.Int(),
                        UnhelpfulMarks = c.Int(),
                        LastUpdated = c.DateTime(nullable: false),
                        LastUpdatedBy = c.String(nullable: false, maxLength: 256),
                        IsActive = c.Boolean(nullable: false),
                        EventFaqCategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventFaqItemID)
                .ForeignKey("dbo.EventFaqCategories", t => t.EventFaqCategoryID)
                .Index(t => t.EventFaqCategoryID);
            
            CreateTable(
                "dbo.EventSeries",
                c => new
                    {
                        EventSeriesID = c.Int(nullable: false, identity: true),
                        SeriesName = c.String(nullable: false, maxLength: 50),
                        SeriesUrlSegment = c.String(nullable: false, maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                        AllowMultiplePublic = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EventSeriesID);
            
            CreateTable(
                "dbo.ScheduleItems",
                c => new
                    {
                        ScheduleItemID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 250),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        IsAllDay = c.Boolean(nullable: false),
                        OtherLocation = c.String(maxLength: 250),
                        VenueScheduleLocationID = c.Int(),
                        ScheduleStatusID = c.Int(nullable: false),
                        ScheduleTypeID = c.Int(nullable: false),
                        Details = c.String(),
                        EventID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ScheduleItemID)
                .ForeignKey("dbo.Events", t => t.EventID)
                .ForeignKey("dbo.ScheduleStatus", t => t.ScheduleStatusID)
                .ForeignKey("dbo.ScheduleTypes", t => t.ScheduleTypeID)
                .ForeignKey("dbo.VenueScheduleLocations", t => t.VenueScheduleLocationID)
                .Index(t => t.VenueScheduleLocationID)
                .Index(t => t.ScheduleStatusID)
                .Index(t => t.ScheduleTypeID)
                .Index(t => t.EventID);
            
            CreateTable(
                "dbo.ScheduleStatus",
                c => new
                    {
                        ScheduleStatusID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        CssClass = c.String(maxLength: 25),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ScheduleStatusID);
            
            CreateTable(
                "dbo.ScheduleTypes",
                c => new
                    {
                        ScheduleTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        CssClass = c.String(maxLength: 25),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ScheduleTypeID);
            
            CreateTable(
                "dbo.VenueScheduleLocations",
                c => new
                    {
                        VenueScheduleLocationID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        CssClass = c.String(maxLength: 25),
                        IsActive = c.Boolean(nullable: false),
                        VenueID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VenueScheduleLocationID)
                .ForeignKey("dbo.Venues", t => t.VenueID)
                .Index(t => t.VenueID);
            
            CreateTable(
                "dbo.Venues",
                c => new
                    {
                        VenueID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 500),
                        City = c.String(nullable: false, maxLength: 100),
                        StateID = c.Int(nullable: false),
                        ZipCode = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.VenueID)
                .ForeignKey("dbo.States", t => t.StateID)
                .Index(t => t.StateID);
            
            CreateTable(
                "dbo.VenueAreas",
                c => new
                    {
                        VenueAreaID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        VenueID = c.Int(nullable: false),
                        IsGA = c.Boolean(nullable: false),
                        GASeatCount = c.Int(),
                    })
                .PrimaryKey(t => t.VenueAreaID)
                .ForeignKey("dbo.Venues", t => t.VenueID)
                .Index(t => t.VenueID);
            
            CreateTable(
                "dbo.VenueSections",
                c => new
                    {
                        VenueSectionID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        VenueAreaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VenueSectionID)
                .ForeignKey("dbo.VenueAreas", t => t.VenueAreaID)
                .Index(t => t.VenueAreaID);
            
            CreateTable(
                "dbo.VenueRows",
                c => new
                    {
                        VenueRowID = c.Int(nullable: false, identity: true),
                        Designation = c.String(nullable: false, maxLength: 50),
                        VenueSectionID = c.Int(nullable: false),
                        SeatCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VenueRowID)
                .ForeignKey("dbo.VenueSections", t => t.VenueSectionID)
                .Index(t => t.VenueSectionID);
            
            CreateTable(
                "dbo.TicketAreas",
                c => new
                    {
                        TicketAreaID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        EventID = c.Int(nullable: false),
                        IsGA = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(),
                    })
                .PrimaryKey(t => t.TicketAreaID)
                .ForeignKey("dbo.Events", t => t.EventID)
                .Index(t => t.EventID);
            
            CreateTable(
                "dbo.TicketAreaDiscounts",
                c => new
                    {
                        TicketDiscountID = c.Int(nullable: false),
                        TicketAreaID = c.Int(nullable: false),
                        AdjustmentType = c.Int(nullable: false),
                        AdjustmentAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.TicketDiscountID, t.TicketAreaID })
                .ForeignKey("dbo.TicketAreas", t => t.TicketAreaID)
                .ForeignKey("dbo.TicketDiscounts", t => t.TicketDiscountID)
                .Index(t => t.TicketDiscountID)
                .Index(t => t.TicketAreaID);
            
            CreateTable(
                "dbo.TicketDiscounts",
                c => new
                    {
                        TicketDiscountID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 500),
                        Code = c.String(nullable: false, maxLength: 20),
                        SecurityConfirmationNumber = c.String(maxLength: 36),
                        EventID = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        MaximumAvailable = c.Int(),
                        CutoffDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TicketDiscountID)
                .ForeignKey("dbo.Events", t => t.EventID)
                .Index(t => t.EventID);
            
            CreateTable(
                "dbo.TicketOptionDiscounts",
                c => new
                    {
                        TicketDiscountID = c.Int(nullable: false),
                        TicketOptionID = c.Int(nullable: false),
                        AdjustmentType = c.Int(nullable: false),
                        AdjustmentAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.TicketDiscountID, t.TicketOptionID })
                .ForeignKey("dbo.TicketDiscounts", t => t.TicketDiscountID)
                .ForeignKey("dbo.TicketOptions", t => t.TicketOptionID)
                .Index(t => t.TicketDiscountID)
                .Index(t => t.TicketOptionID);
            
            CreateTable(
                "dbo.TicketOptions",
                c => new
                    {
                        TicketOptionID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Description = c.String(),
                        BasePrice = c.Decimal(nullable: false, storeType: "money"),
                        CutoffDate = c.DateTime(nullable: false),
                        IsRequired = c.Boolean(nullable: false),
                        EventID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TicketOptionID)
                .ForeignKey("dbo.Events", t => t.EventID)
                .Index(t => t.EventID);
            
            CreateTable(
                "dbo.TicketOptionChoices",
                c => new
                    {
                        TicketOptionChoiceID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Description = c.String(),
                        MarkupPrice = c.Decimal(nullable: false, storeType: "money"),
                        MaximumAvailable = c.Int(),
                        TicketOptionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TicketOptionChoiceID)
                .ForeignKey("dbo.TicketOptions", t => t.TicketOptionID)
                .Index(t => t.TicketOptionID);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketID = c.Int(nullable: false),
                        FirstName = c.String(maxLength: 50),
                        MiddleInitial = c.String(maxLength: 20),
                        LastName = c.String(maxLength: 100),
                        PreferredName = c.String(),
                        ArrivalTime = c.DateTime(),
                        TicketPriceID = c.Int(nullable: false),
                        TicketTotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderID = c.Int(nullable: false),
                        TicketDiscountID = c.Int(),
                    })
                .PrimaryKey(t => t.TicketID)
                .ForeignKey("dbo.Orders", t => t.OrderID)
                .ForeignKey("dbo.TicketDiscounts", t => t.TicketDiscountID)
                .ForeignKey("dbo.TicketPrices", t => t.TicketPriceID)
                .ForeignKey("dbo.TicketSeats", t => t.TicketID)
                .Index(t => t.TicketID)
                .Index(t => t.TicketPriceID)
                .Index(t => t.OrderID)
                .Index(t => t.TicketDiscountID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 256),
                        OrderStatus = c.Int(nullable: false),
                        EnteredOn = c.DateTime(nullable: false),
                        OrderTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RefundAmount = c.Decimal(precision: 18, scale: 2),
                        RefundedBy = c.String(maxLength: 256),
                        RefundedOn = c.DateTime(),
                        OverridedBy = c.String(maxLength: 256),
                        OverridedOn = c.DateTime(),
                        Notes = c.String(maxLength: 2000),
                        OverrideReason = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.OrderID);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        PaidOn = c.DateTime(),
                        PaymentType = c.Int(nullable: false),
                        PaymentDetails = c.String(),
                        GrossPaid = c.Decimal(precision: 18, scale: 2),
                        PaymentFee = c.Decimal(precision: 18, scale: 2),
                        NetPaid = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PaymentID)
                .ForeignKey("dbo.Orders", t => t.OrderID)
                .Index(t => t.OrderID);
            
            CreateTable(
                "dbo.TicketPrices",
                c => new
                    {
                        TicketPriceID = c.Int(nullable: false, identity: true),
                        EventAgeGroupID = c.Int(nullable: false),
                        TicketAreaID = c.Int(nullable: false),
                        TicketSectionID = c.Int(),
                        BasePrice = c.Decimal(nullable: false, storeType: "money"),
                        TicketCutoffID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TicketPriceID)
                .ForeignKey("dbo.EventAgeGroups", t => t.EventAgeGroupID)
                .ForeignKey("dbo.TicketAreas", t => t.TicketAreaID)
                .ForeignKey("dbo.TicketCutoffs", t => t.TicketCutoffID)
                .ForeignKey("dbo.TicketSections", t => t.TicketSectionID)
                .Index(t => t.EventAgeGroupID)
                .Index(t => t.TicketAreaID)
                .Index(t => t.TicketSectionID)
                .Index(t => t.TicketCutoffID);
            
            CreateTable(
                "dbo.TicketCutoffs",
                c => new
                    {
                        TicketCutoffID = c.Int(nullable: false, identity: true),
                        EventID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        OnSellDate = c.DateTime(nullable: false),
                        CutoffDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TicketCutoffID)
                .ForeignKey("dbo.Events", t => t.EventID)
                .Index(t => t.EventID);
            
            CreateTable(
                "dbo.TicketSections",
                c => new
                    {
                        TicketSectionID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        TicketAreaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TicketSectionID)
                .ForeignKey("dbo.TicketAreas", t => t.TicketAreaID)
                .Index(t => t.TicketAreaID);
            
            CreateTable(
                "dbo.TicketRows",
                c => new
                    {
                        TicketRowID = c.Int(nullable: false, identity: true),
                        Designation = c.String(nullable: false, maxLength: 50),
                        TicketSectionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TicketRowID)
                .ForeignKey("dbo.TicketSections", t => t.TicketSectionID)
                .Index(t => t.TicketSectionID);
            
            CreateTable(
                "dbo.TicketSeats",
                c => new
                    {
                        TicketSeatID = c.Int(nullable: false, identity: true),
                        SeatNumber = c.Int(nullable: false),
                        TicketAreaID = c.Int(nullable: false),
                        TicketRowID = c.Int(),
                        TicketSeatStatus = c.Int(nullable: false),
                        PreviousTicketSeatStatus = c.Int(nullable: false),
                        PendingPurchaseConfirmation = c.String(maxLength: 256),
                        PendingPurchaseExpiration = c.DateTime(),
                        TicketDiscountID = c.Int(),
                    })
                .PrimaryKey(t => t.TicketSeatID)
                .ForeignKey("dbo.TicketAreas", t => t.TicketAreaID)
                .ForeignKey("dbo.TicketDiscounts", t => t.TicketDiscountID)
                .ForeignKey("dbo.TicketRows", t => t.TicketRowID)
                .Index(t => t.TicketAreaID)
                .Index(t => t.TicketRowID)
                .Index(t => t.TicketDiscountID);
            
            CreateTable(
                "dbo.FaqCategories",
                c => new
                    {
                        FaqCategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        DisplayOrder = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        FaqSectionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FaqCategoryID);
            
            CreateTable(
                "dbo.FaqItems",
                c => new
                    {
                        FaqItemID = c.Int(nullable: false, identity: true),
                        Question = c.String(nullable: false, maxLength: 250),
                        Answer = c.String(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                        HelpfulMarks = c.Int(),
                        UnhelpfulMarks = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                        LastUpdatedBy = c.String(nullable: false, maxLength: 256),
                        FaqCategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FaqItemID)
                .ForeignKey("dbo.FaqCategories", t => t.FaqCategoryID)
                .Index(t => t.FaqCategoryID);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        LogID = c.Int(nullable: false, identity: true),
                        LogTime = c.DateTime(nullable: false),
                        LogType = c.Int(nullable: false),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.LogID);
            
            CreateTable(
                "dbo.SettingDataTypes",
                c => new
                    {
                        SettingDataTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.SettingDataTypeID);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        SettingID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        Value = c.String(nullable: false, maxLength: 1500),
                        SettingDataTypeID = c.Int(nullable: false),
                        SettingGroupID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SettingID)
                .ForeignKey("dbo.SettingDataTypes", t => t.SettingDataTypeID)
                .ForeignKey("dbo.SettingGroups", t => t.SettingGroupID)
                .Index(t => t.SettingDataTypeID)
                .Index(t => t.SettingGroupID);
            
            CreateTable(
                "dbo.SettingGroups",
                c => new
                    {
                        SettingGroupID = c.Int(nullable: false, identity: true),
                        SettingGroupName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.SettingGroupID);
            
            CreateTable(
                "dbo.CalendarRepeatDayCalendarEvents",
                c => new
                    {
                        CalendarRepeatDay_CalendarRepeatDayID = c.Int(nullable: false),
                        CalendarEvent_CalendarEventID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CalendarRepeatDay_CalendarRepeatDayID, t.CalendarEvent_CalendarEventID })
                .ForeignKey("dbo.CalendarRepeatDays", t => t.CalendarRepeatDay_CalendarRepeatDayID, cascadeDelete: true)
                .ForeignKey("dbo.CalendarEvents", t => t.CalendarEvent_CalendarEventID, cascadeDelete: true)
                .Index(t => t.CalendarRepeatDay_CalendarRepeatDayID)
                .Index(t => t.CalendarEvent_CalendarEventID);
            
            CreateTable(
                "dbo.TicketDiscountEventAgeGroups",
                c => new
                    {
                        TicketDiscount_TicketDiscountID = c.Int(nullable: false),
                        EventAgeGroup_EventAgeGroupID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TicketDiscount_TicketDiscountID, t.EventAgeGroup_EventAgeGroupID })
                .ForeignKey("dbo.TicketDiscounts", t => t.TicketDiscount_TicketDiscountID, cascadeDelete: true)
                .ForeignKey("dbo.EventAgeGroups", t => t.EventAgeGroup_EventAgeGroupID, cascadeDelete: true)
                .Index(t => t.TicketDiscount_TicketDiscountID)
                .Index(t => t.EventAgeGroup_EventAgeGroupID);
            
            CreateTable(
                "dbo.TicketOptionChoiceEventAgeGroups",
                c => new
                    {
                        TicketOptionChoice_TicketOptionChoiceID = c.Int(nullable: false),
                        EventAgeGroup_EventAgeGroupID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TicketOptionChoice_TicketOptionChoiceID, t.EventAgeGroup_EventAgeGroupID })
                .ForeignKey("dbo.TicketOptionChoices", t => t.TicketOptionChoice_TicketOptionChoiceID, cascadeDelete: true)
                .ForeignKey("dbo.EventAgeGroups", t => t.EventAgeGroup_EventAgeGroupID, cascadeDelete: true)
                .Index(t => t.TicketOptionChoice_TicketOptionChoiceID)
                .Index(t => t.EventAgeGroup_EventAgeGroupID);
            
            CreateTable(
                "dbo.TicketTicketOptionChoices",
                c => new
                    {
                        Ticket_TicketID = c.Int(nullable: false),
                        TicketOptionChoice_TicketOptionChoiceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ticket_TicketID, t.TicketOptionChoice_TicketOptionChoiceID })
                .ForeignKey("dbo.Tickets", t => t.Ticket_TicketID, cascadeDelete: true)
                .ForeignKey("dbo.TicketOptionChoices", t => t.TicketOptionChoice_TicketOptionChoiceID, cascadeDelete: true)
                .Index(t => t.Ticket_TicketID)
                .Index(t => t.TicketOptionChoice_TicketOptionChoiceID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Settings", "SettingGroupID", "dbo.SettingGroups");
            DropForeignKey("dbo.Settings", "SettingDataTypeID", "dbo.SettingDataTypes");
            DropForeignKey("dbo.FaqItems", "FaqCategoryID", "dbo.FaqCategories");
            DropForeignKey("dbo.TicketOptionDiscounts", "TicketOptionID", "dbo.TicketOptions");
            DropForeignKey("dbo.Tickets", "TicketID", "dbo.TicketSeats");
            DropForeignKey("dbo.TicketRows", "TicketSectionID", "dbo.TicketSections");
            DropForeignKey("dbo.TicketSeats", "TicketRowID", "dbo.TicketRows");
            DropForeignKey("dbo.TicketSeats", "TicketDiscountID", "dbo.TicketDiscounts");
            DropForeignKey("dbo.TicketSeats", "TicketAreaID", "dbo.TicketAreas");
            DropForeignKey("dbo.TicketPrices", "TicketSectionID", "dbo.TicketSections");
            DropForeignKey("dbo.TicketSections", "TicketAreaID", "dbo.TicketAreas");
            DropForeignKey("dbo.Tickets", "TicketPriceID", "dbo.TicketPrices");
            DropForeignKey("dbo.TicketPrices", "TicketCutoffID", "dbo.TicketCutoffs");
            DropForeignKey("dbo.TicketCutoffs", "EventID", "dbo.Events");
            DropForeignKey("dbo.TicketPrices", "TicketAreaID", "dbo.TicketAreas");
            DropForeignKey("dbo.TicketPrices", "EventAgeGroupID", "dbo.EventAgeGroups");
            DropForeignKey("dbo.TicketTicketOptionChoices", "TicketOptionChoice_TicketOptionChoiceID", "dbo.TicketOptionChoices");
            DropForeignKey("dbo.TicketTicketOptionChoices", "Ticket_TicketID", "dbo.Tickets");
            DropForeignKey("dbo.Tickets", "TicketDiscountID", "dbo.TicketDiscounts");
            DropForeignKey("dbo.Tickets", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Payments", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.TicketOptionChoices", "TicketOptionID", "dbo.TicketOptions");
            DropForeignKey("dbo.TicketOptionChoiceEventAgeGroups", "EventAgeGroup_EventAgeGroupID", "dbo.EventAgeGroups");
            DropForeignKey("dbo.TicketOptionChoiceEventAgeGroups", "TicketOptionChoice_TicketOptionChoiceID", "dbo.TicketOptionChoices");
            DropForeignKey("dbo.TicketOptions", "EventID", "dbo.Events");
            DropForeignKey("dbo.TicketOptionDiscounts", "TicketDiscountID", "dbo.TicketDiscounts");
            DropForeignKey("dbo.TicketAreaDiscounts", "TicketDiscountID", "dbo.TicketDiscounts");
            DropForeignKey("dbo.TicketDiscountEventAgeGroups", "EventAgeGroup_EventAgeGroupID", "dbo.EventAgeGroups");
            DropForeignKey("dbo.TicketDiscountEventAgeGroups", "TicketDiscount_TicketDiscountID", "dbo.TicketDiscounts");
            DropForeignKey("dbo.TicketDiscounts", "EventID", "dbo.Events");
            DropForeignKey("dbo.TicketAreaDiscounts", "TicketAreaID", "dbo.TicketAreas");
            DropForeignKey("dbo.TicketAreas", "EventID", "dbo.Events");
            DropForeignKey("dbo.VenueScheduleLocations", "VenueID", "dbo.Venues");
            DropForeignKey("dbo.VenueRows", "VenueSectionID", "dbo.VenueSections");
            DropForeignKey("dbo.VenueSections", "VenueAreaID", "dbo.VenueAreas");
            DropForeignKey("dbo.VenueAreas", "VenueID", "dbo.Venues");
            DropForeignKey("dbo.Venues", "StateID", "dbo.States");
            DropForeignKey("dbo.Events", "VenueID", "dbo.Venues");
            DropForeignKey("dbo.ScheduleItems", "VenueScheduleLocationID", "dbo.VenueScheduleLocations");
            DropForeignKey("dbo.ScheduleItems", "ScheduleTypeID", "dbo.ScheduleTypes");
            DropForeignKey("dbo.ScheduleItems", "ScheduleStatusID", "dbo.ScheduleStatus");
            DropForeignKey("dbo.ScheduleItems", "EventID", "dbo.Events");
            DropForeignKey("dbo.Events", "EventID", "dbo.PageContents");
            DropForeignKey("dbo.Events", "EventSeriesID", "dbo.EventSeries");
            DropForeignKey("dbo.EventFaqItems", "EventFaqCategoryID", "dbo.EventFaqCategories");
            DropForeignKey("dbo.EventFaqCategories", "EventID", "dbo.Events");
            DropForeignKey("dbo.EventAgeGroups", "EventID", "dbo.Events");
            DropForeignKey("dbo.States", "CountryID", "dbo.Countries");
            DropForeignKey("dbo.PageContents", "PageTypeID", "dbo.PageTypes");
            DropForeignKey("dbo.PageContentImages", "PageContentID", "dbo.PageContents");
            DropForeignKey("dbo.PageContentImages", "ImageID", "dbo.Images");
            DropForeignKey("dbo.PageContents", "LayoutTypeID", "dbo.LayoutTypes");
            DropForeignKey("dbo.PageContents", "ContentSubCategoryID", "dbo.ContentSubCategories");
            DropForeignKey("dbo.ContentStyles", "PageContentID", "dbo.PageContents");
            DropForeignKey("dbo.ContentScripts", "PageContentID", "dbo.PageContents");
            DropForeignKey("dbo.PageContents", "ContentCategoryID", "dbo.ContentCategories");
            DropForeignKey("dbo.ContentBlocks", "PageContentID", "dbo.PageContents");
            DropForeignKey("dbo.PageContents", "ContentAreaID", "dbo.ContentAreas");
            DropForeignKey("dbo.VisitedPages", "ContactID", "dbo.Contacts");
            DropForeignKey("dbo.Contacts", "ContactTypeID", "dbo.ContactTypes");
            DropForeignKey("dbo.CalendarEvents", "CalendarRepeatTypeID", "dbo.CalendarRepeatTypes");
            DropForeignKey("dbo.CalendarRepeatDayCalendarEvents", "CalendarEvent_CalendarEventID", "dbo.CalendarEvents");
            DropForeignKey("dbo.CalendarRepeatDayCalendarEvents", "CalendarRepeatDay_CalendarRepeatDayID", "dbo.CalendarRepeatDays");
            DropForeignKey("dbo.CalendarEvents", "CalendarEventTypeID", "dbo.CalendarEventTypes");
            DropForeignKey("dbo.CalendarEvents", "CalendarEventStatusID", "dbo.CalendarEventStatus");
            DropForeignKey("dbo.CalendarEvents", "CalendarEventLocationID", "dbo.CalendarEventLocations");
            DropForeignKey("dbo.CalendarEvents", "CalendarID", "dbo.Calendars");
            DropIndex("dbo.TicketTicketOptionChoices", new[] { "TicketOptionChoice_TicketOptionChoiceID" });
            DropIndex("dbo.TicketTicketOptionChoices", new[] { "Ticket_TicketID" });
            DropIndex("dbo.TicketOptionChoiceEventAgeGroups", new[] { "EventAgeGroup_EventAgeGroupID" });
            DropIndex("dbo.TicketOptionChoiceEventAgeGroups", new[] { "TicketOptionChoice_TicketOptionChoiceID" });
            DropIndex("dbo.TicketDiscountEventAgeGroups", new[] { "EventAgeGroup_EventAgeGroupID" });
            DropIndex("dbo.TicketDiscountEventAgeGroups", new[] { "TicketDiscount_TicketDiscountID" });
            DropIndex("dbo.CalendarRepeatDayCalendarEvents", new[] { "CalendarEvent_CalendarEventID" });
            DropIndex("dbo.CalendarRepeatDayCalendarEvents", new[] { "CalendarRepeatDay_CalendarRepeatDayID" });
            DropIndex("dbo.Settings", new[] { "SettingGroupID" });
            DropIndex("dbo.Settings", new[] { "SettingDataTypeID" });
            DropIndex("dbo.FaqItems", new[] { "FaqCategoryID" });
            DropIndex("dbo.TicketSeats", new[] { "TicketDiscountID" });
            DropIndex("dbo.TicketSeats", new[] { "TicketRowID" });
            DropIndex("dbo.TicketSeats", new[] { "TicketAreaID" });
            DropIndex("dbo.TicketRows", new[] { "TicketSectionID" });
            DropIndex("dbo.TicketSections", new[] { "TicketAreaID" });
            DropIndex("dbo.TicketCutoffs", new[] { "EventID" });
            DropIndex("dbo.TicketPrices", new[] { "TicketCutoffID" });
            DropIndex("dbo.TicketPrices", new[] { "TicketSectionID" });
            DropIndex("dbo.TicketPrices", new[] { "TicketAreaID" });
            DropIndex("dbo.TicketPrices", new[] { "EventAgeGroupID" });
            DropIndex("dbo.Payments", new[] { "OrderID" });
            DropIndex("dbo.Tickets", new[] { "TicketDiscountID" });
            DropIndex("dbo.Tickets", new[] { "OrderID" });
            DropIndex("dbo.Tickets", new[] { "TicketPriceID" });
            DropIndex("dbo.Tickets", new[] { "TicketID" });
            DropIndex("dbo.TicketOptionChoices", new[] { "TicketOptionID" });
            DropIndex("dbo.TicketOptions", new[] { "EventID" });
            DropIndex("dbo.TicketOptionDiscounts", new[] { "TicketOptionID" });
            DropIndex("dbo.TicketOptionDiscounts", new[] { "TicketDiscountID" });
            DropIndex("dbo.TicketDiscounts", new[] { "EventID" });
            DropIndex("dbo.TicketAreaDiscounts", new[] { "TicketAreaID" });
            DropIndex("dbo.TicketAreaDiscounts", new[] { "TicketDiscountID" });
            DropIndex("dbo.TicketAreas", new[] { "EventID" });
            DropIndex("dbo.VenueRows", new[] { "VenueSectionID" });
            DropIndex("dbo.VenueSections", new[] { "VenueAreaID" });
            DropIndex("dbo.VenueAreas", new[] { "VenueID" });
            DropIndex("dbo.Venues", new[] { "StateID" });
            DropIndex("dbo.VenueScheduleLocations", new[] { "VenueID" });
            DropIndex("dbo.ScheduleItems", new[] { "EventID" });
            DropIndex("dbo.ScheduleItems", new[] { "ScheduleTypeID" });
            DropIndex("dbo.ScheduleItems", new[] { "ScheduleStatusID" });
            DropIndex("dbo.ScheduleItems", new[] { "VenueScheduleLocationID" });
            DropIndex("dbo.EventFaqItems", new[] { "EventFaqCategoryID" });
            DropIndex("dbo.EventFaqCategories", new[] { "EventID" });
            DropIndex("dbo.Events", new[] { "EventSeriesID" });
            DropIndex("dbo.Events", new[] { "VenueID" });
            DropIndex("dbo.Events", new[] { "EventID" });
            DropIndex("dbo.EventAgeGroups", new[] { "EventID" });
            DropIndex("dbo.States", new[] { "CountryID" });
            DropIndex("dbo.PageContentImages", new[] { "ImageID" });
            DropIndex("dbo.PageContentImages", new[] { "PageContentID" });
            DropIndex("dbo.ContentStyles", new[] { "PageContentID" });
            DropIndex("dbo.ContentScripts", new[] { "PageContentID" });
            DropIndex("dbo.ContentBlocks", new[] { "PageContentID" });
            DropIndex("dbo.PageContents", new[] { "PageTypeID" });
            DropIndex("dbo.PageContents", new[] { "LayoutTypeID" });
            DropIndex("dbo.PageContents", new[] { "ContentSubCategoryID" });
            DropIndex("dbo.PageContents", new[] { "ContentCategoryID" });
            DropIndex("dbo.PageContents", new[] { "ContentAreaID" });
            DropIndex("dbo.VisitedPages", new[] { "ContactID" });
            DropIndex("dbo.Contacts", new[] { "ContactTypeID" });
            DropIndex("dbo.CalendarEvents", new[] { "CalendarID" });
            DropIndex("dbo.CalendarEvents", new[] { "CalendarRepeatTypeID" });
            DropIndex("dbo.CalendarEvents", new[] { "CalendarEventStatusID" });
            DropIndex("dbo.CalendarEvents", new[] { "CalendarEventTypeID" });
            DropIndex("dbo.CalendarEvents", new[] { "CalendarEventLocationID" });
            DropTable("dbo.TicketTicketOptionChoices");
            DropTable("dbo.TicketOptionChoiceEventAgeGroups");
            DropTable("dbo.TicketDiscountEventAgeGroups");
            DropTable("dbo.CalendarRepeatDayCalendarEvents");
            DropTable("dbo.SettingGroups");
            DropTable("dbo.Settings");
            DropTable("dbo.SettingDataTypes");
            DropTable("dbo.Logs");
            DropTable("dbo.FaqItems");
            DropTable("dbo.FaqCategories");
            DropTable("dbo.TicketSeats");
            DropTable("dbo.TicketRows");
            DropTable("dbo.TicketSections");
            DropTable("dbo.TicketCutoffs");
            DropTable("dbo.TicketPrices");
            DropTable("dbo.Payments");
            DropTable("dbo.Orders");
            DropTable("dbo.Tickets");
            DropTable("dbo.TicketOptionChoices");
            DropTable("dbo.TicketOptions");
            DropTable("dbo.TicketOptionDiscounts");
            DropTable("dbo.TicketDiscounts");
            DropTable("dbo.TicketAreaDiscounts");
            DropTable("dbo.TicketAreas");
            DropTable("dbo.VenueRows");
            DropTable("dbo.VenueSections");
            DropTable("dbo.VenueAreas");
            DropTable("dbo.Venues");
            DropTable("dbo.VenueScheduleLocations");
            DropTable("dbo.ScheduleTypes");
            DropTable("dbo.ScheduleStatus");
            DropTable("dbo.ScheduleItems");
            DropTable("dbo.EventSeries");
            DropTable("dbo.EventFaqItems");
            DropTable("dbo.EventFaqCategories");
            DropTable("dbo.Events");
            DropTable("dbo.EventAgeGroups");
            DropTable("dbo.States");
            DropTable("dbo.Countries");
            DropTable("dbo.PageTypes");
            DropTable("dbo.Images");
            DropTable("dbo.PageContentImages");
            DropTable("dbo.LayoutTypes");
            DropTable("dbo.ContentSubCategories");
            DropTable("dbo.ContentStyles");
            DropTable("dbo.ContentScripts");
            DropTable("dbo.ContentCategories");
            DropTable("dbo.ContentBlocks");
            DropTable("dbo.PageContents");
            DropTable("dbo.ContentAreas");
            DropTable("dbo.VisitedPages");
            DropTable("dbo.ContactTypes");
            DropTable("dbo.Contacts");
            DropTable("dbo.CalendarRepeatTypes");
            DropTable("dbo.CalendarRepeatDays");
            DropTable("dbo.CalendarEventTypes");
            DropTable("dbo.CalendarEventStatus");
            DropTable("dbo.Calendars");
            DropTable("dbo.CalendarEvents");
            DropTable("dbo.CalendarEventLocations");
            DropTable("dbo.Alerts");
        }
    }
}
