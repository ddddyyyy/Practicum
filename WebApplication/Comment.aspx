<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Comment.aspx.cs" Inherits="WebApplication.Comment" MasterPageFile="~/Site.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="Main">
            <asp:ValidationSummary ShowModelStateErrors="true" runat="server" />
            <asp:TextBox ID="TextBox123" runat="server" Height="289px" TextMode="MultiLine" Width="854px"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="提交" OnClick="Submit" />
            <asp:Button ID="Button2" runat="server" Text="取消" OnClick="Cancel" />
</asp:Content>

