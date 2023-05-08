$(document).ready(function () {

    
    $.ajax({
        url: "/Admin/ProductorDataRequest/GetAllWaitingMovies",
        type: "GET",
        success: function (data) {
            $.each(data, function (i, item) {
                
                var directorsHTML = "";
                $.each(item.directors, function (j, item) {
                    directorsHTML += "<li class='list-group-item'>" + item.name + "</li>";
                });

                // iç döngü (genres)
                var genresHTML = "";
                $.each(item.genres, function (j, item) {
                    genresHTML += "<li class='list-group-item'>" + item.name + "</li>";
                });

                // iç döngü (castMembers)
                var castMembersHTML = "";
                $.each(item.castMembers, function (j, item) {
                    castMembersHTML += "<li class='list-group-item'>" + item.name + "</li>";
                });

                // Accordion HTML
        
        var accordionHTML = `
<div class="set">
    <a>
        <h3>${item.title} (${new Date(item.releaseDate).getFullYear()}) <strong>${item.status == 0 ? "Onay Bekliyor" : ""}</strong><i class="fa fa-plus"></i></h3>
    </a>
    <div class="content">
        <div class="card">
            <div class="row no-gutters">
                <div class="col-md-4 p-3">
                    <img src="/images/Cinemagnesia/${item.posterPath}" class="card-img" alt="Movie Poster">
                </div>
                <div class="col-md-8 p-3">
                  <div class="row">
                        <div class="col-md-12 text-center">
                                <h1 class="card-title text-dark">${item.title} (${new Date(item.releaseDate).getFullYear()})</h1>

                        </div>
                  </div>
                 <div class="row mt-3">
                        <div class="col-md-12 p-5">
                <iframe class="mt-4" width="560" height="315" src="https://www.youtube.com/embed/${item.trailerUrl}" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>

                        </div>
                  </div>
                </div>
            </div>
                <div class="row">
                    <div class="col-lg-12">
                             <div class="card-body">
                                <ul class="list-group">
                                    <li class="list-group-item">Şirket : ${item.companyName}</li>
                                    <li class="list-group-item">Açıklama : ${item.description}</li>
                                    <li class="list-group-item">Başvuru Tarihi: ${item.createdAt}</li>
                                    <li class="list-group-item">Yayım Tarihi: ${item.releaseDate}</li>
                                    <li class="list-group-item">IMDb Puanı: ${item.imdbRating}</li>
                                    <li class="list-group-item">Durum: ${item.status == 0 ? "bekliyor..." : ""}</li>
                                    <li class="list-group-item">Yönetmenler: <ul class="list-group">${directorsHTML}</ul></li>
                                    <li class="list-group-item">Kategoriler: <ul class="list-group">${genresHTML}</ul></li>
                                    <li class="list-group-item">Oyuncular: <ul class="list-group">${castMembersHTML}</ul></li>
                                    <li class="list-group-item">Film Süresi: ${item.movieMinutes}</li>
                                    <li class="list-group-item">Dil: ${item.language}</li>
                                    <li class="list-group-item">Aksiyonlar: <button class='btn btn-warning comfirmMovieBtn' value='${item.id}'>Onayla</button>  <button class='btn btn-danger rejectMovieBtn' value='${item.id}'>Reddet</button></li>
                                </ul>
                            </div>
                    </div>
                </div>
        </div>
    </div>
</div>
`;

                // Accordion HTML'ini sayfaya ekleme
                $('.accordion-container').append(accordionHTML);

            });
            $(".set > a").on("click", function () {
                if ($(this).hasClass("active")) {
                    $(this).removeClass("active");
                    $(this)
                        .siblings(".content")
                        .slideUp(200);
                    $(".set > a i")
                        .removeClass("fa-minus")
                        .addClass("fa-plus");
                } else {
                    $(".set > a i")
                        .removeClass("fa-minus")
                        .addClass("fa-plus");
                    $(this)
                        .find("i")
                        .removeClass("fa-plus")
                        .addClass("fa-minus");
                    $(".set > a").removeClass("active");
                    $(this).addClass("active");
                    $(".content").slideUp(200);
                    $(this)
                        .siblings(".content")
                        .slideDown(200);
                }
            });
            $('.set > a').removeClass('active');
            $('.content').hide();
        },

        // yardımcı fonksiyonlar


        error: function (xhr, status, error) {
            console.log(error);
        }
    });
    // film onaylama başlangıç
    $(document).on("click", ".comfirmMovieBtn", function () {
        var id = $(this).val();
        console.log(id)
        var setDiv = $(this).closest(".set");
        Swal.fire({
            title: 'Emin misin?',
            text: "Bir Başvuruyu Kabul etmek üzeresin!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Evet, Kabul et!'
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: '/Admin/ProductorDataRequest/ComfirmMovie',
                    type: 'POST',
                    data: { id: id },
                    success: function (response) {
                        console.log(response)
                        setDiv.remove(); // set class'ına sahip div'i kaldırmak
                        Swal.fire(
                            'Başarılı!',
                            'Kabul Edildi!',
                            'success'
                        )
                    }
                });
            }
        })
        console.log(id);
    });
    // film onaylama bitiş

    // film reddetme başlangıç
    $(document).on("click", ".rejectMovieBtn", function () {
        var id = $(this).val();
        var setDiv = $(this).closest(".set");
        Swal.fire({
            title: 'Emin misin?',
            text: "Bir Başvuruyu reddetmek üzeresin!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Evet, reddet!'
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: '/Admin/ProductorDataRequest/RejectMovie',
                    type: 'POST',
                    data: { id: id },
                    success: function (response) {
                        console.log(response)
                        setDiv.remove(); // set class'ına sahip div'i kaldırmak
                        Swal.fire(
                            'Başarılı!',
                            'reddedildi!',
                            'success'
                        )
                    }
                });
            }
        })
        
        console.log(id);
    });
    // film reddetme bitiş
});