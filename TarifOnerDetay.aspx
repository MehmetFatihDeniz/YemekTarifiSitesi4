<%@ Page Language="C#" AutoEventWireup="true"
    MasterPageFile="~/Admin.Master"
    CodeBehind="TarifOnerDetay.aspx.cs"
    Inherits="YemekTarifiSitesi4.TarifOnerDetay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="card-title">Tarif Öneri Detay</div>
    <asp:Label ID="LblBilgi" runat="server"></asp:Label>
    <br /><br />

    <table style="width: 100%; background-color: #5e9fee">
        <tr>
            <td style="width: 175px; text-align:right; font-weight:700;">Tarif Adı:</td>
            <td><asp:TextBox ID="TextBox1" runat="server" Width="260px" CssClass="tb5"></asp:TextBox></td>
        </tr>

        <tr>
            <td style="width: 175px; text-align:right; font-weight:700;">Tarif Malzemeleri:</td>
            <td><asp:TextBox ID="TextBox2" runat="server" Width="260px" CssClass="tb5"></asp:TextBox></td>
        </tr>

        <tr>
            <td style="width: 175px; text-align:right; font-weight:700;">Yapılış:</td>
            <td><asp:TextBox ID="TextBox3" runat="server" Height="120px" TextMode="MultiLine" Width="260px" CssClass="tb5"></asp:TextBox></td>
        </tr>

        <tr>
            <td style="width: 175px; text-align:right; font-weight:700;">Tarif Resmi:</td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="tb5" />
                <br />
                <asp:Label ID="LblResim" runat="server" Font-Size="Small"></asp:Label>
            </td>
        </tr>

        <tr>
            <td style="width: 175px; text-align:right; font-weight:700;">Tarifi Öneren:</td>
            <td><asp:TextBox ID="TextBox4" runat="server" Width="260px" CssClass="tb5" ReadOnly="True"></asp:TextBox></td>
        </tr>

        <tr>
            <td style="width: 175px; text-align:right; font-weight:700;">Tarif Öneren Mail:</td>
            <td><asp:TextBox ID="TextBox5" runat="server" Width="260px" CssClass="tb5" ReadOnly="True"></asp:TextBox></td>
        </tr>

        <tr>
            <td style="width: 175px; text-align:right; font-weight:700;">Kategori:</td>
            <td><asp:DropDownList ID="DropDownList1" runat="server" CssClass="tb5" Width="270px"></asp:DropDownList></td>
        </tr>

        <tr>
            <td></td>
            <td>
                <asp:Button ID="BtnOnayla" runat="server" CssClass="btn"
                    Text="Onayla ve Yemeğe Ekle" Width="270px" OnClick="BtnOnayla_Click" />

                <br /><br />

                <asp:Button ID="BtnSil" runat="server" CssClass="btn"
                    Text="Tarifi Sil" Width="270px"
                    BackColor="#cc0000" ForeColor="White"
                    OnClientClick="return confirm('Bu tarifi silmek istediğine emin misin?');"
                    OnClick="BtnSil_Click" />
            </td>
        </tr>
    </table>

</asp:Content>
