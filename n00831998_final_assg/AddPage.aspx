<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddPage.aspx.cs" Inherits="n00831998_final_assg.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="newPagesForm" runat="server">
        <div class="card text-dark bg-light mb-3" style="max-width: 75%;" runat="server">
            <h4 class="card-header text-dark">Add New Page <span runat="server" id="classTitle"></span></h4>
            <div class="card-body">
                <div class="form" runat="server">
                    <div class="form-group row">
                        <label for="pageTitle" class="col-sm-3 col-form-label">Page Title:</label>
                        <div class="col-sm-5">
                            <asp:TextBox runat="server" ID="pageTitle" name="pageTitle"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" EnableClientScript="true" ErrorMessage="Required Field" ControlToValidate="pageTitle" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>


                    <div runat="server" class="form-group row" id="drop_down">
                        <label for="author" class="col-sm-3 col-form-label">Author:</label>
                        <div class="col-sm-5">
                            <asp:DropDownList ID="author"
                                runat="server">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" EnableClientScript="true" ErrorMessage="Required Field" ControlToValidate="author" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            <p><small>Don't see the right author here? </small>
                                <asp:button runat="server" type="button" class="btn btn-link" OnClick="ShowNewAuthor_Click" Text="Add New Author &raquo;" CausesValidation="false"></asp:button></p>
                        </div>
                    </div>
                    <div runat="server" class="form-group row" id="new_author">
                        <div class="form-group row">
                            <label for="firstName" class="col-sm-3 col-form-label">Author First Name:</label>
                            <div class="col-sm-5">
                                <asp:TextBox runat="server" ID="firstName" name="firstName"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" EnableClientScript="true" ErrorMessage="Required Field" ControlToValidate="firstName" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label for="lastName" class="col-sm-3 col-form-label">Author Last Name:</label>
                            <div class="col-sm-5">
                                <asp:TextBox runat="server" ID="lastName" name="lastName"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" EnableClientScript="true" ErrorMessage="Required Field" ControlToValidate="lastName" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <asp:button runat="server" type="button" class="btn btn-link"  OnClick="CancelNewAuthor_Click" Text="Cancel &raquo;" CausesValidation="false"></asp:button>
                    </div>



                    <div class="form-group row">
                        <label for="pageBody" class="col-sm-3 col-form-label">Page Body:</label>
                        <div class="col-sm-5">
                            <asp:TextBox runat="server" ID="pageBody" name="pageBody" TextMode="MultiLine" Rows="10" Columns="30"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" EnableClientScript="true" ErrorMessage="Required Field" ControlToValidate="pageBody" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <button type="button" onclick="location.href='PageView.aspx'" class="btn btn-primary">Go Back</button>
                    <asp:Button runat="server" Text="Add New Entry" ID="addbutton" OnClick="AddButton_Click" CssClass="btn btn-warning" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
