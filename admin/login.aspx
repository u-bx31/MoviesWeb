<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/admin/Admin.Master" CodeBehind="login.aspx.cs" Inherits="TP1_Movies.admin.login" %>

<asp:Content ContentPlaceHolderID="AdminContent" runat="server" ID="login">
    <div class="container">
        <div class="forms">
            <div class="form-group">
                <label for="user">User Name</label>
                <asp:TextBox placeHolder="Enter User Name" CssClass="form-control" ID="txtUser1" runat="server" />
            </div>
            <div class="form-group">
                <label for="exampleInputPassword1">Password</label>
                <asp:TextBox TextMode="Password" placeHolder="Password" CssClass="form-control" ID="txtPass" runat="server" />
            </div>
            <div class="mb-3 form-check">
                <asp:CheckBox CssClass="form-check-input" BorderStyle="None" runat="server" ID="chkCookie" />
                <label class="form-check-label" for="exampleCheck1">Check me out</label>
            </div>
            <div class="btn_log">
                <asp:Button CssClass="btn_log" runat="server" OnClick="btn_Log_Click" Text="Log-in" />
            </div>
            <div class="box" id="div_box" runat="server" visible="false" >
                <asp:Label EnableViewState="true" runat="server" ID="txt_userError" /></br>
                <asp:Label EnableViewState="true" runat="server" ID="txt_passError" />
            </div>

        </div>

    </div>
</asp:Content>
