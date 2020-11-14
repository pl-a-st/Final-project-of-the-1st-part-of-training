using System;
using System.Collections.Generic;
using System.Text;

namespace Final_project_of_the_1st_part_of_training
{
    public class LiftSet
    {
        public List<Lift> Set
        { get; private set;}
        public LiftSet(List<Lift> set)
        {
            Set = set;
        }
        public void SendLiftAndResident(Lift lift, Resident resident, int residentFloor)
        {
            lift.ChangeFloor(residentFloor);
            Location atStreet = Location.street;
            Location atHome = Location.home;
            if (resident.Location == atStreet)
            {
                resident.ChangeLocation(atHome);
            }
            else
            {
                resident.ChangeLocation(atStreet);
            }
        }
        public void CallLiftCalculateSend(List<Flat> flats, Resident resident)
        {
            const int MAX_LIFT_LIFTINGCAPACITY = 400;
            if (resident.Wt+resident.Cargo.wt>MAX_LIFT_LIFTINGCAPACITY)
            {
                Console.WriteLine("Обнаружен нарушитель, пытющийся заставить везти лифт более 400 кг. На место вызвана оперативная бригада, все лифты заблокированы");
                Console.Write("Для продолжения введите любой символ");
                Console.ReadLine();
            }
            else
            {
                Lift targetLift;
                do
                {
                    targetLift = Set[0];
                    foreach (Lift nextLift in Set)
                    {
                        if(nextLift.Floor)
                    }
                }
                while (targetLift.LiftingCapacity < resident.Wt + resident.Cargo.wt);
                
            }

        }
    }
}
