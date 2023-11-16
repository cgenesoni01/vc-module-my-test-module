angular.module('MyTestModule')
    .factory('MyTestModule.webApi', ['$resource', function ($resource) {
        return $resource('api/my-test-module');
    }]);
