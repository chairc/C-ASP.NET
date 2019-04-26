<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListView.aspx.cs" Inherits="Lesson3.ListView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource1" InsertItemPosition="LastItem" DataKeyNames="ID">
            <AlternatingItemTemplate>
                <tr style="background-color: #FFFFFF;color: #284775;">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="删除" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="编辑" />
                    </td>
                   <%--<td>
                        <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                    </td>--%>
                    <td>
                        <asp:Label ID="BookNumLabel" runat="server" Text='<%# Eval("BookNum") %>' />
                    </td>
                    <td>
                        <asp:Label ID="BookNameLabel" runat="server" Text='<%# Eval("BookName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="BookConcernLabel" runat="server" Text='<%# Eval("BookConcern") %>' />
                    </td>
                    <td>
                        <asp:Label ID="BookAuthorLabel" runat="server" Text='<%# Eval("BookAuthor") %>' />
                    </td>
                    <td>
                        <asp:Label ID="BookCountLabel" runat="server" Text='<%# Eval("BookCount") %>' />
                    </td>
                    <td>
                        <asp:Label ID="BookPriceLabel" runat="server" Text='<%# Eval("BookPrice") %>' />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <tr style="background-color: #999999;">
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
                    </td>
                    <%--<td>
                        <asp:TextBox ID="IDTextBox" runat="server" Text='<%# Bind("ID") %>' />
                    </td>--%>
                    <td>
                        <asp:TextBox ID="BookNumTextBox" runat="server" Text='<%# Bind("BookNum") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="BookNameTextBox" runat="server" Text='<%# Bind("BookName") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="BookConcernTextBox" runat="server" Text='<%# Bind("BookConcern") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="BookAuthorTextBox" runat="server" Text='<%# Bind("BookAuthor") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="BookCountTextBox" runat="server" Text='<%# Bind("BookCount") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="BookPriceTextBox" runat="server" Text='<%# Bind("BookPrice") %>' />
                    </td>
                </tr>
            </EditItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                    <tr>
                        <td>未返回数据。</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
                    </td>
                    <%--<td>
                        <asp:TextBox ID="IDTextBox" runat="server" Text='<%# Bind("ID") %>' />
                    </td>--%>
                    <td>
                        <asp:TextBox ID="BookNumTextBox" runat="server" Text='<%# Bind("BookNum") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="BookNameTextBox" runat="server" Text='<%# Bind("BookName") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="BookConcernTextBox" runat="server" Text='<%# Bind("BookConcern") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="BookAuthorTextBox" runat="server" Text='<%# Bind("BookAuthor") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="BookCountTextBox" runat="server" Text='<%# Bind("BookCount") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="BookPriceTextBox" runat="server" Text='<%# Bind("BookPrice") %>' />
                    </td>
                </tr>
            </InsertItemTemplate>
            <ItemTemplate>
                <tr style="background-color: #E0FFFF;color: #333333;">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="删除" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="编辑" />
                    </td>
                    <%--<td>
                        <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                    </td>--%>
                    <td>
                        <asp:Label ID="BookNumLabel" runat="server" Text='<%# Eval("BookNum") %>' />
                    </td>
                    <td>
                        <asp:Label ID="BookNameLabel" runat="server" Text='<%# Eval("BookName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="BookConcernLabel" runat="server" Text='<%# Eval("BookConcern") %>' />
                    </td>
                    <td>
                        <asp:Label ID="BookAuthorLabel" runat="server" Text='<%# Eval("BookAuthor") %>' />
                    </td>
                    <td>
                        <asp:Label ID="BookCountLabel" runat="server" Text='<%# Eval("BookCount") %>' />
                    </td>
                    <td>
                        <asp:Label ID="BookPriceLabel" runat="server" Text='<%# Eval("BookPrice") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                <tr runat="server" style="background-color: #E0FFFF;color: #333333;">
                                    <th runat="server">操作</th>
                                  <%--<th runat="server">ID</th>--%>  
                                    <th runat="server">书号</th>
                                    <th runat="server">书名</th>
                                    <th runat="server">出版社</th>
                                    <th runat="server">作者</th>
                                    <th runat="server">数量</th>
                                    <th runat="server">价格</th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style="text-align: center;background-color: #5D7B9D;font-family: Verdana, Arial, Helvetica, sans-serif;color: #FFFFFF"></td>
                    </tr>
                </table>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <tr style="background-color: #E2DED6;font-weight: bold;color: #333333;">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="删除" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="编辑" />
                    </td>
                    <%--<td>
                        <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                    </td>--%>
                    <td>
                        <asp:Label ID="BookNumLabel" runat="server" Text='<%# Eval("BookNum") %>' />
                    </td>
                    <td>
                        <asp:Label ID="BookNameLabel" runat="server" Text='<%# Eval("BookName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="BookConcernLabel" runat="server" Text='<%# Eval("BookConcern") %>' />
                    </td>
                    <td>
                        <asp:Label ID="BookAuthorLabel" runat="server" Text='<%# Eval("BookAuthor") %>' />
                    </td>
                    <td>
                        <asp:Label ID="BookCountLabel" runat="server" Text='<%# Eval("BookCount") %>' />
                    </td>
                    <td>
                        <asp:Label ID="BookPriceLabel" runat="server" Text='<%# Eval("BookPrice") %>' />
                    </td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Lesson3.BookModel" DeleteMethod="Delete" InsertMethod="InsertBook" SelectMethod="GetBooks" TypeName="Lesson3.BookAction" UpdateMethod="UpdateBook" EnablePaging="True" SelectCountMethod="TotalCount">
            <SelectParameters>
           <%--<asp:Parameter Name="maximumRows" Type="Int32" />
                <asp:Parameter Name="startRowIndex" Type="Int32" />--%>
            </SelectParameters>
        </asp:ObjectDataSource>
    
    </div>
        <asp:DataPager ID="DataPager1" runat="server" PagedControlID="ListView1" PageSize="4">
            <Fields>
                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
            </Fields>
        </asp:DataPager>
    </form>
</body>
</html>
