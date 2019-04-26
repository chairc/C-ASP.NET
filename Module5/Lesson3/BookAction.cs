using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Lesson3
{
    public class BookAction
    {
        public List<BookModel> GetBooks(int maximumRows, int startRowIndex)
        {
            string sql = "select top(@maximumRows) * from Book where Id not in (select top(@startRowIndex) Id from Book)";
            SqlParameter[] pams = {new SqlParameter ("@maximumRows",maximumRows),
                                    new SqlParameter ("@startRowIndex",startRowIndex)
            };
            List<BookModel> bookList = null;
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, pams))
            {
                if (reader.HasRows)
                {
                    bookList = new List<BookModel>();
                    while (reader.Read())
                    {
                        BookModel book = new BookModel();
                        book.ID = reader.GetInt32(0);
                        book.BookNum = reader.GetString(1);
                        book.BookName = reader.GetString(2);
                        book.BookConcern = reader.GetString(3);
                        book.BookAuthor = reader.GetString(4);
                        book.BookCount = reader.GetInt32(5);
                        book.BookPrice = reader.GetDecimal(6);
                        bookList.Add(book);
                    }
                }
            }
            return bookList;
        }
        public int InsertBook(BookModel book)
        {
            string sql = "insert into Book values(@BookNum,@BookName,@BookConcern,@BookAuthor,@BookCount,@BookPrice)";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter ("@BookNum",book.BookNum),
                new SqlParameter ("@BookName",book.BookName),
                new SqlParameter ("@BookConcern",book.BookConcern),
                new SqlParameter ("@BookAuthor",book.BookAuthor),
                new SqlParameter ("@BookCount",book.BookCount),
                new SqlParameter ("@BookPrice",book.BookPrice),
            };
            int count = SqlHelper.ExecuteNonQuery(sql, paras);
            return count;
        }
        public int Delete(BookModel book)
        {
            string sql = "delete Book where Id=@Id";
            SqlParameter pam = new SqlParameter("@Id", book.ID);
            int count = SqlHelper.ExecuteNonQuery(sql, pam);
            return count;
        }
        public int UpdateBook(BookModel book)
        {
            string sql = "update Book set BookNum=@BookNum,bookName=@BookName,BookConcern=@BookConcern,BookAuthor=@BookAuthor,BookCount=@BookCount,BookPrice=@BookPrice where ID=@ID";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter ("@ID",book.ID),
                new SqlParameter ("@BookNum",book.BookNum),
                new SqlParameter ("@BookName",book .BookName),
                new SqlParameter ("@BookConcern",book.BookConcern),
                new SqlParameter ("@BookAuthor",book.BookAuthor),
                new SqlParameter ("@BookCount",book.BookCount),
                new SqlParameter ("@BookPrice",book.BookPrice),
            };
            int count = SqlHelper.ExecuteNonQuery(sql, paras);
            return count;
        }
        public int TotalCount()
        {
            string sql = "select count (*) from Book";
            int count = Convert.ToInt32(SqlHelper.ExecuteScalar(sql));
            return count;
        }
    }
}


