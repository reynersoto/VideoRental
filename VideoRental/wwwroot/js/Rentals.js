$(document).ready(function () {

    var vm = {
        MovieIds: []
    };

    var customers = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('name'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        remote: {
            url: '/api/customers?query=%QUERY',
            wildcard: '%QUERY'
        }
    });

    $('#customer').typeahead({
        minLength: 3,
        highlight: true
    }, {
        name: 'customers',
        display: 'name',
        source: customers
    }).on("typeahead:select", function (e, customer) {
        vm.CustomerId = customer.id;
    });

    var movies = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('title'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        remote: {
            url: '/api/movies?query=%QUERY',
            wildcard: '%QUERY'
        }
    });

    $('#movie').typeahead({
        minLength: 3,
        highlight: true
    }, {
        name: 'movies',
        display: 'title',
        source: movies
    }).on("typeahead:select", function (e, movie) {
        $("#movieList").append("<li class='list-group-item'>" + movie.title + "</li>");

        $("#movie").typeahead("val", "");

        vm.MovieIds.push(movie.id);
    });

    $.validator.addMethod("validCustomer", function () {
        return vm.CustomerId && vm.CustomerId !== 0;
    }, "Please select a valid customer.");

    $.validator.addMethod("atLeastOneMovie", function () {
        return vm.MovieIds.length > 0;
    }, "Please select at least one movie.");

    var validator = $("#newRental").validate({
        submitHandler: function () {
            $.ajax({
                url: "/api/newRental",
                method: "post",
                data: JSON.stringify({
                    CustomerId: vm.CustomerId,
                    MovieIds: vm.MovieIds
                }),
                contentType: "application/json",

            })
                .done(function () {
                    toastr.success("Rentals successfully recorded.");

                    $("#customer").typeahead("val", "");
                    $("#movie").typeahead("val", "");
                    $("#movieList").empty(); // Limpia la lista de películas seleccionadas

                    vm = { MovieIds: [] };
                    // Reiniciar el objeto vm correctamente
                    vm.CustomerId = null;
                    vm.MovieIds = [];

                    validator.resetForm();
                })
                .fail(function () {
                    toastr.error("Something unexpected happened.");
                });

            return false;
        }
    });
});
