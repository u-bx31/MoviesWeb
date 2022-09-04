<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/admin/Admin.Master" CodeBehind="list.aspx.cs" Inherits="TP1_Movies.admin.users.list" %>

<asp:Content ContentPlaceHolderID="AdminContent" runat="server">
<div class="main_info">
        <div class="btn_add">
            <asp:Button ID="add_btn" Text="Add" runat="server" OnClick="add_btn_Click" CssClass="add_bt" />
        </div>
        <div class="gdv_data">
            <asp:GridView CssClass="gdv_item" runat="server" HeaderStyle-BackColor="#808080" FooterStyle-BackColor="#808080" DataKeyNames="ID" ID="grid_User_view" AutoGenerateColumns="False" OnRowCancelingEdit="grid_User_view_RowCancelingEdit" OnRowDeleted="grid_User_view_RowDeleted" OnRowDeleting="grid_User_view_RowDeleting" OnRowEditing="grid_User_view_RowEditing" OnRowUpdating="grid_User_view_RowUpdating" AllowPaging="True" OnPageIndexChanging="grid_User_view_PageIndexChanging" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                <Columns>

                    <asp:BoundField DataField="Username" HeaderText="User Name" />
                    <asp:BoundField DataField="Password" HeaderText="Password" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HyperLink runat="server" Text="Full_edit" NavigateUrl='<%# "/admin/users/add.aspx?id=" +Eval("ID")%>' ImageUrl="~/Icons/settings.png" ImageHeight="40px" ImageWidth="40px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="true" ButtonType="Image" CancelImageUrl="~/Icons/cross.png" EditImageUrl="~/Icons/edit.png" UpdateImageUrl="~/Icons/check.png" >
                    <ControlStyle Height="40px" Width="40px" />
                    </asp:CommandField>
                    <asp:CommandField ShowDeleteButton="true" ButtonType="Image" DeleteImageUrl="~/Icons/trash.png" AccessibleHeaderText="DeleteBtn" >
                    <ControlStyle Height="40px" Width="40px" />
                    </asp:CommandField>
                </Columns>

                <FooterStyle BackColor="#CCCC99" ForeColor="Black"></FooterStyle>

                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White"></HeaderStyle>
                <PagerStyle BackColor="#333333" ForeColor="white" Font-Size="19px" HorizontalAlign="center"  />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>
