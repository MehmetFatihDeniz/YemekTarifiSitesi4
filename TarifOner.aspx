<%@ Page Title="Tarif Öner" Language="C#"
    MasterPageFile="~/Kullanici.Master"
    AutoEventWireup="true"
    CodeBehind="TarifOner.aspx.cs"
    Inherits="YemekTarifiSitesi4.TarifOner" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="LblBilgi" runat="server"></asp:Label>
    <br /><br />

    <table class="auto-style1">
        <tr>
            <td style="width: 121px; text-align: right"><b>Tarif Adı:</b></td>
            <td><asp:TextBox ID="TxtTarifAd" runat="server" Width="250px"></asp:TextBox></td>
        </tr>

        <tr>
            <td style="width: 121px; text-align: right"><b>Malzemeler:</b></td>
            <td><asp:TextBox ID="TxtMalzemeler" runat="server" Height="80px" TextMode="MultiLine" Width="250px"></asp:TextBox></td>
        </tr>

        <tr>
            <td style="width: 121px; text-align: right"><b>Yapılış:</b></td>
            <td><asp:TextBox ID="TxtYapilis" runat="server" Height="150px" TextMode="MultiLine" Width="250px"></asp:TextBox></td>
        </tr>

        <tr>
            <td style="width: 121px; text-align: right"><b>Resim:</b></td>
            <td><asp:FileUpload ID="FileUpload1" runat="server" Width="250px" /></td>
        </tr>

        <tr>
            <td style="width: 121px; text-align: right"><b>Tarif Öneren:</b></td>
            <td><asp:TextBox ID="TxtTarifOneren" runat="server" Width="250px"></asp:TextBox></td>
        </tr>

        <tr>
            <td style="width: 121px; text-align: right"><b>Mail Adresi:</b></td>
            <td><asp:TextBox ID="TxtMailAdresi" runat="server" Width="250px"></asp:TextBox></td>
        </tr>

        <tr>
            <td></td>
            <td>
                <asp:Button ID="BtnTarifOner" runat="server"
                    CssClass="btn"
                    BackColor="#009999"
                    Style="font-weight:700; font-size:medium; font-style:italic; margin-left:44px"
                    Text="Tarifi Öner" Width="169px"
                    OnClick="BtnTarifOner_Click" />
            </td>
        </tr>
    </table>

</asp:Content>
