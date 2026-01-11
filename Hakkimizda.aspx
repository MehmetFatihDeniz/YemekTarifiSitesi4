<%@ Page Title="Hakkımızda" Language="C#"
    MasterPageFile="~/Kullanici.Master"
    AutoEventWireup="true"
    CodeBehind="Hakkimizda.aspx.cs"
    Inherits="YemekTarifiSitesi4.Hakkimizda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
    <asp:Image ID="Image2" runat="server" Height="200px" ImageUrl="~/resimler/yemekhakkimizda.png" Width="450px" />
    <br /><br />
    <asp:DataList ID="DataList2" runat="server" Width="445px" Height="125px" OnSelectedIndexChanged="DataList2_SelectedIndexChanged">
        <ItemTemplate>
            <asp:Label ID="Label3" runat="server" Text='<%# Eval("Metin") %>'></asp:Label>
        </ItemTemplate>
    </asp:DataList>
    <div></div>
    </asp:Content>

