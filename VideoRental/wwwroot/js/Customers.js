$(document).ready(function () {
    var table = $("#customers").DataTable
        ({
            ajax:
            {
                url: "/api/customers",
                dataSrc: ""
            },
            columns:
                [
                    {
                        data: "name",
                        render: function (data, type, customer) {
                            return "<a href='customer/edit/" + customer.id + "'>" + customer.name + " " + customer.lastName + "</a>";
                        }
                    },
                    {
                        data: "membershipTypes.name"
                    },
                    {
                        data: "id",
                        render: function (data) {
                            return "<button class='btn-link js-delete' data-customer-id=" + data + ">Delete</button>";
                        }
                    }
                ]
        });
    $("#customers").on("click", ".js-delete", function () {
        var button = $(this);
        bootbox.confirm("Are you sure you want to delete this customer?", function (result) {
            if (result) {
                $.ajax
                    ({
                        url: "api/customers/" + button.attr("data-customer-id"),
                        method: "DELETE",
                        success: function () {
                            table.row(button.parents("tr")).remove().draw();
                        }
                    });
            }
        });

    });
});
