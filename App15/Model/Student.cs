using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App15.Model
{
    class Student : IComparable<Model.Student>
    {
        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String ClassName { get; set; }

        public String ExamGroup { get; set; }


        public int CompareTo(Student other)
        {
            // sort by firstname - easy 
            return FirstName.CompareTo(other.FirstName);
        }
    }
}
