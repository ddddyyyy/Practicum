﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="WebApplication.UserList" MasterPageFile="~/Site.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="Main" ID="Test">
        <asp:ValidationSummary ShowModelStateErrors="true" runat="server"  />
        <asp:GridView ID="GridView1" AutoGenerateColumns="false" runat="server" BackColor="White"
            BorderColor="#DEDFDE" BorderStyle="None" 
            BorderWidth="1px" CellPadding="4" 
            ForeColor="Black" GridLines="Vertical" 
            AutoGenerateEditButton="true" UpdateMethod="Update"  SelectMethod="GridView1_GetData"
            ItemType="WebApplication.Model.User" DataKeyNames="Id"
            AutoGenerateDeleteButton="True" DeleteMethod="Delete">
            <Columns>
                <asp:HyperLinkField Text="评价" DataNavigateUrlFormatString="~/Comment.aspx?Id={0}"
                 DataNavigateUrlFields="Id" />
                <asp:HyperLinkField Text="查看评价" DataNavigateUrlFormatString="~/CommentList.aspx?Id={0}"
                 DataNavigateUrlFields="Id" />
                <asp:DynamicField DataField="Id"/>
                <asp:DynamicField DataField="Name" />
                <asp:DynamicField DataField="Sex" />
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label runat="server" Text="日期"></asp:Label>
                    </HeaderTemplate>
                    <EditItemTemplate>
                        <asp:Calendar runat="server" SelectedDate='<%# Bind("Birthday") %>' ID="date"></asp:Calendar>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="label" Text='<%# Bind("Birthday","{0:yyyy年MM月dd日}") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:DynamicField DataField="Tel" />
                <asp:DynamicField DataField="Role" />
                <asp:DynamicField DataField="Adress" />
                <asp:DynamicField DataField="Unit" />
            </Columns>

            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False"
            Text="添加" OnClick="New"></asp:LinkButton>
</asp:Content>
