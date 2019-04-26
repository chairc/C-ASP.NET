using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lesson3
{
    public partial class AddStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Requset.UrlReferrer获取有关客户端上次请求的Url信息
                HiddenField1.Value = Request.UrlReferrer.ToString();
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(HiddenField1.Value);
        }
        StudentAction action = new StudentAction();
        protected void btnInsert_Click(object sender, ImageClickEventArgs e)
        {
            string stuNum = txtNum.Text.Trim();
            if (Page.IsValid)
            {
                if (action.SelectCount(stuNum) > 0)
                {
                    Response.Write("<script>alert('学号重复')</script>");
                }
                else
                {
                    int age;
                    StudentModel stu = new StudentModel();
                    stu.StuAge = Int32.TryParse(txtAge.Text.Trim(), out age) ? (int?)age : null;
                    stu.StuClass = txtClass.Text.Trim();
                    stu.StuGender = radbtnB.Checked ? "男" : (radbtnG.Checked ? "女" : "");
                    stu.StuName = txtName.Text.Trim();
                    stu.StuNum = stuNum;
                    stu.Subject = Subject.Text.Trim();
                    stu.StuPhone = txtPhone.Text.Trim();
                    bool isOk = action.InsertStudent(stu) > 0;
                    if (isOk)
                    {
                        Response.Redirect("/Repeater.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('添加失败'</script>)");
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