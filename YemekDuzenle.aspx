<%@ Page Language="C#" AutoEventWireup="true"
    MasterPageFile="~/Admin.Master"
    CodeBehind="YemekDuzenle.aspx.cs"
    Inherits="YemekTarifiSitesi4.YemekDuzenle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="card-title">Yemek Düzenle</div>
    <asp:Label ID="LblBilgi" runat="server"></asp:Label>
    <br /><br />

    <table class="auto-style1" style="height: 473px; background-color: #5e9fee">
        <tr>
            <td style="width: 126px; font-weight: 700; text-align: right">Yemek Adı:</td>
            <td><asp:TextBox ID="TextBox1" runat="server" CssClass="tb5"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 126px; font-weight: 700; text-align: right">Malzemeler:</td>
            <td><asp:TextBox ID="TextBox2" runat="server" CssClass="tb5" Height="100px" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 126px; font-weight: 700; text-align: right">Tarif:</td>
            <td><asp:TextBox ID="TextBox3" runat="server" CssClass="tb5" Height="200px" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 126px; font-weight: 700; text-align: right">Kategori:</td>
            <td><asp:DropDownList ID="DropDownList1" runat="server" CssClass="tb5" Width="216px"></asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 126px; font-weight: 700; text-align: right">Yemek Resmi:</td>
            <td><asp:FileUpload ID="FileUpload1" runat="server" CssClass="tb5" /></td>
        </tr>
        <tr>
            <td style="width: 126px"></td>
            <td>
                <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Güncelle" Width="237px" />
            </td>
        </tr>
        <tr>
            <td style="width: 126px"></td>
            <td>
                <asp:Button ID="Button2" runat="server" CssClass="btn"
                    OnClick="Button2_Click"
                    Text="Günün Yemeği Olarak Ayarla" Width="237px"
                    style="background-color:#FF3300;font-weight:700;" />
            </td>
        </tr>
    </table>

</asp:Content>
