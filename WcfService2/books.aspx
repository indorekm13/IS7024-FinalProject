<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="books.aspx.cs" Inherits="WcfService2.Books" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta content="text/html; charset=iso-8859-2" http-equiv="Content-Type" />
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css" />
    <title>Books - Game Of Thrones</title>
    <!-- Styling Sheets for different screens-->
    <link rel="stylesheet" href="desktop.css" type="text/css" />
    <link rel="stylesheet" href="print.css" type="text/css" media="print" />
    <link rel="stylesheet" href="mobile.css" type="text/css" media="screen and (max-device-width: 480px)" />
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script>
        $(function () {
            $("#TxtBookName").autocomplete({
                source: "BookNameAutoComplete.aspx"
            });
            $("#TxtPublisher").autocomplete({
                source: "PublisherAutoComplete.aspx"
            });
            $("#TxtIsbn").autocomplete({
                source: "ISBNAutoComplete.aspx"
            });
        });
    </script>
</head>
<body>
    <!--Cover Images Carousel-->
    <div id="mySidenav" class="sidenav noprint">
        <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">&times;</a>
        <a href="/index.html">Home</a>
        <a href="/books.aspx">Search Books</a>
        <a href="/houses.aspx">Search Houses</a>
        <a href="/FormDataPage.aspx">Create a JSON</a>
        <a href="/aboutus.html">About Us</a>
    </div>
    <div id="main">
        <div>
            <span id="menuIcon" class="noprint" onclick="openNav()">&#9776;</span>
            <h1 class="textcolor">A Song of Ice and Fire</h1>
        </div>
        <!-- Search Filters -->
        <div class="filter noprint">
            <form id="form1" runat="server">
                <div>
                    <div class=" form-row">
                        <label for="bookname">Search By Book Name</label>
                        <asp:TextBox ID="TxtBookName" runat="server"></asp:TextBox>
                    </div>
                    <div class=" form-row">
                        <label for="TxtPublisher">Search By Publisher</label>
                        <asp:TextBox ID="TxtPublisher" runat="server"></asp:TextBox>
                    </div>
                    <div class=" form-row">
                        <label for="TxtIsbn">Search By ISBN</label>
                        <asp:TextBox ID="TxtIsbn" runat="server"></asp:TextBox>
                    </div>
                    <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" OnClick="ButtonSubmitClick" />
                </div>
            </form>
        </div>
        <!-- Table to display List of Books -->
        <div>
            <table>
                <caption class="textcolor">Details of Books</caption>
                <tr>
                    <th class="textcolor">Name</th>
                    <th class="textcolor">ISBN</th>
                    <th class="textcolor">Author</th>
                    <th class="textcolor">Number Of Pages</th>
                    <th class="textcolor">Publisher</th>
                    <th class="textcolor">Country</th>
                    <th class="textcolor">Media Type</th>
                    <th class="textcolor">Release Date</th>
                </tr>
                <%=GetTableData()%>
            </table>
        </div>
        <!--Scripting for Carousel and side Navigation-->
        <script src="scripting.js" type="text/javascript"></script>
    </div>
</body>
</html>
