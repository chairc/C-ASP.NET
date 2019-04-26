<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Repeater.aspx.cs" Inherits="Lesson3.Repeater" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="header">
        <h1>学生信息列表<a href="AddStudent.aspx">添加记录</a></h1>
    </div>
    <div id="CenterDiv">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="repeater_ItemCommand">
            <HeaderTemplate>
                <table id="studentTable">
                    <tr>
                        <th>编号</th>
                        <th>学号</th>
                        <th>姓名</th>
                        <th>班级</th>
                        <th>学科</th>
                        <th>年龄</th>
                        <th>电话</th>
                        <th>性别</th>
                        <th>操作</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <th><%#Container.ItemIndex+1 %></th>
                    <th><%# Eval("StuNum") %></th>
                    <th><%# Eval("StuName") %></th>
                    <th><%# Eval("StuClass") %></th>
                    <th><%# Eval("subject") %></th>
                    <th><%# Eval("StuAge") %></th>
                    <th><%# Eval("StuPhone") %></th>
                    <th><%# Eval("StuGender") %></th>
                    <th>
                        <asp:LinkButton ID="btnEdit" CommandArgument='<%# Eval("ID") %>' CommandName="Update" runat="server" Text="修改" />
                        <asp:LinkButton ID="btnDelete" OnClientClick="return confirm('是要真的删除吗？')" CommandArgument='<%# Eval("ID") %>' CommandName="Delete" runat="server">删除</asp:LinkButton>
                    </th>
                </tr>
            </ItemTemplate>
            <FooterTemplate></table></FooterTemplate>
        </asp:Repeater>
        <div style="margin-top: 410px;">
            <asp:Literal ID="Literal1" runat="server">

            </asp:Literal>
        </div>
    </div>
    </form>
</body>
</html>
