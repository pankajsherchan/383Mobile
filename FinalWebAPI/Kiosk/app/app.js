'use strict';

var eventsApp = angular.module('eventsApp', ['ngRoute', 'angular-loading-bar']);
eventsApp.config(function($routeProvider) {
    $routeProvider

        // route for the home page
        .when('/', {
            templateUrl: 'app/views/home.html',
            controller  : 'movieController'
        })

        // route for the movie detail page
        .when('/movies/:MovieId', {
            templateUrl : 'app/views/movie.html',
            controller  : 'movieController'
        })

        // route for the checkout page
        .when('/cart', {
            templateUrl: 'app/views/shoppingCart.htm',
            controller  : 'movieController'
        });
});