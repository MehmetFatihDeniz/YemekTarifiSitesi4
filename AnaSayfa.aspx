<%@ Page Title="Ana Sayfa" Language="C#" MasterPageFile="~/Kullanici.Master" AutoEventWireup="true"
    CodeBehind="AnaSayfa.aspx.cs" Inherits="YemekTarifiSitesi4._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- WOW: ARAMA -->
    <div style="margin-bottom:10px;">
        <asp:TextBox ID="TxtAra" runat="server" Width="260px" placeholder="Yemek ara..."></asp:TextBox>
        <asp:Button ID="BtnAra" runat="server" Text="Ara" OnClick="BtnAra_Click" />
        <asp:Button ID="BtnTemizle" runat="server" Text="Temizle" OnClick="BtnTemizle_Click" />
    </div>

    <asp:Label ID="LabelBilgi" runat="server"></asp:Label>
    <br />

    <!-- LİSTE: SENİN DATALIST2 -->
    <asp:DataList ID="DataList2" runat="server" Width="449px">
        <ItemTemplate>
            <table style="width: 100%">
                <tr>
                    <td style="background-color: #FFFF99">
                        <a href="YemekDetay.aspx?Yemekid=<%# Eval("Yemekid") %>">
                            <asp:Label ID="Label3" runat="server"
                                Text='<%# Eval("YemekAd") %>'
                                style="font-weight:700; font-size:x-large; color:#FF0066;"></asp:Label>
                        </a>
                    </td>
                </tr>

                <tr>
                    <td style="height: 23px">
                        <strong>Malzemeler:</strong>
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("YemekMalzeme") %>'></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>
                        <strong>Yemek Tarifi:</strong>
                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("YemekTarif") %>'></asp:Label>
                        &nbsp;
                        <a href="YemekDetay.aspx?Yemekid=<%# Eval("Yemekid") %>">Devamı</a>
                    </td>
                </tr>

                <tr>
                    <td>
                        <strong>Eklenme Tarihi:</strong>
                        <asp:Label ID="Label6" runat="server" style="color:#FFFFFF"
                            Text='<%# Eval("YemekTarih", "{0:dd.MM.yyyy}") %>'></asp:Label>
                        &nbsp;- <strong><em>Puan:
                            <asp:Label ID="Label7" runat="server" style="color:#FFFFFF"
                                Text='<%# Eval("YemekPuan") %>'></asp:Label>
                        </em></strong>
                    </td>
                </tr>

                <tr>
                    <td class="altCizgi">&nbsp;</td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>

    <!-- WOW: SAYFALAMA -->
    <div style="margin-top:10px; text-align:center;">
        <asp:LinkButton ID="LnkPrev" runat="server" OnClick="LnkPrev_Click">◀ Önceki</asp:LinkButton>
        &nbsp;&nbsp;
        <asp:Label ID="LblSayfa" runat="server" style="font-weight:700;"></asp:Label>
        &nbsp;&nbsp;
        <asp:LinkButton ID="LnkNext" runat="server" OnClick="LnkNext_Click">Sonraki ▶</asp:LinkButton>
    </div>

</asp:Content>
