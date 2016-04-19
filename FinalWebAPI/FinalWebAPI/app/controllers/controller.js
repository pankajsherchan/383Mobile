'use strict';
eventsApp.controller('movieController',
function movieController($scope, $routeParams, $http) {

    $scope.waitMessage = "Please wait while we load a list of our movies.....";
    $scope.hour = "pm";
    $scope.data = [
   { id: 1, title: 'Get Hard', desc: 'Will Ferrell and Kevin Hart headline this Warner Bros. comedy about a wrongfully convicted investment banker who prepares for prison life with the help of the man who washes his car. Etan Cohen directs, with Ian Roberts and Jay Martel handling screenwriting duties.', category_name: 'Category 1', time: [{ timeid: 1, times: 10, seats: 100 }, { timeid: 2, times: 12, seats: 100 }, { timeid: 3, times: 2, seats: 100 }] },
   { id: 2, title: 'Neighbors 2', desc: 'Young parents Mac (Seth Rogen and Kelly Radnor (Rose Byrne) find their troubles are far from over in this sequel co-starring Zac Efron.', category_name: 'Category 2', time: [{ timeid: 1, times: 8, seats: 100 }, { timeid: 2, times: 11, seats: 100 }, { timeid: 3, times: 5, seats: 100 }] },
   { id: 3, title: 'Ride Along 2', desc: 'Friction continues between rookie cop Ben Barber (Kevin Hart) and his seasoned partner (and future brother-in-law) James Payton (Ice Cube) in this sequel to the hit action comedy Ride Along. After discovering a mysterious flash drive during an arrest, the pair travel to Miami to hunt down a local drug lord with the help of a savvy detective (Olivia Munn). Directed by Tim Story.', category_name: 'Category 1', time: [{ timeid: 1, times: 9, seats: 100 }, { timeid: 2, times: 12, seats: 100 }, { timeid: 3, times: 3, seats: 100 }] },
   { id: 4, title: 'Star Wars: The Force Awakens', desc: 'In this thrilling continuation of the epic space opera, ex-stormtrooper Finn (John Boyega), scrappy desert dweller Rey (Daisy Ridley), and droid companion BB-8 get caught up in a galactic war when they come across a map containing the whereabouts of the vanished Luke Skywalker (Mark Hamill). ', category_name: 'Category 2', time: [{ timeid: 1, times: 10, seats: 34 }, { timeid: 2, times: 12, seats: 100 }, { timeid: 3, times: 3, seats: 20 }] },
   { id: 5, title: 'Captain America: Civil War', desc: 'Former Avengers teammates Iron Man (Robert Downey Jr.) and Captain America (Chris Evans) clash over a proposal that would make superheroes accountable to government oversight. Soon, the rest of the Marvel heroes take sides in the conflict. Directed by Anthony and Joe Russo.', category_name: 'Category 3', time: [{ timeid: 1, times: 12, seats: 10 }, { timeid: 2, times: 3, seats: 45 }, { timeid: 3, times: 6, seats: 100 }] }
    ];

    if ($routeParams.id != null) {
        $scope.movie = $scope.getProduct($routeParams.id);
    }

    $scope.getProduct = function (id) {
        for (var i = 0; i < this.data.length; i++) {
            if (this.data[i].id == id)
                return this.data[i];
        }
        return null;
    }

    $scope.setSelectedItem = function (i) {
        $scope.selectedItem = i;
    }

    $scope.deleteItem = function () {
        if ($scope.selectedItem >= 0) {
            $scope.data.splice($scope.selectedItem, 1);
        }
    }
});