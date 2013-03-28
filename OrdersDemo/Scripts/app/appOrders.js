﻿var OrderCtrl = function ($scope, $http) {

    var results = $http.get('api/orders');
    results.success(function (data) {
        $scope.orders = data.orders;
    });

    $scope.addOrder = function () {
        var newOrder = {
            'customerName': $scope.newOrderCustomerName,
            'itemName': $scope.newOrderItemName,
            'quantity': $scope.newOrderQuantity
        };

        $http.post('api/orders', newOrder);
        $scope.orders.push(newOrder);
        $('#modalOrders').modal('hide');
    };
}