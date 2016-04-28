'use strict';
//var eventsApp = angular.module('eventsApp', ['ngRoute', 'angular-loading-bar']);
    eventsApp.controller('movieController',
        function movieController($scope, $routeParams, $http, DataService, MovieService) {
        //    $scope.data = MovieService.getMovies();
            //   haha;
            //  alert($routeParams);
            $scope.waitMessage = "";
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

