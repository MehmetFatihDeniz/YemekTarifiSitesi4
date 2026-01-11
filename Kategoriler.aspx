<%@ Page Language="C#" AutoEventWireup="true"
    MasterPageFile="~/Admin.Master"
    CodeBehind="Kategoriler.aspx.cs"
    Inherits="YemekTarifiSitesi4.Kategoriler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="card-title">Kategoriler</div>

    <asp:Label ID="LblBilgi" runat="server" ForeColor="Green"></asp:Label>
    <br /><br />

    <!-- KATEGORİ LİSTESİ -->
    <asp:Panel ID="Panel1" runat="server" CssClass="panel-header">
        <asp:Button ID="Button1" runat="server" Text="+" CssClass="mini-btn" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="-" CssClass="mini-btn" OnClick="Button2_Click" />
        <span class="panel-title">KATEGORİ LİSTESİ</span>
    </asp:Panel>

    <asp:Panel ID="Panel2" runat="server" CssClass="panel-body">
        <asp:DataList ID="DataList1" runat="server" Width="100%">
            <ItemTemplate>
                <div class="row-item">
                    <span class="row-text"><%# Eval("KategoriAd") %></span>

                    <span class="row-actions">
                        <a class="icon-link"
                           href='Kategoriler.aspx?Kategoriid=<%# Eval("Kategoriid") %>&islem=sil'
                           onclick="return confirm('Bu kategoriyi silmek istiyor musun?');">
                            <img src="ikonlar/delete2.png" alt="Sil" />
                        </a>

                        <a class="icon-link"
                           href='KategoriDuzenle.aspx?Kategoriid=<%# Eval("Kategoriid") %>'>
                            <img src="ikonlar/update.png" alt="Güncelle" />
                        </a>
                    </span>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </asp:Panel>

    <br />

    <!-- KATEGORİ EKLEME -->
    <asp:Panel ID="Panel3" runat="server" CssClass="panel-header">
        <asp:Button ID="Button3" runat="server" Text="+" CssClass="mini-btn" OnClick="Button3_Click" />
        <asp:Button ID="Button4" runat="server" Text="-" CssClass="mini-btn" OnClick="Button4_Click" />
        <span class="panel-title">KATEGORİ EKLEME</span>
    </asp:Panel>

    <asp:Panel ID="Panel4" runat="server" CssClass="panel-body">
        <div class="form-row">
            <label class="form-label">KATEGORİ AD:</label>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="tb5"></asp:TextBox>
        </div>

        <div class="form-row">
            <label class="form-label">KATEGORİ İKON:</label>
            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="tb5" />
        </div>

        <div class="form-row">
            <span class="form-label"></span>
            <asp:Button ID="BtnEkle" runat="server" CssClass="btn" Text="Ekle" OnClick="BtnEkle_Click" />
        </div>
    </asp:Panel>

</asp:Content>
