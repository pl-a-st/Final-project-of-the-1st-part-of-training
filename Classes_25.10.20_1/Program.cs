using System;
using System.Collections.Generic;

namespace Classes_25._10._20_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Есть сотрудники. Фамилия Имя  Отчество Должность  Возраст Зарплата.   " +
                "Генерируем все что можно. Необходимо понять, на сколько каждому сотруднику нужно поднять " +
                "зарплату если все начали работать с 20 лет и увеличение рассчитывается в зависимости: 5% за каждые 4 года.");
            const int MIN_STAFF_COUNT = 5;
            const int MAX_STAFF_COUNT = 100;
            Random rnd = new Random();
            int staffsCount = rnd.Next(MIN_STAFF_COUNT, MAX_STAFF_COUNT + 1);
            List<Staff> staffs = new List<Staff>();
            for (int i=0;i< staffsCount; i++)
            {
                string post = GeneratePost();
                Staff staff = new Staff(GenerateName(),GenerateSurname(),GenerateMiddlename(),post,GenerateAge(),GenerateSalary(post));
                staff.CalculatePremium();                
                staffs.Add(staff);
            }
            foreach(Staff nextStaff in staffs)
            {
                Console.WriteLine("Работник. Имя: {0}, Фамилия: {1}, Оттчество: {2}, Должность: {3}, Зарплата: {4}," +
                    " Возраст: {5}, Премия: {6}. ", nextStaff.Name, nextStaff.SurName, nextStaff.MiddleName, nextStaff.Post, nextStaff.Salary,
                    nextStaff.Age, nextStaff.Premium);
            }
        }
        static string GenerateSurname()
        {
            Random rnd = new Random();
            string[] surnames = { "Иванов", "Петров", "Хвостиченко", "Смирнов", "Верин" };
            return surnames[rnd.Next(0, surnames.Length)];
        }
        static string GeneratePost()
        {
            Random rnd = new Random();
            string[] postes = { "Инженер 1-ой категории", "Менеджер", "Директор", "Уборщик", "Массажист" };
            return postes[rnd.Next(0, postes.Length)];
        }
        static int GenerateSalary(string post)
        {
            Dictionary<string,int> matchingSalaryPost = new Dictionary<string, int>
            {
                {"Инженер 1-ой категории",50000},
                {"Менеджер",70000},
                {"Директор",150000 },
                {"Уборщик",25000},
                {"Массажист",60000},
            };
            return matchingSalaryPost[post];
        }
        static string GenerateMiddlename()
        {
            Random rnd = new Random();
            string[] middlenames = { "Иванович", "Петрович", "Сергеевич", "Васильевич", "Владимирович" };
            return middlenames[rnd.Next(0, middlenames.Length)];
        }
        static string GenerateName()
        {
            Random rnd = new Random();
            string[] names = { "Сергей", "Петр", "Борис", "Владислав", "Галя" };
            return names[rnd.Next(0, names.Length)];
        }
        static int GenerateAge()
        {
            Random rnd = new Random();
            
            return rnd.Next(20, 60);
        }
    }

}
