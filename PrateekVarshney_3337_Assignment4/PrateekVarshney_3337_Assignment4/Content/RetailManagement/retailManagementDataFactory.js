retailManagementApp.factory('retailService', [function () {

    var service = [];

    service.GetCart = function () {
        var cart = angular.fromJson(sessionStorage.Cart);

        if (cart == null) return [];
        else return cart;
    }

    service.StoreCart = function (cart) {
        sessionStorage.Cart = angular.toJson(cart);
    }

    service.selectedVehicleService = {};

    service.AddProductToCart = function (product) {
        var Cart = this.GetCart();

        if (!Cart) cart = [];

        if (!Cart) Cart = [];
            Cart.push(product);

        this.StoreCart(Cart);
        this.Operations.push("add");
    }

    service.GetNextId = function() {

        var newId = angular.fromJson(sessionStorage.lastStoredId);

        if (newId) {
            sessionStorage.lastStoredId = newId + 1;
            newId += 1;
        }
        else {
            newId = 1;
            sessionStorage.lastStoredId = 1;
        }
        return newId;
    }

    service.DeleteServiceRequest = function (service) {

        var serviceList = this.GetServiceList();
        var removeIndex = -1;

        for(var i=0; i<serviceList.length; i++)
        {
            if (serviceList[i].id == service.id)
            {
                removeIndex = i;
            }
        }
        serviceList.splice(removeIndex, 1);
        this.StoreServiceList(serviceList);
        this.DeletedServiceList.push(service)
        this.Operations.push("delete");
    }

    service.Operations = [];

    service.DeletedServiceList = [];

    return service;
}]);
