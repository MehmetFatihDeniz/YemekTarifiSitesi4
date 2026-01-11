<%@ Page Language="C#" AutoEventWireup="true"
    MasterPageFile="~/Admin.Master"
    CodeBehind="MesajDetay.aspx.cs"
    Inherits="YemekTarifiSitesi4.MesajDetay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="card-title">Mesaj Detay</div>
    <asp:Label ID="LblBilgi" runat="server"></asp:Label>
    <br /><br />

    <table class="auto-style1" style="background-color: #5e9fee">
        <tr>
            <td style="width: 160px; text-align: right"><b>Mesaj Gönderen:</b></td>
            <td><asp:TextBox ID="TextBox1" runat="server" CssClass="tb5" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 160px; text-align: right"><b>Başlık:</b></td>
            <td><asp:TextBox ID="TextBox2" runat="server" CssClass="tb5" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 160px; text-align: right"><b>Mail Adresi:</b></td>
            <td><asp:TextBox ID="TextBox3" runat="server" CssClass="tb5" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 160px; text-align: right"><b>Mesaj İçeriği:</b></td>
            <td><asp:TextBox ID="TextBox4" runat="server" CssClass="tb5" Height="200px" TextMode="MultiLine" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 160px"></td>
            <td>
                <asp:Button ID="BtnSil" runat="server" CssClass="btn"
                    Text="Sil" Width="160px"
                    BackColor="#cc0000" ForeColor="White"
                    OnClientClick="return confirm('Bu mesajı silmek istediğine emin misin?');"
                    OnClick="BtnSil_Click" />
            </td>
        </tr>
    </table>

</asp:Content>
