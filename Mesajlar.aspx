<%@ Page Language="C#" AutoEventWireup="true"
    MasterPageFile="~/Admin.Master"
    CodeBehind="Mesajlar.aspx.cs"
    Inherits="YemekTarifiSitesi4.Mesajlar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="card-title">Mesajlar</div>
    <asp:Label ID="LblBilgi" runat="server"></asp:Label>
    <br /><br />

    <asp:Panel ID="Panel1" runat="server" CssClass="panel-header">
        <asp:Button ID="Button1" runat="server" Text="+" CssClass="mini-btn" OnClick="Button1_Click1" />
        <asp:Button ID="Button2" runat="server" Text="-" CssClass="mini-btn" OnClick="Button2_Click" />
        <span class="panel-title">MESAJLAR LİSTESİ</span>
    </asp:Panel>

    <asp:Panel ID="Panel2" runat="server" CssClass="panel-body">
        <asp:DataList ID="DataList1" runat="server" Width="100%">
            <ItemTemplate>
                <div class="row-item">
                    <span class="row-text">
                        <%# Eval("MesajGonderen") %>
                        <span style="font-weight:400; opacity:.75;"> - <%# Eval("MesajBaslik") %></span>
                    </span>

                    <span class="row-actions">
                        <a class="icon-link" href='MesajDetay.aspx?Mesajid=<%# Eval("Mesajid") %>'>
                            <img src="ikonlar/read2.jpg" alt="Oku" style="width:22px;height:16px;" />
                        </a>
                    </span>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </asp:Panel>

</asp:Content>
