// Call this to register your module to main application
var moduleName = 'MyTestModule';

if (AppDependencies !== undefined) {
    AppDependencies.push(moduleName);
}

angular.module(moduleName, [])
    .config(['$stateProvider',
        function ($stateProvider) {
            $stateProvider
                .state('workspace.MyTestModuleState', {
                    url: '/MyTestModule',
                    templateUrl: '$(Platform)/Scripts/common/templates/home.tpl.html',
                    controller: [
                        'platformWebApp.bladeNavigationService',
                        function (bladeNavigationService) {
                            var newBlade = {
                                id: 'blade1',
                                controller: 'MyTestModule.helloWorldController',
                                template: 'Modules/$(MyCoolCompany.MyTestModule)/Scripts/blades/hello-world.html',
                                isClosingDisabled: true,
                            };
                            bladeNavigationService.showBlade(newBlade);
                        }
                    ]
                });
        }
    ])
    .run(['platformWebApp.mainMenuService', '$state',
        function (mainMenuService, $state) {
            //Register module in main menu
            var menuItem = {
                path: 'browse/MyTestModule',
                icon: 'fa fa-cube',
                title: 'MyTestModule',
                priority: 100,
                action: function () { $state.go('workspace.MyTestModuleState'); },
                permission: 'MyTestModule:access',
            };
            mainMenuService.addMenuItem(menuItem);
        }
    ]);
