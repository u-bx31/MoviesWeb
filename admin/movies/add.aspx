<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/admin/Admin.Master" CodeBehind="add.aspx.cs" Inherits="TP1_Movies.admin.movies.add" %>

<asp:Content ContentPlaceHolderID="AdminContent" runat="server">
    <div class="main_info">
        <div class="v_summary1">
            <asp:ValidationSummary ValidationGroup="info_movie" CssClass="v_summary" runat="server" ID="sumryV" />
        </div>
        <div class="info">
            <asp:Label Text="Title :" CssClass="lbl_hedrs" runat="server" /><br>
            <asp:TextBox ID="Txt_Title" runat="server" CssClass="txt_inputs" />
            <asp:RequiredFieldValidator ValidationGroup="info_movie" Display="None" ID="RequiredFieldValidator" ErrorMessage="Title Cant Be Empty" runat="server" ControlToValidate="txt_Title"></asp:RequiredFieldValidator>
        </div>
        <div class="info">
            <asp:Label Text="Desciption" runat="server" CssClass="lbl_hedrs" /><br>
            <asp:TextBox TextMode="MultiLine" Height="200px" CssClass="txt_inputs" ID="Txt_Desciption" runat="server" />
            <asp:RequiredFieldValidator ValidationGroup="info_movie" Display="None" ID="RequiredFieldValidator1" ErrorMessage="Desciption Cant Be Empty" runat="server" ControlToValidate="Txt_Desciption"></asp:RequiredFieldValidator>
        </div>
        <div class="info">
            <asp:Label Text="Iamge :" runat="server" CssClass="lbl_hedrs" /><br>
            <asp:Image ID="image" runat="server" Height="200" Width="300" Visible="false" />
            <asp:FileUpload ID="fileUpload" runat="server" Width="40%" />
            <asp:Label ID="lbl_msg" runat="server" Visible="false"></asp:Label>
        </div>
        <div class="info">
            <asp:Label Text="Duration :" runat="server" CssClass="lbl_hedrs" /><br>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="Txt_Duration" Display="None" ErrorMessage="&quot;Duration&quot; accepet only numbers" MaximumValue="1000" MinimumValue="1" Type="Integer" ValidationGroup="info_movie"></asp:RangeValidator>
            <asp:TextBox ID="Txt_Duration" runat="server" CssClass="txt_inputs" />
            <asp:RequiredFieldValidator ValidationGroup="info_movie" Display="None" ID="RequiredFieldValidator3" ErrorMessage="Duration Cant Be Empty" runat="server" ControlToValidate="Txt_Duration"></asp:RequiredFieldValidator>
        </div>
        <div class="info">
            <asp:Label Text="Realse Date :" runat="server" CssClass="lbl_hedrs" /><br>
            <asp:TextBox TextMode="Date" ID="date_realseDate" runat="server" CssClass="txt_inputs" />
        </div>
        <div class="info">
            <asp:Label Text="Rating :" runat="server" CssClass="lbl_hedrs" /><br>
            <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="Txt_Rating" Display="None" ErrorMessage="&quot;Rating&quot; accept only numbers" MaximumValue="1000" MinimumValue="1" Type="Double" ValidationGroup="info_movie"></asp:RangeValidator>
            <asp:TextBox ID="Txt_Rating" runat="server" CssClass="txt_inputs" />
            <asp:RequiredFieldValidator ValidationGroup="info_movie" Display="None" ID="RequiredFieldValidator4" ErrorMessage="Rating Cant Be Empty" runat="server" ControlToValidate="txt_Rating"></asp:RequiredFieldValidator>
        </div>
        <div class="info">
            <asp:Label Text="Country :" runat="server" CssClass="lbl_hedrs" /><br>
            <asp:TextBox ID="Txt_Country" runat="server" CssClass="txt_inputs" />
            <asp:RequiredFieldValidator ValidationGroup="info_movie" ID="RequiredFieldValidator2" ErrorMessage="Country Cant Be Empty" runat="server" Display="None" ControlToValidate="Txt_Country"></asp:RequiredFieldValidator>

        </div>
        <div class="button_">
            <asp:Button runat="server" ValidationGroup="info_movie" ID="btnSave" CssClass="btn_" Text="Save" OnClick="btnSave_Click" />
            <asp:Button runat="server" ID="btnCancel" CssClass="btn_" Text="Cancel" OnClick="btnCancel_Click" OnClientClick="if (!confirm('Are you sure you want delete?')) return false;" />
        </div>
    </div>


</asp:Content>
