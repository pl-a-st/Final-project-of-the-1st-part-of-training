﻿using System;
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
        public void SendLiftAndResident(Lift lift, Resident resident, int arrivalFloor)
        {
            lift.ChangeFloor(arrivalFloor);
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
            if (resident.Wt + resident.Cargo.wt > MAX_LIFT_LIFTINGCAPACITY)
            {
                Console.WriteLine("Обнаружен нарушитель, пытающийся заставить лифт везти более 400 кг. На место вызвана оперативная бригада, все лифты заблокированы");
                Console.Write("Для продолжения введите любой символ: ");
                Console.ReadLine();
            }
            else
            {
                const int FIRST_FLOOR = 1;
                int targetLiftNumberinList=Set.Count;
                int departureFloor;
                int arrivalFloor;
                int minDifference = 0;
                foreach (Flat nextFlat in flats)
                {
                    if (nextFlat.Floor > minDifference)
                    {
                        minDifference = nextFlat.Floor;
                    }
                }
                if (resident.Location == Location.home)
                {
                    departureFloor = resident.Flat.Floor;
                    arrivalFloor = FIRST_FLOOR;
                }
                else
                {
                    departureFloor = FIRST_FLOOR;
                    arrivalFloor = resident.Flat.Floor;
                }
                do
                {
                    for (int i = 0; i < Set.Count; i++)
                    {
                        if (Math.Abs(Set[i].Floor - departureFloor) < minDifference && targetLiftNumberinList != i)
                        {
                            targetLiftNumberinList = i;
                        }
                    }
                    Set[targetLiftNumberinList].ChangeFloor(departureFloor);
                }
                while (resident.Wt + resident.Cargo.wt > Set[targetLiftNumberinList].LiftingCapacity);
                SendLiftAndResident(Set[targetLiftNumberinList], resident, arrivalFloor);
            }
        }
    }
}
