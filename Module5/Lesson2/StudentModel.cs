using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson3
{
    public class StudentModel
    {
        public int ID { set; get; }
        public string StuNum { set; get; }
        public string StuName { set; get; }
        public string StuClass { set; get; }
        public string Subject { set; get; }
        public int? StuAge { set; get; }
        public string StuPhone { set; get; }
        public string StuGender { set; get; }
    }
}