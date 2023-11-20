////Call this to register our module to main application
//var moduleName = "MyTestModule";

//if (AppDependencies != undefined) {
//    AppDependencies.push(moduleName);
//}

//angular.module(moduleName, [])
//    .run(
//        ['virtoCommerce.orderModule.knownOperations', 'platformWebApp.bladeNavigationService', 'platformWebApp.ui-grid.extension',
//            function (knownOperations,  $compile, scopeResolver, settings, bladeNavigationService, gridOptionExtension) {
//                var foundTemplate = knownOperations.getOperation('CustomerOrder');
//                if (foundTemplate) {
//                    foundTemplate.detailBlade.metaFields.push(
//                        {
//                            name: 'NewOrderField',
//                            title: "New Order field",
//                            valueType: "ShortText"
//                        });

                   
//                }

//                // Register extension to add custom column permanently (data-independent) into the list
//                gridOptionExtension.registerExtension("customerOrder-list-grid", function (gridOptions) {
//                    var customColumnDefs = [
//                        { name: 'NewOrderField', displayName: 'orders.blades.customerOrder-list.labels.NewOrderField', width: '***' }
//                    ];

//                    gridOptions.columnDefs = _.union(gridOptions.columnDefs, customColumnDefs);
//                });
//            }
//        ]);

