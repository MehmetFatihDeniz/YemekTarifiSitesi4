<%@ Page Language="C#" AutoEventWireup="true"
    MasterPageFile="~/Admin.Master"
    CodeBehind="Yorumlar.aspx.cs"
    Inherits="YemekTarifiSitesi4.Yorumlar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="card-title">Yorumlar</div>
    <asp:Label ID="LblBilgi" runat="server"></asp:Label>
    <br /><br />

    <!-- ONAYLI -->
    <asp:Panel ID="Panel1" runat="server" CssClass="panel-header">
        <asp:Button ID="Button1" runat="server" Text="+" CssClass="mini-btn" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="-" CssClass="mini-btn" OnClick="Button2_Click" />
        <span class="panel-title">ONAYLANAN YORUMLAR</span>
    </asp:Panel>

    <asp:Panel ID="Panel2" runat="server" CssClass="panel-body">
        <asp:DataList ID="DataList1" runat="server" Width="100%">
            <ItemTemplate>
                <div class="row-item">
                    <span class="row-text"><%# Eval("YorumAdSoyad") %></span>

                    <span class="row-actions">
                        <a class="icon-link"
                           href='Yorumlar.aspx?Yorumid=<%# Eval("Yorumid") %>&islem=sil'
                           onclick="return confirm('Bu yorumu silmek istiyor musun?');">
                            <img src="ikonlar/delete2.png" alt="Sil" />
                        </a>

                        <a class="icon-link"
                           href='YorumDetay.aspx?Yorumid=<%# Eval("Yorumid") %>'>
                            <img src="ikonlar/update.png" alt="Detay" />
                        </a>
                    </span>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </asp:Panel>

    <br />

    <!-- ONAYSIZ -->
    <asp:Panel ID="Panel3" runat="server" CssClass="panel-header">
        <asp:Button ID="Button3" runat="server" Text="+" CssClass="mini-btn" OnClick="Button3_Click1" />
        <asp:Button ID="Button4" runat="server" Text="-" CssClass="mini-btn" OnClick="Button4_Click" />
        <span class="panel-title">ONAYLANMAYAN YORUMLAR</span>
    </asp:Panel>

    <asp:Panel ID="Panel4" runat="server" CssClass="panel-body">
        <asp:DataList ID="DataList2" runat="server" Width="100%">
            <ItemTemplate>
                <div class="row-item">
                    <span class="row-text"><%# Eval("YorumAdSoyad") %></span>

                    <span class="row-actions">
                        <a class="icon-link"
                           href='Yorumlar.aspx?Yorumid=<%# Eval("Yorumid") %>&islem=sil'
                           onclick="return confirm('Bu yorumu silmek istiyor musun?');">
                            <img src="ikonlar/delete2.png" alt="Sil" />
                        </a>

                        <a class="icon-link"
                           href='YorumDetay.aspx?Yorumid=<%# Eval("Yorumid") %>'>
                            <img src="ikonlar/update.png" alt="Detay" />
                        </a>
                    </span>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </asp:Panel>

</asp:Content>
