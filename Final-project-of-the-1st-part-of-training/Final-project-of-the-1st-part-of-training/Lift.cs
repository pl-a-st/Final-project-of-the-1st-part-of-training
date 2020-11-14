using System;
using System.Collections.Generic;
using System.Text;

namespace Final_project_of_the_1st_part_of_training
{
   public  class Lift
    {
        public int Number
        { get; private set;}
        public int Floor
        { get; private set; }
        public int LiftingCapacity
        { get; private set; }
        public Lift (int number, int floor, int liftingCapacity)
        {
            Number = number;
            Floor = floor;
            LiftingCapacity = liftingCapacity;
        }
        public void ChangeFloor (int floor)
        {
            Floor = floor;
        }
    }
}
