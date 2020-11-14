using System;
using System.Collections.Generic;
using System.Text;
public enum Location
{
    home,
    street
}

namespace Final_project_of_the_1st_part_of_training
{
    public class Resident
    {
        public string Name
        { get; private set; }

        public Location Location
        { get; private set; }
        public int Wt
        { get; private set; }
        public int FlatNumber
        { get; private set; }
        public Resident(int wt, string name)
        {
            Name = name;
            Wt = wt;
        }
        public void PutInAnFlat(int flatNumber)
        {
            FlatNumber = flatNumber;
        }

    }
}
