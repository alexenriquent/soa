<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Calculator.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        &nbsp;<asp:TextBox ID="FirstValueTextBox" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="OperatorDropDownList" runat="server">
            <asp:ListItem>+</asp:ListItem>
            <asp:ListItem>-</asp:ListItem>
            <asp:ListItem>*</asp:ListItem>
            <asp:ListItem>/</asp:ListItem>
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="SecondValueTextBox" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="CalculateButton" runat="server" Text="Calculate" OnClick="CalculateButton_Click" />
&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        Base-10:&nbsp;
        <asp:TextBox ID="DecimalTextBox" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;
        <br />
        <br />
        Base-2:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="BinaryTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        &nbsp;<asp:Button ID="CountButton" runat="server" Text="Count" OnClick="CountButton_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        Number of 0s:&nbsp; <asp:TextBox ID="ZeroCountTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        Number of 1s:&nbsp;
        <asp:TextBox ID="OneCountTextBox" runat="server"></asp:TextBox>
    
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>