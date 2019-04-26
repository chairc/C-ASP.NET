<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditStudent.aspx.cs" Inherits="Lesson3.EditStudent" %>

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
        <h1>修改学生信息
            <a href="Repeater.aspx">
                返回
             
            </a>
        </h1>
    </div>
        
    <div id="CenterDiv2">
        <div id="head"><h4>修改用户</h4></div>
        <asp:HiddenField ID="HiddenField1" runat="server" Visible="False" OnValueChanged="HiddenField1_ValueChanged" />
        
        <p>
            学号：<asp:TextBox ID="txtNum" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNum" Display="Dynamic" ErrorMessage="*不能为空" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:Label ID="lblId" runat="server" Text="Label" Visible="False"></asp:Label>
        </p>
        <p>
            姓名：<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="*不能为空" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <p>
            班级：<asp:TextBox ID="txtClass" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtClass" Display="Dynamic" ErrorMessage="*不能为空" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <p>
            学科：<asp:TextBox ID="Subject" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Subject" Display="Dynamic" ErrorMessage="*不能为空" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <p>
            年龄：<asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
        </p>
        <p>
            电话：<asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
        </p>
        <p>
            性别：
           <asp:RadioButton ID="radbtnB" runat="server" Text="男" GroupName="sex" />
           <asp:RadioButton ID="radbtnG" runat="server" Text="女" GroupName="sex" />
        </p>
        <p>
            <asp:ImageButton ID="btnUpdate" runat="server" ImageUrl="~/images/Save.png" OnClick="btnUpdate_Click" />
            <asp:ImageButton ID="btnClear" runat="server" ImageUrl="~/images/Clear.png" OnClick="btnClear_Click" />
        </p>
    </div>
    </form>
</body>
</html>
