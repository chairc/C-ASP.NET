using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lesson3
{
    public partial class Repeater : System.Web.UI.Page
    {
        public StudentAction action = new StudentAction();

        protected void Page_Load(object sender, EventArgs e)
        {
            int pageSize = int.Parse(Request["pageSize"] ?? "5");
            int pageIndex = int.Parse(Request["pageIndex"] ?? "1");
            int total = 0;
            if (!IsPostBack)
            {
                this.Repeater1.DataSource = action.GetStudents(pageIndex, pageSize, out total);
                this.Repeater1.DataBind();
            }
            this.Literal1.Text = PagingHelper.ShowPageNavigate(pageSize, pageIndex, total);
        }

        protected void repeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int pageSize = int.Parse(Request["pageSize"] ?? "5");
                int pageIndex = int.Parse(Request["pageIndex'"] ?? "1");
                int total = 0;
                int deleteId = int.Parse(e.CommandArgument.ToString());
                action.Delete(deleteId);
                this.Repeater1.DataSource = action.GetStudents(pageIndex, pageSize, out total);
                this.Repeater1.DataBind();
                if (pageIndex > 1 && total <= (pageIndex - 1) * pageSize)
                {
                    pageIndex -= 1;
                }
                this.Literal1.Text = PagingHelper.ShowPageNavigate(pageSize, pageIndex, total);
            }
            else if(e.CommandName=="Update")
            {
                int editId = int.Parse(e.CommandArgument.ToString());
                Response.Redirect("EditStudent.aspx?id=" + editId);
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AddStudent.aspx");
        }
    }
}