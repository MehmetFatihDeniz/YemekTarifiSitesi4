<%@ Page Language="C#" AutoEventWireup="true"
    MasterPageFile="~/Admin.Master"
    CodeBehind="Tarifler.aspx.cs"
    Inherits="YemekTarifiSitesi4.Tarifler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="card-title">Tarif Önerileri</div>
    <asp:Label ID="LblBilgi" runat="server"></asp:Label>
    <br /><br />

    <!-- ONAYLANMAMIŞ -->
    <asp:Panel ID="Panel1" runat="server" CssClass="panel-header">
        <asp:Button ID="Button1" runat="server" Text="+" CssClass="mini-btn" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="-" CssClass="mini-btn" OnClick="Button2_Click" />
        <span class="panel-title">ONAYLANMAMIŞ TARİFLER</span>
    </asp:Panel>

    <asp:Panel ID="Panel2" runat="server" CssClass="panel-body">
        <asp:DataList ID="DataList1" runat="server" Width="100%">
            <ItemTemplate>
                <div class="row-item">
                    <span class="row-text"><%# Eval("TarifAd") %></span>

                    <span class="row-actions">
                        <a class="icon-link" href='TarifOnerDetay.aspx?Tarifid=<%# Eval("Tarifid") %>'>
                            <img src="ikonlar/Ticket-Star--Streamline-Plump.png" alt="Detay" style="width:20px;height:20px;" />
                        </a>
                    </span>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </asp:Panel>

    <br />

    <!-- ONAYLANMIŞ -->
    <asp:Panel ID="Panel3" runat="server" CssClass="panel-header">
        <asp:Button ID="Button3" runat="server" Text="+" CssClass="mini-btn" OnClick="Button3_Click" />
        <asp:Button ID="Button4" runat="server" Text="-" CssClass="mini-btn" OnClick="Button4_Click" />
        <span class="panel-title">ONAYLANMIŞ TARİFLER</span>
    </asp:Panel>

    <asp:Panel ID="Panel4" runat="server" CssClass="panel-body">
        <asp:DataList ID="DataList2" runat="server" Width="100%">
            <ItemTemplate>
                <div class="row-item">
                    <span class="row-text"><%# Eval("TarifAd") %></span>

                    <span class="row-actions">
                        <a class="icon-link" href='TarifOnerDetay.aspx?Tarifid=<%# Eval("Tarifid") %>'>
                            <img src="ikonlar/Ticket-Star--Streamline-Plump.png" alt="Detay" style="width:20px;height:20px;" />
                        </a>
                    </span>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </asp:Panel>

</asp:Content>
