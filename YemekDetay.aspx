<%@ Page Language="C#" AutoEventWireup="true"
    MasterPageFile="~/Kullanici.Master"
    CodeBehind="YemekDetay.aspx.cs"
    Inherits="YemekTarifiSitesi4.YemekDetay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="Label3" runat="server" style="font-weight: 700; font-size: xx-large; color: #FFFFFF;" Text="Label"></asp:Label>

    <asp:DataList ID="DataList2" runat="server">
        <ItemTemplate>
            <table style="width: 100%">
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" style="font-size: large; font-weight: 700" Text='<%# Eval("YorumAdSoyad") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="altCizgi">
                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("Yorumicerik") %>'></asp:Label>
                        &nbsp;-
                        <asp:Label ID="Label6" runat="server" style="font-size: xx-small" Text='<%# Eval("YorumTarih") %>'></asp:Label>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    <br />
    <div style="background-color: #999999">YORUM YAPMA PANELİ</div>
    <asp:Panel ID="Panel1" runat="server">
        <table style="width: 100%">
            <tr>
                <td style="width: 175px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 175px; text-align: right"><b>Ad Soyad:</b></td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Height="20px" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 175px; text-align: right"><b>Mail:</b></td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Height="20px" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 175px; text-align: right"><b>Yorumunuz:</b></td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Height="100px" TextMode="MultiLine" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 175px">&nbsp;</td>
                <td>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="font-size: medium; font-weight: 700" Text="Yorum Yap" Width="200px" />
                </td>
            </tr>
            <tr>
                <td style="width: 175px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </asp:Panel>

</asp:Content>



