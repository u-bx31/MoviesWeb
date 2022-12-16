<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/site/Site.Master" CodeBehind="index.aspx.cs" Inherits="TP1_Movies.index" %>


<asp:Content ID="indexContent" runat="server" ContentPlaceHolderID="SiteContent">
    <header class="header"><asp:HyperLink Text="Weclome to MovieLand"  ForeColor="White"  runat="server" NavigateUrl="~/site/index.aspx"/></header>
    <div class="conatiner">
        <div class="filtr">
            <div class="item ">
                <h3>KeyWord</h3>
                <asp:TextBox CssClass="txtBx" ID="keyword" runat="server" ValidationGroup="v_1"  />
            </div>
            <div class="item ">
                <h3>Year From</h3>
                <asp:DropDownList ID="drpYearFrom" CssClass="dropdown" runat="server">
                    <asp:ListItem />
                </asp:DropDownList>
            </div>
            <div class="item ">
                <h3>Year To</h3>
                <asp:DropDownList ID="drpYearTo" CssClass="dropdown" runat="server">
                    <asp:ListItem />
                </asp:DropDownList>
            </div>
            <div class="item ">
                <h3>Rating From</h3>
                <asp:TextBox CssClass="txtBx" ID="ratingFrom" runat="server" ValidationGroup="v_1" />
                <asp:RangeValidator runat="server" Type="Double" ControlToValidate="ratingFrom" ValidationGroup="v_1" MaximumValue="10" MinimumValue="0" Display="Dynamic" ErrorMessage="Rating(0 - 10)" ForeColor="Red" />
            </div>
            <div class="item ">
                <h3>Rating To</h3>
                <asp:TextBox CssClass="txtBx" ID="ratingTO" runat="server" ValidationGroup="v_1" />
                <asp:RangeValidator runat="server" Type="Double" ControlToValidate="ratingTO" ValidationGroup="v_1" SetFocusOnError="false" MaximumValue="10" MinimumValue="0" Display="Dynamic" ErrorMessage="Rating(0 - 10)" ForeColor="Red" />
            </div>
            <div class="itemBtn ">
                <asp:Button CssClass="btn Search" runat="server" Text="Search" ValidationGroup="v_1" OnClick="btnSearsh_Click" />
            </div>
            <div class="itemBtn">
                <asp:Button CssClass="btn Clear" runat="server" Text="Clear" OnClick="btnClear_Click"/>
            </div>

        </div>
        <div class="movies">
            <div class="nav">
                <div class="div_paging">
                    <div class="paging_rpt">
                        <asp:LinkButton ID="lnk_prev" runat="server" CssClass="lnk_pg" Text="Prev" OnClick="lnk_prev_Click" />
                        <asp:Repeater ID="rpt_pg" runat="server" OnItemDataBound="rpt_pg_ItemDataBound" >
                            <ItemTemplate>
                                <asp:LinkButton runat="server" CssClass="lnk_pg" ID="link_paging" OnCommand="link_paging_Click" />
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:LinkButton ID="lnk_next" runat="server" CssClass="lnk_pg" Text="Next" OnClick="lnk_next_Click" />
                    </div>
                </div>
                <div class="sorting">
                    <div class="headr">
                        <h4>Sort By :</h4>
                    </div>
                    <div class="drp">
                        <asp:DropDownList Class="items" ID="drpSort" runat="server" Width="99px" AutoPostBack="True" OnSelectedIndexChanged="drpSort_SelectedIndexChanged">
                            <asp:ListItem Text="Title" Value="Title" />
                            <asp:ListItem Text="Year" Value="ReleaseDate" />
                            <asp:ListItem Text="Rating Asc" Value="Rating" />
                            <asp:ListItem Text="Rating Dsc" Value="Rating DESC" />
                        </asp:DropDownList>
                    </div>
                </div>
            </div>

            <div class="movies-col">
                <asp:ScriptManager ID="scrp_" runat="server" ></asp:ScriptManager>
                <asp:UpdatePanel UpdateMode="Conditional" runat="server" ID="updt_"  >
                    <ContentTemplate>
                        <asp:Repeater runat="server" ID="rpt_mov" OnItemDataBound="rpt_mov_ItemDataBound">
                            <ItemTemplate>
                                <div class="box">
                                    <asp:HyperLink CssClass="link_m" runat="server" NavigateUrl='<%# "/site/details.aspx?id="+Eval("ID")%>'>
                                <div class="picture">
                                    <img class="images" src="../images/<%# Eval("Image") %>" />
                                </div>
                                <asp:Panel CssClass="rating" runat="server" id="movi_rt"><i class="rate" runat="server" id="rt_"><%# Eval("Rating") %></i></asp:Panel>
                                <div class="info_movie">
                                    <h3><%# Eval("Title") %></h3>
                                    <span class="date"><%# DateTime.Parse(Eval("ReleaseDate").ToString()).ToString("MMM dd ,yyyy") %></span>
                                </div>
                                    </asp:HyperLink>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="drpSort" />
                    </Triggers>
                </asp:UpdatePanel>


            </div>
        </div>

    </div>

</asp:Content>

