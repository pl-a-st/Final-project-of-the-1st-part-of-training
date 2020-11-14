using System;
using System.Collections.Generic;
using System.Text;

namespace Final_project_of_the_1st_part_of_training
{
    public class Flat
    {
        public int Floor
        { get; private set; }
        public int Capacity
        { get; private set; }
        public int ResidentCount
        { get; private set; }
        public int Number
        { get; private set;}
        public Flat(int floor, int capacity,int number)
        {
            Floor = floor;
            Capacity = capacity;
            Number = number;
        }
        public void AddResident()
        {
            if (Capacity==ResidentCount)
            {
                Console.WriteLine("Вместимость квартиры не позволяет добавить еще одного человека.");
                Console.Write("Для продолжения нажмите любую кнопку: ");
                Console.ReadLine();
            }
            else
            {
                ResidentCount++;
            }
        }
    }
}
