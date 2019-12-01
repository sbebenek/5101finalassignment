<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateAuthor.aspx.cs" Inherits="n00831998_final_assg.UpdateAuthor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card text-dark bg-light mb-3" style="max-width: 75%;"  runat="server">
        <h4 class="card-header text-dark">Update Author: <span runat="server" id="author_full" ></span></h4>
        <div class="card-body">
            <div class="form" id="update_author" runat="server">
                <div class="form-group row">
                    <label for="first_name" class="col-sm-3 col-form-label">First Name:</label>
                    <div class="col-sm-5">
                        <asp:TextBox runat="server" ID="first_name" name="first_name"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" EnableClientScript="true" ErrorMessage="Required Field" ControlToValidate="first_name" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="last_name" class="col-sm-3 col-form-label">Last Name:</label>
                    <div class="col-sm-5">     
                        <asp:TextBox runat="server" ID="last_name" name="last_name"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" EnableClientScript="true" ErrorMessage="Required Field" ControlToValidate="last_name" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <asp:Button runat="server" Text="Go Back" id ="back" OnClick="BackButton_Click" cssClass="btn btn-primary"/>
                <asp:Button runat="server" Text="Update" ID="update_button" OnClick="UpdateButton_Click" cssClass="btn btn-warning"/>
            </div>
        </div>
    </div>
</asp:Content>
