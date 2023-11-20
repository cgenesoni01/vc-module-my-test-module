angular.module('MyTestModule')
    .controller('MyTestModule.helloWorldController', ['$scope', 'MyTestModule.webApi', function ($scope, api) {
        var blade = $scope.blade;
        blade.title = 'MyTestModule';

        blade.refresh = function () {
            //api.get(function (data) {
                blade.title = 'MyTestModule title';
                //blade.data = data.result;
                blade.isLoading = false;
            //});
        };

        blade.refresh();
    }]);
