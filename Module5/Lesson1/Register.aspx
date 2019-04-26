<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Lesson1.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="reg">
        <h2>用户注册</h2>
        <p>昵称：<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="*用户名不能为空" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <p>密码：<asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPwd" Display="Dynamic" ErrorMessage="*密码不能为空" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <p>重复密码：<asp:TextBox ID="txtRePwd" runat="server" TextMode="Password"></asp:TextBox>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPwd" ControlToValidate="txtRePwd" Display="Dynamic" ErrorMessage="*两次密码必须一致" ForeColor="Red"></asp:CompareValidator>
        </p>
        <p>邮箱：<asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="*邮箱格式不正确" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </p>
        <p>年龄：<asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtAge" Display="Dynamic" ErrorMessage="*年龄范围不正确" ForeColor="Red" MaximumValue="120" MinimumValue="0" Type="Integer"></asp:RangeValidator>
        </p>
        <p>
            性别：
           <asp:RadioButton ID="radbtnB" runat="server" Text="男" GroupName="sex" />
           <asp:RadioButton ID="radbtnG" runat="server" Text="女" GroupName="sex" />
        </p>
        <p>电话：<asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></p>
        <p>
            家庭住址：
           <asp:DropDownList ID="DDLProvince" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLProvince_SelectedIndexChanged"></asp:DropDownList>
           <asp:DropDownList ID="DDLCity" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLCity_SelectedIndexChanged"></asp:DropDownList>
           <asp:DropDownList ID="DDLCounty" runat="server" AutoPostBack="True"></asp:DropDownList>
        </p>
        <p><asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/images/Save.png" OnClick="btnSave_Click" /></p>    
    </div>
    </form>
</body>
</html>
