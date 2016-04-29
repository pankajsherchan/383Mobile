'use strict';
//var eventsApp = angular.module('eventsApp', ['ngRoute', 'angular-loading-bar']);
    eventsApp.controller('movieController',
        function movieController($scope, $routeParams, $http, DataService, MovieService) {
        //    $scope.data = MovieService.getMovies();
            //   haha;
            //  alert($routeParams);
            $scope.waitMessage = "";
            $scope.qrcodeString = "";
            $scope.qrcode = "";
            $scope.type = "";
            $scope.timeSelected = "";
            $scope.reset = "reset"
            $scope.check = false;
            $scope.ScreenNumber = "";
            $scope.adult = 10.00;
            $scope.child = 5.00;
            $scope.old = 7.00;
            $scope.cart = DataService.cart;
            MovieService.getMovies()
          .success(function (response) {
              $scope.data = response;
          })
            .error(function (response) {
                $console.log = response;
            });
            $scope.httpget = function () {
                $scope.waitMessage = "Please wait while we grab a list of movies.....";
                $http.get("http://localhost:51269/api/movies").then(function (data) {
                    $scope.movies = data.data;
                    $scope.waitMessage = "";
                })
            }

            $scope.submitTime = function (time) {
                $scope.timeSelected = time;
                $scope.check = true;
            }

            $scope.uncheck = function () {
                $scope.check = false;
                $scope.timeSelected = "";

                //if ($scope.checked == $event.target.value) $scope.checked = false
            }

            $scope.update = function (qrcode) {
                for (var i = 0; i < qrcode.length; i++) {
                    $scope.qrcodeString += "\n [Movie: " + qrcode[i].Name + " Type: " + qrcode[i].type + " Price: " + qrcode[i].price + " Time: " + qrcode[i].time + "]";
                }

                 $scope.image = "https://api.qrserver.com/v1/create-qr-code/?size=150x150&data=" + $scope.qrcodeString;
                //$http.get("https://api.qrserver.com/v1/create-qr-code/?size=150x150&data=dafdsasf").then(function (data) {
                //    $scope.image = data.data;
                //    $scope.waitMessage = "";
                
            }

            $scope.updatePurchase = function (email, updateMovie) {
                $scope.buy = true;
                $scope.waitMessage = "Please wait while we proccess your order.....";
                $http.post("api/PurchaseDetails/Update?email=" + email, updateMovie).then(function (response) {
                    $scope.cart.clearItems();
                    $scope.waitMessage = "";
                    $scope.buy = false;
                })
            }

            $scope.upcoming = function () {
                $scope.waitMessage = "Please wait while we grab a list of movies.....";
                $http.get("http://localhost:51269/api/movies/1").then(function (data) {
                    $scope.movies = data.data;
                    $scope.waitMessage = "";
                })
            }
        
            if ($routeParams.Id != null) {
                $scope.movie = $scope.getProduct($routeParams.Id);
            }

            $scope.getProduct = function (id) {
                for (var i = 0; i < this.data.length; i++) {
                    if (this.data[i].Id == id)
                        return this.data[i];
                }
                return null;
            }

            $scope.setSelectedItem = function (i) {
                $scope.selectedItem = i;
            }
     

        });

