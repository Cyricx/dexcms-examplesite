module.exports = function (grunt) {

    var WCParser = require('webconfig-parser'),
        version = require('./package.json').version,
        config = WCParser.parse({ url: './Web.config' }),
        dexCMSUtilities = require('./node_modules/dexcms-core/DexCMS.Core.Client/utilities'),
        helpers = dexCMSUtilities.helpers,
        dexRoot = '../../';

    var options = {
        modules: [
            "Core",
            "Alerts",
            "Base",
            "Calendars",
            "Faqs",
            "Tickets"
        ],
        defaultSettings: {
            localUrl: config.LocalServerUrl,
            developmentUrl: config.DevelopmentServerUrl,
            productionUrl: config.ProductionServerUrl,
            cacheBuster: version
        },
        vendorFiles: require('./VendorFiles'),
        versionSuffix: version,
        cacheBustConfigs: [
            'Web.config'
        ],
        symlinks: [
            { module: 'core', src: dexRoot + 'dexcms.core/' }
        ],
        debugXml: {
            projectFile: 'DexCMS.ExampleSite.csproj',
        }
    };

    var websiteGrunt = dexCMSUtilities.gruntBuilder.website(grunt, options);
    var gruntOptions = websiteGrunt.builder();

    //Configuration setup
    grunt.initConfig(gruntOptions);
    //load npm tasks
    websiteGrunt.loadTasks();

    //register tasks
    websiteGrunt.registerTasks();
};