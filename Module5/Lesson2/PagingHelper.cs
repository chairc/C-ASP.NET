using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Lesson3
{
    public class PagingHelper
    {
        public static string ShowPageNavigate(int pageSize, int currentPage, int totalCount)
        {
            string redirectTo = "";
            pageSize = pageSize == 0 ? 5 : pageSize;
            var totalPages = Math.Max((totalCount + pageSize - 1) / pageSize, 1);
            var output = new StringBuilder();
            if (totalPages > 1)
            {
                if (totalPages != 1)
                {
                    output.AppendFormat("<a class='pageLink' href='{0}?pageIndex=1&pageSize={1}'>首页</a>", redirectTo, pageSize);
                }
                if (currentPage > 1)
                {
                    output.AppendFormat("<a class='pageLink' href='{0}?pageIndex={1}&pageSize={2}'>上一页</a>", redirectTo, currentPage - 1, pageSize);
                }
                output.Append(" ");
                int currint = 5;
                for (int i = 0; i <= 10; i++)
                {
                    if ((currentPage + 1 - currint) >= 1 && (currentPage + 1 - currint) <= totalPages)
                    {
                        if (currint == i)
                        {
                            output.AppendFormat("<a class='cpb' href='{0}?pageIndex={1}&pageSize={2}'>{3}</a>", redirectTo, currentPage + i - currint, pageSize, currentPage + i - currint);
                        }
                    }
                    output.Append(" ");
                }
                if (currentPage < totalPages)
                {
                    output.AppendFormat("<a class='pageLink' href='{0}?pageIndex={1}&pageSize={2}'>下一页</a>", redirectTo, currentPage + 1, pageSize);
                }
                output.Append(" ");
                if (currentPage != totalPages)
                {
                    output.AppendFormat("<a class='pageLink' href='{0}?pageIndex={1}&pageSize={2}'>末页</a>", redirectTo, totalPages, pageSize);
                }
                output.Append(" ");
            }
            output.AppendFormat("<font class='pageLink'>第{0}页 / 共{1}页</font>", currentPage, totalPages);
            return output.ToString();
        }
    }
    
}