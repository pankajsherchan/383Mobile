'use strict';
eventsApp.factory('MovieService', function ($http) {

    return {

        getMovies: function () {
          

            return $http({ method: 'GET', url: '/api/movies'});
                //}).then(function mySucces(response) {
                //    $scope.data = response.data;
                //}, function myError(response) {
                //    $scope.myData = response.statusText;
                //});


                //    .then(function (response) {
                //    $scope.myData = response.data;
                //});


      

          
        },

        getMovie: function($id) {
    
            return $http({ method: 'GET' , url: 'api/movies/$id'});
        }

    };

           
});