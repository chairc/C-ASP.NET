using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lesson3
{
    public partial class EditStudent : System.Web.UI.Page
    {
        StudentAction action = new StudentAction();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HiddenField1.Value = Request.UrlReferrer.ToString();
                string id = Request.QueryString["ID"];
                if (string.IsNullOrEmpty(id))
                {
                    Response.Write("<script>alert('数据错误')</script>");

                }
                else
                {
                    StudentModel stu = action.SelectStudent(Convert.ToInt32(id));
                    if (stu == null)
                    {
                        Response.Write("<script>alert('需修改用户不存在')</scropt>");
                    }
                    else
                    {
                        lblId.Text = stu.ID.ToString();
                        txtNum.Text = stu.StuNum;
                        txtName.Text = stu.StuName;
                        txtClass.Text = stu.StuClass;
                        Subject.Text = stu.Subject;
                        txtAge.Text = stu.StuAge == null ? "" : stu.StuAge.ToString();
                        txtPhone.Text = stu.StuPhone;
                        if (stu.StuGender == "男")
                        {

                            radbtnB.Checked = true;
                        }
                        else if (stu.StuGender == "女")
                        {
                            radbtnG.Checked = true;
                        }
                    }
                }
            }
        }


        protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
        {
            string stuNum = txtNum.Text.Trim();
            if (Page.IsValid)
            {
                if (action.SelectCount(stuNum, Convert.ToInt32(lblId.Text)) > 0)
                {
                    Response.Write("<script>alert('学号重复')</script>");
                }
                else
                {
                    int age;
                    StudentModel stu = new StudentModel();
                    stu.ID = Convert.ToInt32(lblId.Text);
                    stu.StuAge = Int32.TryParse(txtAge.Text.Trim(), out age) ? (int?)age : null;
                    stu.StuClass = txtClass.Text.Trim();
                    stu.StuGender = radbtnB.Checked ? "男" : (radbtnG.Checked ? "女" : "");
                    stu.StuName = txtName.Text.Trim();
                    stu.StuNum = stuNum;
                    stu.Subject = Subject.Text.Trim();
                    stu.StuPhone = txtPhone.Text.Trim();
                    bool isOk = action.UpdateStudent(stu) > 0;
                    if (isOk)
                    {
                        Response.Redirect("/Repeater.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('修改失败')</script>");
                    }
                }
            }
        }

        protected void btnClear_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void HiddenField1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}