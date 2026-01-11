<%@ Page Language="C#" AutoEventWireup="true"
    MasterPageFile="~/Admin.Master"
    CodeBehind="GununYemegiAdmin.aspx.cs"
    Inherits="YemekTarifiSitesi4.GununYemegiAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="card-title">Günün Yemeği</div>
    <asp:Label ID="LblBilgi" runat="server"></asp:Label>
    <br />
    <b>Şu anki günün yemeği:</b>
    <asp:Label ID="LblGununYemegi" runat="server" Font-Bold="True"></asp:Label>
    <br /><br />

    <asp:Panel ID="Panel1" runat="server" CssClass="panel-header">
        <asp:Button ID="Button1" runat="server" Text="+" CssClass="mini-btn" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="-" CssClass="mini-btn" OnClick="Button2_Click" />
        <span class="panel-title">YEMEK LİSTESİ</span>
    </asp:Panel>

    <asp:Panel ID="Panel2" runat="server" CssClass="panel-body">
        <asp:DataList ID="DataList1" runat="server" Width="100%">
            <ItemTemplate>
                <div class="row-item">
                    <span class="row-text"><%# Eval("YemekAd") %></span>

                    <span class="row-actions">
                        <a class="icon-link"
                           href='GununYemegiAdmin.aspx?Yemekid=<%# Eval("Yemekid") %>&islem=sec'
                           onclick="return confirm('Günün yemeği olarak bunu seçmek istiyor musun?');">
                            <img src="ikonlar/click.png" alt="Seç" style="width:22px;height:22px;" />
                        </a>
                    </span>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </asp:Panel>

</asp:Content>
