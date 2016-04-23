'use strict';

    eventsApp.controller('movieController',
        function movieController($scope, $routeParams, MovieService) {
        //    $scope.data = MovieService.getMovies();
            //   haha;
          //  alert($routeParams);
            MovieService.getMovies()
          .success(function (response) {
              $scope.data = response;
          })
            .error(function (response) {
                $console.log = response;
            });
            
        
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

