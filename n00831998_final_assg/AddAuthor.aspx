<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddAuthor.aspx.cs" Inherits="n00831998_final_assg.AddAuthor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="newAuthorForm" runat="server">
        <div class="card text-dark bg-light mb-3" style="max-width: 75%;" runat="server">
            <h4 class="card-header text-dark">Add New Author<span runat="server" id="classTitle"></span></h4>
            <div class="card-body">
                <div class="form" runat="server">
                    <div class="form-group row">
                        <label for="firstName" class="col-sm-3 col-form-label">First Name:</label>
                        <div class="col-sm-5">
                            <asp:TextBox runat="server" ID="firstName" name="firstName"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" EnableClientScript="true" ErrorMessage="Required Field" ControlToValidate="firstName" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="lastName" class="col-sm-3 col-form-label">Last Name:</label>
                        <div class="col-sm-5">
                            <asp:TextBox runat="server" ID="lastName" name="lastName"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" EnableClientScript="true" ErrorMessage="Required Field" ControlToValidate="lastName" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    

                    <button type="button" onclick="location.href='AuthorView.aspx'" class="btn btn-primary">Go Back</button>
                    <asp:Button runat="server" Text="Add New Entry" ID="addbutton" OnClick="AddButton_Click" CssClass="btn btn-warning" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
