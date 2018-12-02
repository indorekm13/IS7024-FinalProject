<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="houses.aspx.cs" Inherits="WcfService2.Houses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css" />
    <title>Houses - Game Of Thrones</title>
    <!-- Styling Sheets for different screens-->
    <link rel="stylesheet" href="desktop.css" type="text/css" />
    <link rel="stylesheet" href="print.css" type="text/css" media="print" />
    <link rel="stylesheet" href="mobile.css" type="text/css" media="screen and (max-device-width: 480px)" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script>
        $(function () {
            $("#TxtHouseName").autocomplete({
                source: "HouseNamesAutoComplete.aspx"
            });
            $("#TxtRegion").autocomplete({
                source: "RegionAutoComplete.aspx"
            });
            $("#TxtCoatOfArms").autocomplete({
                source: "CoatofArmsAutoComplete.aspx"
            });
        });
    </script>
</head>
<body>
    <!--Side Navigation Code-->
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

        <!-- Filters to search for specific Houses (Royal Families) -->
        <div class="filter noprint">
            <form id="form1" runat="server">
                <div>
                    <label for="TxtHouseName">Search By House Name</label>
                    <asp:TextBox ID="TxtHouseName" runat="server"></asp:TextBox>

                    <label for="TxtRegion">Search By Region</label>
                    <asp:TextBox ID="TxtRegion" runat="server"></asp:TextBox>

                    <label for="TxtCoatOfArms">Search By Coat Of Arms</label>
                    <asp:TextBox ID="TxtCoatOfArms" runat="server"></asp:TextBox>

                    <label for="TxtWords">Search By Words</label>
                    <asp:TextBox ID="TxtWords" runat="server"></asp:TextBox>

                    <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" OnClick="ButtonSubmitClick" />
                </div>
            </form>
        </div>
        <div>
            <!-- Table to Display Details of Houses -->
            <table>
                <caption class="textcolor">Details of Houses (Royal Families)</caption>
                <tr>
                    <th class="textcolor">Name</th>
                    <th class="textcolor">Region</th>
                    <th class="textcolor">Coat Of Arms</th>
                    <th class="textcolor">Words</th>
                    <th class="textcolor">Seats</th>
                </tr>
                <%=GetTableData()%>
            </table>
        </div>
        <!-- Javascript for Side Navigation -->
        <script src="scripting.js" type="text/javascript"></script>
    </div>
</body>
</html>
