using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Lesson3
{
    public class StudentAction
    {

        public List<StudentModel> GetStudents(int pageIndex, int pageSize, out int total)
        {
            string sql = "select count (*) from Student";
            total = (int)SqlHelper.ExecuteScalar(sql);
            if (pageIndex > 1 && total <= (pageIndex - 1) * pageSize)
            {
                pageIndex -= 1;
            }
            int count = pageSize * (pageIndex - 1);
            sql = "select top(@pageSize)*from Student where Id not in (select top(@count) Id from Student)";
            SqlParameter[] pams ={
                new SqlParameter("@pageSize",pageSize),
                new SqlParameter("@count",count)
           };
            List<StudentModel> studentList = null;
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, pams))
            {
                if (reader.HasRows)
                {
                    studentList = new List<StudentModel>();
                    while (reader.Read())
                    {
                        StudentModel student = new StudentModel();
                        student.ID = reader.GetInt32(0);
                        student.StuNum = reader.GetString(1);
                        student.StuName = reader.GetString(2);
                        student.StuClass = reader.GetString(3);
                        student.Subject = reader.GetString(4);
                        student.StuAge = Convert.IsDBNull(reader[5]) ? null : (int?)reader.GetInt32(5);
                        student.StuPhone = Convert.IsDBNull(reader[6]) ? null : reader.GetString(6);
                        student.StuGender = Convert.IsDBNull(reader[7]) ? null : reader.GetString(7);
                        studentList.Add(student);
                    }
                }
            }
            return studentList;
        }

        public int SelectCount(string stuNum)
        {
            string sql = "select count (*) from Student where StuNum=@StuNum";
            SqlParameter para = new SqlParameter("@StuNum", stuNum);
            int count = Convert.ToInt32(SqlHelper.ExecuteScalar(sql, para));
            return count;
        }

        public int InsertStudent(StudentModel stu)
        {
            string sql = "insert into Student values(@StuNum,@StuName,@StuClass,@Subject,@StuAge,@StuPhone,@StuGender)";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@StuNum",stu.StuNum),
                new SqlParameter("@StuClass",stu.StuClass),
                new SqlParameter("@StuName",stu.StuName),
                new SqlParameter("@Subject",stu.Subject),
                new SqlParameter("@StuAge",stu.StuAge==null?DBNull.Value:(object)stu.StuAge),
                new SqlParameter("@StuPhone",stu.StuPhone),
                new SqlParameter("@StuGender",stu.StuGender)
            };
            int count = SqlHelper.ExecuteNonQuery(sql, paras);
            return count;
        }

        public int Delete(int id)
        {
            string sql = "delete Student where Id=@Id";
            SqlParameter pam = new SqlParameter("@Id", id);
            int count = SqlHelper.ExecuteNonQuery(sql, pam);
            return count;
        }

        public StudentModel SelectStudent(int id)
        {
            string sql = "select * from Student where Id=@Id";
            SqlParameter pam = new SqlParameter("@Id", id);
            StudentModel stu = null;
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, pam))
            {
                if (reader.Read())
                {
                    stu = new StudentModel();
                    stu.ID = reader.GetInt32(0);
                    stu.StuNum = reader.GetString(1);
                    stu.StuName = reader.GetString(2);
                    stu.StuClass = reader.GetString(3);
                    stu.Subject = reader.GetString(4);
                    stu.StuAge = Convert.IsDBNull(reader[5]) ? null : (int?)reader.GetInt32(5);
                    stu.StuPhone = Convert.IsDBNull(reader[6]) ? null : reader.GetString(6);
                    stu.StuGender = Convert.IsDBNull(reader[7]) ? null : reader.GetString(7);
                }
            }
            return stu;
        }


        public int UpdateStudent(StudentModel stu)
        {
            string sql = "update Student set StuNum=@StuNum,StuName=@StuName,StuClass=@StuClass,Subject=@Subject,StuAge=@StuAge,StuPhone=@StuPhone,StuGender=@StuGender where ID=@ID";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@ID",stu.ID),
                new SqlParameter("@StuNum",stu.StuNum),
                new SqlParameter("@StuClass",stu.StuClass),
                new SqlParameter("@StuName",stu.StuName),
                new SqlParameter("@Subject",stu.Subject),
                new SqlParameter("@StuAge",stu.StuAge==null?DBNull.Value:(object)stu.StuAge),
                new SqlParameter("@StuPhone",stu.StuPhone),
                new SqlParameter("@StuGender",stu.StuGender)
            };
            int count = SqlHelper.ExecuteNonQuery(sql, paras);
            return count;
        }

        public int SelectCount(string stuNum, int id)
        {
            string sql = "select count (*) from Student where StuNum=@StuNum and Id not in (@Id)";
            SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@StuNum",stuNum),
                    new SqlParameter("@Id",id)
                };
            int count = Convert.ToInt32(SqlHelper.ExecuteScalar(sql, paras));
            return count;
        }

    }
}