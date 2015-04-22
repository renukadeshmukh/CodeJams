using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengeCS
{
    public class User
    {
        protected int basicId;
        protected string sampleName;

        public int GetId()
        {
            return basicId;
        }

        public string GetName()
        {
            return sampleName;
        }
    }

    public class Student : User {

        public int studentId { get; set; }

        public Student(string sampleName, int basicId, int studentId)
        {
            this.sampleName = sampleName;
            this.basicId = basicId;
            this.studentId = studentId;
        }

        new public int GetId()
        {
            return studentId;
        }
    }

    public class Staff : User
    {
        public int hoursWorkedWeekly { get; set; }
        public Staff(string sampleName, int basicId, int hoursWorkedWeekly) {
            this.sampleName = sampleName;
            this.basicId = basicId;
            this.hoursWorkedWeekly = hoursWorkedWeekly;
        }

        public int GetHoursWorkedWeekly()
        {
            return hoursWorkedWeekly;
        }
    }

    public class Professor : User
    {
        public bool hasPhd { get; set; }

        public Professor(string sampleName,int basicId,bool hasPhd)
        {
            this.sampleName = sampleName;
            this.basicId = basicId;
            this.hasPhd = hasPhd;
        }

        new public string GetName()
        {
            if (hasPhd)
                return "Dr. " + this.sampleName;
            else return this.sampleName;
        }
    }
}
