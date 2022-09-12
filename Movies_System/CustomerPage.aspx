<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerPage.aspx.cs" Inherits="Movies_System.CustomerPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Page</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.1/dist/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <link rel="stylesheet" href="https://pro.fontawesome.com/releases/v5.10.0/css/all.css" integrity="sha384-AYmEC3Yw5cVb3ZcuHtOA93w35dYTsvhLPVnYs9eStHfGJvOvKxVfELGroGkvsg+p" crossorigin="anonymous" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.22/css/jquery.dataTables.min.css" />
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.22/js/jquery.dataTables.min.js"></script>

</head>
    <script>
        $(document).ready(function () {
            DisplayMovies();
        });

        function DisplayMovies() {
            $.ajax({
                url: 'CustomerPage.aspx/GetMovies',
                method: 'post',
                dataType: 'json',
                contentType: 'application/json',
                async: false,
                success: function (data) {
                    $('#moviesData').DataTable({
                        data: JSON.parse(data.d),
                        columns: [
                            { 'data': 'Movies.MovieName' },
                            { 'data': 'Movies.MoviePrice' },
                            { 'data': 'Genres' },
                            {
                                'data': 'Movies.MovieId',
                                'render': function (data) {
                                    //Edit or Delete Button
                                    return '<button type="button" class="btn btn-secondary" id="addtocart" onclick="addtocart(' + data + ');return false"><i class="fa fa-shopping-cart" aria-hidden="true"></i></button>'
                                },
                            }
                        ]
                    });
                }
            });
        }
    </script>
<body>
    <div class="container py-3 h-100">
        <div clss="table-responsive table-responsive-sm table-responsive-md table-responsive-lg table-responsive-xl">
            <h1>Movies</h1>
        </div>
        <%--tabledata--%>
        <div>
            <table id="moviesData" class="table table-active table-bordered table-hover">
                <thead class="thead-dark">
                    <tr>
                        <th>Movie Name</th>
                        <th>Movie Price</th>
                        <th>Genres</th>
                        <th>Actions</th>
                        
                    </tr>
                </thead>
            </table>
        </div>
    </div>
</body>
</html>
