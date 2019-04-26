using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Lesson1
{
    public partial class Register : System.Web.UI.Page
    {
        private void BindDropDownList(DropDownList ddl, params SqlParameter[] pms)
        {
            string sql = "select * from Area where ParentID=@pId";
            DataTable dtprovince = SqlHelper.ExecuteDataTable(sql, pms);
            ddl.DataSource = dtprovince;
            ddl.DataTextField = "Name";
            ddl.DataValueField = "AreaID";
            ddl.DataBind();
        }
        private void BindAllDropDownList(params SqlParameter[] pms)
        {
            BindDropDownList(DDLProvince, pms);
            int citySelect = Convert.ToInt32(DDLProvince.SelectedItem.Value);
            BindDropDownList(DDLCity, new SqlParameter("@pId", citySelect));
            int countySelect = Convert.ToInt32(DDLCity.SelectedItem.Value);
            BindDropDownList(DDLCounty, new SqlParameter("@pId", countySelect));
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAllDropDownList(new SqlParameter("@pId", "0"));
            }
            else
            {
                txtPwd.Attributes["value"] = Request["txtPwd"];
                txtRePwd.Attributes["value"] = Request["txtRePwd"];
            }
        }

        protected void DDLProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDropDownList(DDLCity, new SqlParameter("@pId", DDLProvince.SelectedItem.Value));//绑定选中省下的市
            BindDropDownList(DDLCounty, new SqlParameter("@pId", DDLCity.SelectedItem.Value));//绑定选中市下的县
        }

        protected void DDLCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDropDownList(DDLCounty, new SqlParameter("@pId", DDLCity.SelectedItem.Value));//绑定选中市下的县
        }

        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            if (Page.IsValid)
            {
                String[] address = { DDLProvince.SelectedItem.Text, DDLCity.SelectedItem.Text, DDLCounty.SelectedItem.Text };
                string sql = "insert into UserMessage values(@Name,@Age,@Gender,@Address,@Email,@pwd,@Phone)";
                SqlParameter[] pms = { new SqlParameter("@Name", txtName.Text), new SqlParameter("@Age", txtAge.Text), new SqlParameter("@Gender", radbtnB.Checked ? "男" : "女"), new SqlParameter("@Address", string.Join(",", address)), new SqlParameter("@Email", txtEmail.Text), new SqlParameter("@pwd", txtPwd.Text), new SqlParameter("@Phone", txtPhone.Text) };
                int count = SqlHelper.ExecuteNonQuery(sql, pms);
                if (count > 0)
                {
                    Response.Write("<script>alert('注册成功')</script>");
                    Clear();
                }
                else
                {
                    Response.Write("<script>alert('注册失败')</script>");
                }
            }
        }
        private void Clear()
        {
            txtAge.Text = "";
            txtEmail.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtPwd.Text = "";
            txtRePwd.Text = "";
            txtPwd.Attributes["value"] = "";
            txtRePwd.Attributes["value"] = "";
            radbtnB.Checked = true;
            BindAllDropDownList(new SqlParameter("@pid", "0"));
        }
    }
}