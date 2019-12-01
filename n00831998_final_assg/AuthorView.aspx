<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AuthorView.aspx.cs" Inherits="n00831998_final_assg.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h4 class="text-center">Authors</h4>
    <!--Line Below will be updated if page is being reached after CRUD functions are made in other pages (Shown in url with GET methods)-->
    <div id="commandDiv" runat="server" class="alert alert-success w-25">
        <p id="commandConfirm" runat="server" class="mb-0"></p>
    </div>
    <div class="form-inline">
        <div class="form-group mb-4">
            <label for="search_value" class="col-sm-2 col-form-lable">Search:</label>
            <asp:TextBox ID="search_value" name="search_value" runat="server" CssClass="form-control-plaintext border-dark" />

            <asp:RequiredFieldValidator runat="server" EnableClientScript="true" ErrorMessage="Required Field" ControlToValidate="search_value" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:Button Text="Search" runat="server" CssClass="btn btn-primary ml-2" />
            <button onclick="location.href='AddAuthor.aspx'" type="button" class="btn btn-primary mt-2 ml-5">Add New Author</button>
        </div>
    </div>
    <div id="pages_result" class="_table" runat="server">
    </div>
</asp:Content>
