<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="books.aspx.cs" Inherits="WcfService2.books" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta content="text/html; charset=iso-8859-2" http-equiv="Content-Type" />
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css" />
    <title>Books - Game Of Thrones</title>
    <link rel="stylesheet" href="desktop.css" type="text/css" />
    <link rel="stylesheet" href="print.css" type="text/css" media="print" />
    <link rel="stylesheet" href="mobile.css" type="text/css" media="screen and (max-device-width: 480px)" />
</head>
<body>
    <div id="mySidenav" class="sidenav">
        <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">&times;</a>
        <a href="/index.html">Home</a>
        <a href="/books.aspx">Search Book</a>
        <a href="/houses.aspx">Search Houses</a>
    </div>
    <div id="main">
        <div>
            <span id="menuIcon" onclick="openNav()">&#9776;</span>
            <h1 class="textcolor">A Song of Ice and Fire</h1>
        </div>
        <div class="filter">
            <form id="form1" runat="server">
                <div>
                    <label for="bookname">Search By Book Name</label>
                    <asp:TextBox ID="TxtBookName" runat="server"></asp:TextBox>
                   

                    <label for="TxtPublisher">Search By Publisher</label>
                    <asp:TextBox ID="TxtPublisher" runat="server"></asp:TextBox>
                  

                    <label for="TxtIsbn">Search By ISBN</label>
                    <asp:TextBox ID="TxtIsbn" runat="server"></asp:TextBox>

                    <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" OnClick="ButtonSubmit_Click" />
                </div>
            </form>
        </div>

        <div>
            <table>
                <caption class="textcolor">Details of Book/s</caption>
                <tr>
                    <th class="textcolor">Name</th>
                    <th class="textcolor">ISBN</th>
                    <th class="textcolor">Author/s</th>
                    <th class="textcolor">Number Of Pages</th>
                    <th class="textcolor">Publisher</th>
                    <th class="textcolor">Country</th>
                    <th class="textcolor">Media Type</th>
                    <th class="textcolor">Release Date</th>
                </tr>
                <%=GetTableData()%>
            </table>
        </div>
        <script src="scripting.js" type="text/javascript"></script>
    </div>
</body>
</html>
