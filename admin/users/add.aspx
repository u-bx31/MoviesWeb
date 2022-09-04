<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/admin/Admin.Master" CodeBehind="add.aspx.cs" Inherits="TP1_Movies.admin.users.add" %>

<asp:Content ContentPlaceHolderID="AdminContent" runat="server">
    <div class="main_info">
        <div class="v_summary1">
            <asp:ValidationSummary ValidationGroup="info_User" CssClass="v_summary" runat="server" ID="sumryV" />
        </div>
        <div class="info">
            <asp:Label Text="UserName :" CssClass="lbl_hedrs" runat="server" /><br>
            <asp:TextBox ID="txt_user" runat="server" CssClass="txt_inputs" />
            <asp:RequiredFieldValidator ValidationGroup="info_User" Display="None" ID="RequiredFieldValidator" ErrorMessage="UserName Cant Be Empty" runat="server" ControlToValidate="txt_user"></asp:RequiredFieldValidator>
        </div>
        <div class="info">
            <asp:Label Text="Password" runat="server" CssClass="lbl_hedrs" /><br>
            <asp:TextBox CssClass="txt_inputs" ID="txt_pass" runat="server" />
            <asp:RequiredFieldValidator ValidationGroup="info_User" Display="None" ID="RequiredFieldValidator1" ErrorMessage="Desciption Cant Be Empty" runat="server" ControlToValidate="txt_pass"></asp:RequiredFieldValidator>
        </div>
        <div class="info">
            <asp:Label Text="State" runat="server" CssClass="lbl_hedrs" /><br>
            <asp:CheckBox  CssClass="chek" ID="check_activ" runat="server" Checked="false" />
        </div>
        <div class="button_">
            <asp:Button runat="server" ValidationGroup="info_User" ID="btnSave" CssClass="btn_" Text="Save" OnClick="btnSave_Click" />
            <asp:Button runat="server" ID="btnCancel" CssClass="btn_" Text="Cancel" OnClick="btnCancel_Click" OnClientClick="if (!confirm('Are you sure you want delete?')) return false;" />
        </div>
    </div>


</asp:Content>