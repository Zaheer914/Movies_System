<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="Movies_System.AdminPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Admin</title>
  <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.1/dist/css/bootstrap.min.css" />
  <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
  <link rel="stylesheet" href="https://pro.fontawesome.com/releases/v5.10.0/css/all.css" integrity="sha384-AYmEC3Yw5cVb3ZcuHtOA93w35dYTsvhLPVnYs9eStHfGJvOvKxVfELGroGkvsg+p" crossorigin="anonymous" />
  <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.22/css/jquery.dataTables.min.css" />
  <style>
      label{
          color:red;
          margin:0px 8px 0px 3px;
      }
  </style>
  <script type="text/javascript" src="https://cdn.datatables.net/1.10.22/js/jquery.dataTables.min.js"></script>
  <script>
    const getCode = (e) => {
      e = e || window.event;

      return e.key;
    };
    function isNumberKey(e) {
      const keycode = getCode(e);
      if ((isFinite(keycode))) {
        return true;
      }
      alert('Please Enter a Number');
      return false;
    }


    function AddMovies() {
      var genres = [];
      $(':checkbox:checked').each(function (i) {
        genres[i] = $(this).val();
      });
        
        var moviePrice = document.getElementById("moviePrice").value;
        var movieName = document.getElementById("movieName").value;
        if (movieName =="" || moviePrice == "" || genres == "") {
            alert("Field are Required");
            return false;
        }
        else {
            
            $.ajax({
                url: 'AdminPage.aspx/AddMovies',
                type: "Post",
                data: JSON.stringify({ "movieName": movieName, "moviePrice": moviePrice, "genres": genres }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    $('#moviePrice').val("");
                    $('#InvalidMovie').empty();
                    $(":input[type=checkbox]").prop('checked', false);;
                    $('#InvalidMovie').append([data.d]);
                    $('#moviesData').DataTable().destroy();
                    DisplayMovies();
                }
            });
      }
    }

    $(document).ready(function () {
        DisplayMovies();
    });

      function DisplayMovies() {
          $.ajax({
              url: 'AdminPage.aspx/GetMovies',
              method: 'post',
              dataType: 'json',
              contentType: 'application/json',
              async: false,
              success: function (data) {
                  $('#moviesData').dataTable({
                      data: JSON.parse(data.d),
                      columns: [
                          { 'data': 'Movies.MovieName'},
                          { 'data': 'Movies.MoviePrice' },
                          { 'data': 'Genres' },
                          {
                              'data': 'Movies.MovieId',
                              'render': function (data) {
                                  //Edit or Delete Button
                                  return '<button type="button" class="btn btn-secondary" id="deletemovies" onclick="deletemovies(' + data + ');return false"><i <i class="fas fa-trash"></i></button>'
                              },
                          }
                      ]
                  });
              }
          });
      }

      //Delete Customer Ajax Function
      function deletemovies(data) {
          $.ajax({
              url: 'AdminPage.aspx/DeleteMovies',
              type: "POST",
              data: JSON.stringify({ "data": data }),
              contentType: "application/json; charset=utf-8",
              dataType: "json",
              success: function (data) {
                  alert("Successfully Deleted");
                  $('#moviesData').DataTable().destroy();
                  DisplayMovies();
              }
          });
      }
  </script>
</head>
<body>
  <form id="movies" runat="server">
    <div class="container py-3 h-100">
      <h1>Add Movies</h1>
      <div class="form-outline mb-4">
        <asp:Label runat="server" class="form-label" for="movieName" Text="Movie Name"></asp:Label>
        <asp:TextBox runat="server" ID="movieName" class="form-control form-control-lg " ></asp:TextBox>
      </div>

      <div class="form-outline mb-4">
        <asp:Label runat="server" class="form-label" for="moviePrice" Text="Price"></asp:Label>
        <asp:TextBox runat="server" ID="moviePrice" class="form-control form-control-lg" onkeypress="return isNumberKey(event)"> </asp:TextBox>

      </div>
      <div class="form-outline mb-4">
        <div>
          <asp:CheckBoxList runat="server" ID="genres" DataTextField="Name" DataValueField="GenresId" RepeatColumns="7"  RepeatDirection="Vertical" RepeatLayout="Flow" />
        </div>
      </div>
      <div class="pt-1 mb-4">
        <asp:Label runat="server" class="form-label" for="movieName" Id="InvalidMovie"></asp:Label>
        <asp:Button runat="server" class="btn btn-success btn-lg btn-block" ID="save_value" Text="Add Movies" OnClientClick="AddMovies();return false;" />
      </div>
    </div>
  </form>

    <div class="container py-3 h-100">
        <div clss="table-responsive table-responsive-sm table-responsive-md table-responsive-lg table-responsive-xl">
            <h1>Movies Details</h1>
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
