<%@ Page Language="C#" AutoEventWireup="true"
    MasterPageFile="~/Admin.Master"
    CodeBehind="KategoriDuzenle.aspx.cs"
    Inherits="YemekTarifiSitesi4.KategoriAdminDetay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <table class="auto-style1" style="background-color: #5e9fee">
        <tr>
            <td style="width: 168px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 168px; text-align: right; font-weight: 700">KATEGORİ ADI:</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="tb5"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 168px; text-align: right; font-weight: 700">ADET:</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" CssClass="tb5"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 168px; text-align: right; font-weight: 700">RESİM:</td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="tb5" />
            </td>
        </tr>
        <tr>
            <td style="width: 168px">&nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Güncelle" />
            </td>
        </tr>
    </table>


</asp:Content>

