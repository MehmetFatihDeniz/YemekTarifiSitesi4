<%@ Page Language="C#" AutoEventWireup="true"
    MasterPageFile="~/Admin.Master"
    CodeBehind="HakkimizdaAdmin.aspx.cs"
    Inherits="YemekTarifiSitesi4.HakkimizdaAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="card-title">Hakkımızda</div>
    <asp:Label ID="LblBilgi" runat="server"></asp:Label>
    <br /><br />

    <asp:Panel ID="Panel1" runat="server" CssClass="panel-header">
        <asp:Button ID="Button1" runat="server" Text="+" CssClass="mini-btn" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="-" CssClass="mini-btn" OnClick="Button2_Click" />
        <span class="panel-title">HAKKIMIZDA METNİ</span>
    </asp:Panel>

    <asp:Panel ID="Panel2" runat="server" CssClass="panel-body">

        <asp:TextBox ID="TextBox1" runat="server" CssClass="tb5"
            Height="250px" TextMode="MultiLine" Width="100%"></asp:TextBox>

        <br /><br />

        <div style="text-align:center;">
            <asp:Button ID="Button3" runat="server" CssClass="btn"
                Text="Güncelle" Width="200px" OnClick="Button3_Click" />
        </div>

    </asp:Panel>

</asp:Content>
