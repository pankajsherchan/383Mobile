'use strict';

var eventsApp = angular.module('eventsApp', ['ngRoute', 'angular-loading-bar', 'ngResource']);
eventsApp.config(function($routeProvider) {
    $routeProvider

        // route for the home page
        .when('/', {
            templateUrl: 'app/views/home.html',
            controller: 'movieController'
        })

        .when('/movieList', {
            templateUrl: 'app/views/movieList.html',
            controller: 'movieController'
        })
         .when('/upComingMovies', {
             templateUrl: 'app/views/UpComingMovies.html',
             controller: 'movieController'
         })
        // route for the movie detail page
        .when('/movies/:Id', {
            templateUrl: 'app/views/movie.html',
            controller: 'movieController'
        })

        // route for the checkout page
        .when('/cart', {
            templateUrl: 'app/views/shoppingCart.html',
            controller: 'movieController'
        });
    $routeProvider.otherwise({ redirectTo: '/' });
});
eventsApp.factory("DataService", function () {


    // create shopping cart
    var myCart = new shoppingCart("eventsApp");

    myCart.addCheckoutParameters("Purchase");



    // return data object with store and cart
    return {
        cart: myCart
    };

});