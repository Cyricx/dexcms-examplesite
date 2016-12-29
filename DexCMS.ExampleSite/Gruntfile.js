module.exports = function (grunt) {

    var WCParser = require('webconfig-parser'),
        version = require('./package.json').version,
        config = WCParser.parse({ url: './Web.config' }),
        dexCMSUtilities = require('./node_modules/dexcms-core/DexCMS.Core.Client/utilities'),
        helpers = dexCMSUtilities.helpers,
        dexRoot = '../../../dexcms/';

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
//        jsonOverrides: {},
        vendorFiles: require('./VendorFiles'),
        versionSuffix: version,
        cacheBustConfigs: [
            'Web.config'
        ],
        symlinks: [
            { module: 'core', src: dexRoot + 'dexcms.core/' }
        ]
    };

    var websiteGrunt = dexCMSUtilities.gruntBuilder.website(grunt, options);
    var gruntOptions = websiteGrunt.builder();
    gruntOptions.xmlpoke = {
        debugReferences: {
            options: {
                namespaces: {
                    'w': 'http://schemas.microsoft.com/developer/msbuild/2003'
                },
                replacements: [{
                    xpath: '/w:Project/w:ItemGroup/w:Reference/w:HintPath',
                    value: function (node) {
                        var nodeValue = node.childNodes['0'].data;

                        var regex = /node_modules\\dexcms-([a-z]*)\\dist\\([\w\.]*)\.dll/gi;

                        var match = regex.exec(nodeValue);
                        if (match) {
                            return '..\\..\\dexcms.' + match[1] + '\\' + match[2] + '\\bin\\release\\' + match[2] + '.dll';
                            
                        } else {
                            return nodeValue;
                        }

                    }
                }],
            },
            files: {
                'DexCMS.ExampleSite.csproj': 'DexCMS.ExampleSite.csproj'
            }
        },
        prodReferences: {
            options: {
                namespaces: {
                    'w': 'http://schemas.microsoft.com/developer/msbuild/2003'
                },
                replacements: [{
                    xpath: '/w:Project/w:ItemGroup/w:Reference/w:HintPath',
                    value: function (node) {
                        var nodeValue = node.childNodes['0'].data;

                        var regex = /\.\.\\\.\.\\DexCMS\.([\w]*)\\([\w\.]*)\\bin\\release\\([\w\.]*)\.dll/gi;

                        var match = regex.exec(nodeValue);
                        if (match) {
                            return 'node_modules\\dexcms-' + match[1] + '\\dist\\' + match[2] + '.dll';
                        } else {
                            return nodeValue;
                        }

                    }
                }],
            },
            files: {
                'DexCMS.ExampleSite.csproj': 'DexCMS.ExampleSite.csproj'
            }
        }
    };
    //Configuration setup
    grunt.initConfig(gruntOptions);
    //load npm tasks
    websiteGrunt.loadTasks();
    grunt.loadNpmTasks('grunt-xmlpoke');

    //register tasks
    websiteGrunt.registerTasks();
};