<%@ Page Language="C#" AutoEventWireup="true"
    MasterPageFile="~/Admin.Master"
    CodeBehind="YorumDetay.aspx.cs"
    Inherits="YemekTarifiSitesi4.YorumDetay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="card-title">Yorum Detay</div>

    <asp:Label ID="LblBilgi" runat="server"></asp:Label>
    <br />

    <asp:Label ID="LblDurum" runat="server" Font-Bold="True"></asp:Label>
    <br /><br />

    <table class="auto-style1" style="background-color: #5e9fee">
        <tr>
            <td style="width: 132px; text-align: right"><b>Ad-Soyad:</b></td>
            <td><asp:TextBox ID="TxtAdSoyad" runat="server" CssClass="tb5"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 132px; text-align: right"><b>Mail Adresi:</b></td>
            <td><asp:TextBox ID="TxtMail" runat="server" CssClass="tb5" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 132px; text-align: right"><b>İçerik:</b></td>
            <td><asp:TextBox ID="Txticerik" runat="server" CssClass="tb5" Height="100px" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 132px; text-align: right"><b>Yemek:</b></td>
            <td><asp:TextBox ID="TxtYemek" runat="server" CssClass="tb5" ReadOnly="True"></asp:TextBox></td>
        </tr>

        <tr>
            <td style="width: 132px"></td>
            <td>
                <asp:Button ID="BtnOnay" runat="server" CssClass="btn"
                    Text="Onayla" Width="120px" OnClick="BtnOnay_Click" />

                &nbsp;

                <asp:Button ID="BtnSil" runat="server" CssClass="btn"
                    Text="Sil" Width="120px"
                    BackColor="#cc0000" ForeColor="White"
                    OnClientClick="return confirm('Bu yorumu silmek istediğine emin misin?');"
                    OnClick="BtnSil_Click" />
            </td>
        </tr>

        <tr>
            <td style="width: 132px"></td>
            <td style="font-size: small; text-align: right">
                <strong>Tarih: <asp:Label ID="LblTarih" runat="server"></asp:Label></strong>
            </td>
        </tr>
    </table>

</asp:Content>
