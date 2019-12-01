<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PageDetail.aspx.cs" Inherits="n00831998_final_assg.IndividualPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <span id="error" runat="server"></span>
    <div id="commandDiv" runat="server" class="alert alert-success w-25">
        <p id="commandConfirm" runat="server" class="mb-0"></p>
    </div>

    <div class="card text-white bg-light mb-3" style="max-width: 50%;" id="page_content" runat="server">
        <h4 class="card-header text-dark">Details for <span id="page_title" runat="server"></span></h4>
        <div class="card-body">
            <table class="table table-condensed">
                <tbody>
                    <tr>
                        <td>Page Title:</td>
                        <td><span id="page_name" runat="server"></span></td>
                    </tr>
                    <tr>
                        <td>Author:</td>
                        <td><span id="author" runat="server"></span></td>
                    </tr>
                    <tr>
                        <td>Page Body:</td>
                        <td><span id="page_body" runat="server"></span></td>
                    </tr>
                    <tr>
                        <td>Publish Date:</td>
                        <td><span id="publish_date" runat="server"></span></td>
                    </tr>
                </tbody>
            </table>
            <div class="btn-group">
                <asp:Button runat="server" Text="Update Entry" ID="updateButton" OnClick="UpdateButton_Click" CssClass="btn btn-warning" />
                <asp:Button runat="server" Text="Delete Entry" ID="deleteButton" OnClick="DeleteButton_Click" OnClientClick="return confirm('Are you sure you would like to delete this entry?');" CssClass="btn btn-danger" />
                <button type="button" onclick="location.href='PageView.aspx'" class="btn btn-primary">Go back</button>
            </div>

        </div>
        
    </div>

</asp:Content>
