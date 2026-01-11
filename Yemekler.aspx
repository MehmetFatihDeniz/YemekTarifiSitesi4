<%@ Page Language="C#" AutoEventWireup="true"
    MasterPageFile="~/Admin.Master"
    CodeBehind="Yemekler.aspx.cs"
    Inherits="YemekTarifiSitesi4.Yemekler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="card-title">Yemekler</div>

    <asp:Label ID="LblBilgi" runat="server"></asp:Label>
    <br /><br />

    <!-- YEMEK LİSTESİ -->
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
                           href='Yemekler.aspx?Yemekid=<%# Eval("Yemekid") %>&islem=sil'
                           onclick="return confirm('Bu yemeği silmek istiyor musun?');">
                            <img src="ikonlar/delete2.png" alt="Sil" />
                        </a>

                        <a class="icon-link"
                           href='YemekDuzenle.aspx?Yemekid=<%# Eval("Yemekid") %>'>
                            <img src="ikonlar/update.png" alt="Güncelle" />
                        </a>
                    </span>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </asp:Panel>

    <br />

    <!-- YEMEK EKLEME -->
    <asp:Panel ID="Panel3" runat="server" CssClass="panel-header">
        <asp:Button ID="Button3" runat="server" Text="+" CssClass="mini-btn" OnClick="Button3_Click1" />
        <asp:Button ID="Button4" runat="server" Text="-" CssClass="mini-btn" OnClick="Button4_Click" />
        <span class="panel-title">YEMEK EKLEME</span>
    </asp:Panel>

    <asp:Panel ID="Panel4" runat="server" CssClass="panel-body">

        <div class="form-row">
            <label class="form-label">YEMEK ADI:</label>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="tb5" Width="300px"></asp:TextBox>
        </div>

        <div class="form-row">
            <label class="form-label">MALZEMELER:</label>
            <asp:TextBox ID="TextBox2" runat="server" CssClass="tb5" Height="90px"
                TextMode="MultiLine" Width="300px"></asp:TextBox>
        </div>

        <div class="form-row">
            <label class="form-label">YEMEK TARİFİ:</label>
            <asp:TextBox ID="TextBox3" runat="server" CssClass="tb5" Height="140px"
                TextMode="MultiLine" Width="300px"></asp:TextBox>
        </div>

        <div class="form-row">
            <label class="form-label">KATEGORİ:</label>
            <asp:DropDownList ID="DropDownList1" runat="server" Width="301px"></asp:DropDownList>
        </div>

        <div class="form-row">
            <span class="form-label"></span>
            <asp:Button ID="BtnEkle" runat="server" CssClass="btn" Text="Ekle" OnClick="BtnEkle_Click" />
        </div>

    </asp:Panel>

</asp:Content>
