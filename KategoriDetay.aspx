<%@ Page Language="C#" MasterPageFile="~/Kullanici.Master" AutoEventWireup="true" CodeBehind="KategoriDetay.aspx.cs" Inherits="YemekTarifiSitesi4.KategoriDetay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:DataList ID="DataList2" runat="server" Width="449px">
    <ItemTemplate>
        <table style="width: 100%">
            <tr>
                <td style="background-color: #FFFF99"><a href="YemekDetay.aspx?Yemekid=<%#Eval("Yemekid") %>">
                    <asp:Label ID="Label3" runat="server"
                           Text='<%# Eval("YemekAd") %>' style="font-weight: 700; font-size: x-large; color: #FF0066;"></asp:Label>
                    </a></td>
            </tr>
            <tr>
                <td style="height: 23px"><strong>Malzemeler:</strong>
                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("YemekMalzeme") %>'></asp:Label>
                </td>
            </tr>
            <tr>
                <td><strong>Yemek Tarifi:</strong>
                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("YemekTarif") %>'></asp:Label>
                </td>
            </tr>
            <tr>
                <td><strong>Eklenme Tarihi:</strong>
                    <asp:Label ID="Label6" runat="server" style="color: #FFFFFF" Text='<%# Eval("YemekTarih") %>'></asp:Label>
                        &nbsp;- <strong><em>Puan:
                        <asp:Label ID="Label7" runat="server" style="color: #FFFFFF" Text='<%# Eval("YemekPuan") %>'></asp:Label>
                    </em></strong></td>
            </tr>
            <tr>
                <td class="altCizgi">&nbsp;</td>
            </tr>
        </table>
    </ItemTemplate>
</asp:DataList>

</asp:Content>

