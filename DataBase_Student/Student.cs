using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase_Student
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }
        public string Payment { get; set; }
        public string Contact { get; set; }

        public Student(int id, string name, string data, string payment, string contact)
        {
            Id = id;
            Name = name;
            Data = data;
            Payment = payment;
            Contact = contact;
        }
    }
}
