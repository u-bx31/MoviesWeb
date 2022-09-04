<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="details.aspx.cs" Inherits="TP1_Movies.details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Movie Detail</title>
    <link href="../styles/Details.css" rel="stylesheet" />
</head>
<body>
    <header class="hdr">
        <h4> Movie Details </h4>
    </header>
    <form id="form" runat="server">
        <div class="container">
            <div class="side_img">
                <asp:Image runat="server" CssClass="m_img" id="mv_img" />
            </div>
            <div class="mov_info">
                <div class="movi_info">
                    <div class="movi_tcd">
                        <h3 runat="server" class="Title" id="Title"></h3><br />
                        <table>
                            <tr>
                                <td class="lbls" >Duration :</td>
                                <td class="info" ><span runat="server" class="Duration mv" id="Duration"></span></td>
                            </tr>
                            <tr>
                                <td class="lbls" >Date : </td>
                                <td class="info"><span runat="server" class="date mv" id="date"></span></td>
                            </tr>
                            <tr>
                                <td class="lbls">Country : </td>
                                <td class="info"><span runat="server" class="Country mv" id="Country"></span></td>
                            </tr>
                        </table>
                    </div>
                    <div class="movi_rt">
                        <div class="ds_rt" runat="server" id="rt_form">

                        </div>
                    </div>
                </div>
                <div class="mov_desc">
                    <p runat="server" class="prg_" id="p_desc"></p>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
