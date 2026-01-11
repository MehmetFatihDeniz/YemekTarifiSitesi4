<%@ Page Title="Günün Yemeği" Language="C#" MasterPageFile="~/Kullanici.Master"
    AutoEventWireup="true" CodeBehind="GununYemegi.aspx.cs"
    Inherits="YemekTarifiSitesi4.GununYemegi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:DataList ID="DataList2" runat="server" style="margin-right: 140px" Width="445px">
        <ItemTemplate>
            <table class="auto-style1" style="height: 314px; width: 103%">
                <tr>
                    <td style="text-align: center">
                        <asp:Label ID="Label8" runat="server" style="font-weight: 700; font-size: x-large" Text='<%# Eval("YemekAd") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong>Malzemeler:</strong>
                        <asp:Label ID="Label9" runat="server" Text='<%# Eval("YemekMalzeme") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <strong>Tarif:</strong>
                        <asp:Label ID="Label10" runat="server" Text='<%# Eval("YemekTarif") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <asp:Image ID="Image2" runat="server" Height="141px" ImageUrl='<%# Eval("YemekResim") %>' Width="259px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong>Puan:</strong>
                        <asp:Label ID="Label11" runat="server" Text='<%# Eval("YemekPuan") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 25px">
                        <strong>Eklenme Tarihi:</strong>
                        <asp:Label ID="Label12" runat="server" Text='<%# Eval("YemekTarih") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 25px">&nbsp;</td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>

</asp:Content>
