(function () {
    'use strict';

    wallApp.controller("wallcontroller", ["$scope", "$http", function($scope, $http) {
        $scope.Statuses = [];

        $scope.createComment = function(status) {
            $http.post('/Wall/CreateComment', status).then(function (response) {
                refreshStatuses();
            });
        };

        refreshStatuses();

        function refreshStatuses() {
            $http.get('/Wall/Status').then(function(response) {
                $scope.Statuses = response.data.Statuses;
            });
        }
    }]);  
})();
