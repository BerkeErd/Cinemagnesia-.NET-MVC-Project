$(document).ready(function () {
   
    $.ajax({
        url: 'Movie/GetHomeMovies',
        type: 'GET',
        success: function (response) {
            // film listesi
            var movies = response;
            var movieIndex = 0;
            // yeni row oluşturma
            var row = $("<div>").addClass("row mb-4");
            // container 'a row u ekleme
            $(".movie-container").append(row);
            for (var i = 0; i < movies.length; i++) {
                var movie = movies[i];
                // colonn ve card ekleme
                var col = $("<div>").addClass("col-lg-3 col-sm-6");
                var card = $("<div>").addClass("movie-card");
                // img oluşturma
                var img = $("<img>").attr("src", `/images/Cinemagnesia/${movie.posterPath}`).attr("alt", movie.title + " Poster");
                var movieInfo = $("<div>").addClass("movie-info");
                // baslık
                var title = $("<h2>").text(movie.title);
                // imdb puanı
                var rating = $("<p>").addClass("rating").text("IMDb Rating: " + movie.imdbRating);
                // kategoriler listesi
                var genres = $("<ul>").addClass("genres");
                for (var j = 0; j < movie.genres.length; j++) {
                    var genre = $("<li>").text(movie.genres[j].name);
                    genres.append(genre);
                }
                // date yalnızca year alma
                var date = movie.releaseDate;
                var year = date.substr(0, 4);
                var description = $("<p>").addClass("description").text(movie.language + ' - ' + year);
                var button = $("<a>").addClass("button").attr("href", `Movie/MoviePage/id?id=${movie.id}`).text("Watch Trailer");
                movieInfo.append(title, rating, genres, description, button);
                card.append(img, movieInfo);
                col.append(card);
                row.append(col);
                movieIndex++;
                if (movieIndex % 4 === 0) {
                    row = $("<div>").addClass("row mb-4");
                    $(".movie-container").append(row);
                }
            }
        }
    });

})