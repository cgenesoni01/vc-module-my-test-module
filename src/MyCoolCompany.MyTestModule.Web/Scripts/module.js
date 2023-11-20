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
                                id: 'blade1MyTestModule',
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
    .run(['platformWebApp.mainMenuService', '$state', 'virtoCommerce.orderModule.knownOperations', 'platformWebApp.ui-grid.extension',
        function (mainMenuService, $state, knownOperations, gridOptionExtension) {
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

            var foundTemplate = knownOperations.getOperation('CustomerOrder');
            if (foundTemplate) {
                foundTemplate.detailBlade.metaFields.push(
                    {
                        name: 'NewOrderField',
                        title: "New Order field",
                        valueType: "ShortText"
                    });
            }

            // Register extension to add custom column permanently (data-independent) into the list
            gridOptionExtension.registerExtension("customerOrder-list-grid", function (gridOptions) {
                var customColumnDefs = [
                    { name: 'NewOrderField', displayName: 'orders.blades.customerOrder-list.labels.NewOrderField', width: '***' }
                ];

                gridOptions.columnDefs = _.union(gridOptions.columnDefs, customColumnDefs);
            });

        }
    ]);
