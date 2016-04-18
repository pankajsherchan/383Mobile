'use strict';

var eventsApp = angular.module('eventsApp', ['ngRoute', 'angular-loading-bar']);
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
        // route for the movie detail page
        .when('/movies/:id', {
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