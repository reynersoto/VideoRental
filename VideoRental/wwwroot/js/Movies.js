$(document).ready(function () {
    var table = $("#movies").DataTable
        ({
            ajax:
            {
                url: "/api/movies",
                dataSrc: ""
            },
            columns:
                [
                    {
                        data: "title",
                        render: function (data, type, movies) {
                            return "<a href='movie/edit/" + movies.id + "'>" + movies.title  + "</a>";
                        }
                    },
                    {
                        data: "genre.name"
                    },
                    {
                        data: "id",
                        render: function (data) {
                            return "<button class='btn-link js-delete' data-movie-id=" + data + ">Delete</button>";
                        }
                    }
                ]
        });
    $("#movies").on("click", ".js-delete", function () {
        var button = $(this);
        bootbox.confirm("Are you sure you want to delete this movie?", function (result) {
            if (result) {
                $.ajax
                    ({
                        url: "api/movies/" + button.attr("data-movie-id"),
                        method: "DELETE",
                        success: function () {
                            table.row(button.parents("tr")).remove().draw();
                        }
                    });
            }
        });

    });
});
