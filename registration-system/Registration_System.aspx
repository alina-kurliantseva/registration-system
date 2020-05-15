<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration_System.aspx.cs" Inherits="Registration_System" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Alina Kurliantseva | Course Registration</title>
    <link href="App_Themes/Styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <asp:Panel ID="CourseRegistrationPanel" runat="server">
        <div class="profileForm">
            <form id="CourseRegistrationForm" runat="server">
                <div>
                    <h1>Algonquin College Course Registration</h1>
                    <div class="text-center">
                        <asp:Label ID="LabelStudentName" runat="server" Text="Student Name:"></asp:Label>
                    </div>
                    <div class="margin-auto">
                        <asp:TextBox ID="StudentName" runat="server" CssClass="input"></asp:TextBox>
                    </div>
                    <div class="margin-auto">
                        <asp:RadioButtonList ID="RadioButtonListStudentType" runat="server"></asp:RadioButtonList>
                    </div>
                    <p>Following courses are currently available for registration:</p>
                    <div class="margin-auto">
                        <asp:CheckBoxList ID="CheckBoxListCourses" runat="server"></asp:CheckBoxList>
                    </div>
                    <asp:Label id="ErrorMessage" Text="" runat="server" CssClass="error" />
                    <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" CssClass="button" />
                </div>
            </form>
        </div>
    </asp:Panel>

    <asp:Panel ID="CourseConfirmationPanel" runat="server">
        <div class="profileForm">
            <h1>Algonquin College Course Registration</h1>
            <div class="text-center">
                <asp:Label ID="ConfirmationMessage1" runat="server" Text=""></asp:Label>
            </div>
            <div class="text-center margin-auto">
                <asp:Label ID="ConfirmationMessage2" runat="server" Text=""></asp:Label>
            </div>
            <asp:Table ID="ConfirmationTable" runat="server" CssClass="custom-table">
                <asp:TableRow runat="server">
                    <asp:TableHeaderCell runat="server">Course Code</asp:TableHeaderCell>
                    <asp:TableHeaderCell runat="server">Course Title</asp:TableHeaderCell>
                    <asp:TableHeaderCell runat="server">Weekly Hours</asp:TableHeaderCell>
                    <asp:TableHeaderCell runat="server">Fee Payable</asp:TableHeaderCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </asp:Panel>
</body>
</html>
