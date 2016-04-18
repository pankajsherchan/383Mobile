function movie() {
    this.movies = [];
    {
        //(movieID, movie name, room playing in, seats left, time)
            new Movie(1, "Get Hard", "room1", 100, 10),
            new Movie(2, "Star Wars", "room2", 100, 06)


    }
}
store.prototype.getMovie = function (MovieId) {
    for (var i = 0; i < this.Movies.length; i++) {
        if (this.Movies[i].MovieId == MovieId)
            return this.Movies[i];
    }
    return null;
}