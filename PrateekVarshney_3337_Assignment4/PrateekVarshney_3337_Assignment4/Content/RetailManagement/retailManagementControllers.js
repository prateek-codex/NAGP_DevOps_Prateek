
retailManagementApp.controller('Index', ['$scope', '$location', '$http', 'retailService', function ($scope, $location, $http, retailService) {

    $scope.visibleWindow = "Default";
    $scope.false = false;
    $scope.role = "none";
    $scope.isUpdate = false;
    $scope.product = {};
    $scope.viewCart = false;

    $scope.Products = [];

    (function GetProducts()
    {
        var url = "/Home/GetProductList";

        $http.get(url, $scope.product).
          then(function (response) {
              $scope.Products = response.data;
          }, function (response) {
              alert("Not able to fetch product list !!! Please set up server side code correctly");
          });

        setTimeout(function () { $scope.$apply(); console.log($scope.Products) }, 100);
    })();

    $scope.ShowAbout = function () {
        $scope.visibleWindow = "About";
    }

    $scope.ShowHome = function () {
        if ($scope.role == "admin") {
            console.log("here1");
            $scope.visibleWindow = "adminProductManagement";
        }

        if ($scope.role == "user") {
            console.log("here1");
            $scope.visibleWindow = "userHome";
        }

        if($scope.role == "none") {
            console.log("here1");
            $scope.visibleWindow = "Default";
        }
    }

    $scope.ShowContact = function () {
        $scope.visibleWindow = "Contact";
    }

    $scope.LoginAsUser = function () {
        $scope.role = "user";
        $scope.visibleWindow = "userHome";
    }

    $scope.LoginAsAdmin = function () {
        $scope.role = "admin";
        $scope.visibleWindow = "adminProductManagement";
    }

    $scope.AddToCart = function (product) {
        retailService.AddProductToCart(product);
        $scope.viewCart = !$scope.viewCart;
        $scope.ViewCart();
    }

    $scope.Cancel = function () {
        $scope.visibleWindow = "adminProductManagement";
    }

    $scope.isValidated = $scope.product.name && $scope.product.type && $scope.product.cost;

    $scope.AddProduct = function () {
        // Server side handling for updating the product
        console.log($scope.product);
        var url = "/Home/Create";
        $http.post(url, $scope.product).
          then(function (response) {
              $scope.Products = response.data;
              alert("Product Added Successfully");
              $scope.ShowHome();
          }, function (response) {
              alert("Product add failed");
          });
    }

    $scope.AddProductScreen = function () {
        $scope.product = {};
        $scope.isUpdate = false;
        $scope.visibleWindow = "adminAddProduct";
    }

    $scope.EditProduct = function (product) {
        $scope.product = product;
        $scope.isUpdate = true;
        $scope.visibleWindow = "adminAddProduct";
    }

    $scope.UpdateProduct = function () {
        var url = "/Home/Edit";
        $http.post(url, $scope.product).
          then(function (response) {
              $scope.Products = response.data;
              alert("Product Updated Successfully");
              $scope.ShowHome();
          }, function (response) {
              alert("Product add failed");
          });
    }

    $scope.DeleteProduct = function () {
        // Server side handling for deleting the product
        var url = "/Home/Delete";
        $http.post(url, $scope.product).
          then(function (response) {
              $scope.Products = response.data;
              alert("Product deleted Successfully");
              $scope.ShowHome();
          }, function (response) {
              alert("Product delete failed");
          });
    }

    $scope.ViewCart = function()
    {
        $scope.viewCart = !$scope.viewCart;
        $scope.Cart = retailService.GetCart();
        console.log($scope.Cart);
    }

    
}]);
