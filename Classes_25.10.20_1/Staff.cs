using System;
using System.Collections.Generic;
using System.Text;

namespace Classes_25._10._20_1
{
    class Staff
    {
        public string Name
        {
            get; private set;
        }
        public string SurName
        {
            get; private set;
        }
        public string MiddleName
        {
            get; private set;
        }
        
        /// <summary>
        /// Должность
        /// </summary>
        public string Post
        {
            get; private set;
        }
        public int Age
        {
            get; private set;
        }
       public int Salary
        {
            get; private set;
        }
        public double Premium
        {
            get; private set;
        }
        public Staff(string name, string surName, string middleName, string post, int age, int salary )
        {
            Name = name;
            SurName = surName;
            MiddleName = middleName;
            Post = post;
            Age = age;
            Salary = salary;
        }
       
        public void CalculatePremium()
        {
            const int START_EXPERIENCE_AGE = 20;
            const int DEGREE_EXPERIENCE_FOR_PREMIUM = 4;
            Premium = 0;
            if (Age> START_EXPERIENCE_AGE)
            {
                Premium = Salary/100*Convert.ToInt32((Age- START_EXPERIENCE_AGE) / DEGREE_EXPERIENCE_FOR_PREMIUM * 5);
            }
            
        }
    }
    

}
