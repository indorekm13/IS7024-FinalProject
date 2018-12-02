<%@ Page Language="C#" Inherits="WcfService2.FormDataPage" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>FormDataPage</title>
         <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css" />
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
        <a href="/FormDataPage.aspx">Create a JSON</a>
    </div>
         <div id="main">
        <div>
            <span id="menuIcon" onclick="openNav()">&#9776;</span>
            <h1 class="textcolor">Creating a JSON from User Form</h1>
        </div>
	<form id="form1" runat="server">
            <div>
                <label for="firstName">First Name</label>
                    <asp:TextBox ID="firstName" runat="server" CssClass="textbox"></asp:TextBox>
                       <br/> 
                    <label for="lastName"> Last Name</label>
                    <asp:TextBox ID="lastName" runat="server" CssClass="textbox"></asp:TextBox>
            </div>
            <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" OnClick="ButtonSubmit_Click" />
            <br/>
            <asp:TextBox ID="DisplayData" TextMode="multiline" width="330px" Height="50px" wrap="true" runat="server"></asp:TextBox>
	</form>
            <script src="scripting.js" type="text/javascript"></script>
            </div>
         
        
</body>
</html>
