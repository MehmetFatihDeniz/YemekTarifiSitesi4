<%@ Page Title="İletişim" Language="C#"
    MasterPageFile="~/Kullanici.Master"
    AutoEventWireup="true"
    CodeBehind="iletisim.aspx.cs"
    Inherits="YemekTarifiSitesi4.iletisim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <table style="width: 100%">
    <tr>
        <td colspan="2" style="font-size: x-large"><strong><em style="text-align: center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Bizimle iletişime geçin</em></strong></td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right"><b>Ad Soyad:</b></td>
        <td>
            <asp:TextBox ID="TxtGonderen" runat="server" CssClass="tb5"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right"><b>Mail Adresi:</b></td>
        <td>
            <asp:TextBox ID="TxtMail" runat="server" CssClass="tb5"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right"><b>Konu:</b></td>
        <td>
            <asp:TextBox ID="TxtBaslık" runat="server" CssClass="tb5"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right"><b>Mesajınız:</b></td>
        <td>
            <asp:TextBox ID="TxtMesaj" runat="server" CssClass="tb5" Height="150px" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="height: 37px"></td>
        <td style="height: 37px">
            <asp:Button ID="Button1" runat="server" style="font-weight: 700; font-size: large" Text="GÖNDER" Width="150px" CssClass="btn" OnClick="Button1_Click" />
        </td>
    </tr>
    <tr>
        <td style="height: 37px">&nbsp;</td>
        <td style="height: 37px">
            &nbsp;</td>
    </tr>
</table>
    
</asp:Content>
