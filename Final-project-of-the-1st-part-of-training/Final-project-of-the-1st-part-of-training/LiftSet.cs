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
            PrintResultSend(resident);
        }
        public void CallLiftCalculateSendPrint(List<Flat> flats, Resident resident)
        {
            Generate generate = new Generate();
            resident.AddCargo(generate.Cargo());
            const int MAX_LIFT_LIFTINGCAPACITY = 400;
            if (resident.Wt + resident.Cargo.wt > MAX_LIFT_LIFTINGCAPACITY)
            {
                Console.WriteLine("Обнаружен нарушитель, пытающийся заставить лифт везти более 400 кг. На место вызвана оперативная бригада, все лифты заблокированы");
                Console.Write("Для продолжения введите любой символ: ");
                Console.ReadLine();
            }
            else
            {
                const int FIRST_FLOOR_NUMBER = 1;
                if (resident.Flat.Floor==1)
                {
                    int location;
                    if (resident.Location == Location.home)
                    {
                        location = resident.Flat.Floor;
                    }
                    else
                    {
                        location = FIRST_FLOOR_NUMBER;
                    }
                    Console.WriteLine("");
                    Console.WriteLine("Житель квартиры №{0} {1} уже поднес палец к кнопке вызова лифта, но вовремя опомнился: Жителю первого этажа не нужен лифт. Усмехнувшись он посмотрел на свой безценный груз - {3} весом {4} кг." +
                        " {1} заглянул в прорезь в стене, которую проковырял еще в детсве. Все лифты мирно покачивались каждый на отведенном ему судьбой месте:",
                        resident.Flat.Number, resident.Name, location, resident.Cargo.name, resident.Cargo.wt);

                    foreach (Lift nextLift in Set)
                    {
                        Console.Write("Лифт №{0} на этаже №{1}. ", nextLift.Number, nextLift.Floor);
                    }
                    Console.WriteLine("");
                }
                else
                {
                    
                    int targetLiftNumberinList = Set.Count;
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
                        arrivalFloor = FIRST_FLOOR_NUMBER;
                    }
                    else
                    {
                        departureFloor = FIRST_FLOOR_NUMBER;
                        arrivalFloor = resident.Flat.Floor;
                    }
                    do
                    {
                        for (int i = 0; i < Set.Count; i++)
                        {
                            if (Math.Abs(Set[i].Floor - departureFloor) < minDifference && targetLiftNumberinList != i)
                            {
                                targetLiftNumberinList = i;
                                minDifference = Math.Abs(Set[i].Floor - departureFloor);
                            }
                        }
                        Set[targetLiftNumberinList].ChangeFloor(departureFloor);
                    }
                    while (resident.Wt + resident.Cargo.wt > Set[targetLiftNumberinList].LiftingCapacity);
                    SendLiftAndResident(Set[targetLiftNumberinList], resident, arrivalFloor);
                }
                
            }
        }
        public void PrintResultSend(Resident resident)
        {
            const int FIRST_FLOOR_NUMBER = 1;
            int location;
            if (resident.Location == Location.home)
            {
                location = resident.Flat.Floor;
            }
            else
            {
                location = FIRST_FLOOR_NUMBER;
            }
            Console.WriteLine("");
            Console.WriteLine("Житель квартиры №{0} {1} приехал на этаж №{2}. Чтобы не простаивала грузопдъемность лифата {1} захватил с собой {3} весом {4} кг." +
                " Легкий холодок пробежал по его спине, ощущение того, что он всего лишь симуляция опять острой иглой укололо в центр его естества. {1} заглянул в прорезь в стене, " +
                "которую проковырял еще в детсве. Все лифты мирно покачивались каждый на отведенном ему судьбой месте:",
                resident.Flat.Number, resident.Name, location, resident.Cargo.name, resident.Cargo.wt);
           
            foreach (Lift nextLift in Set)
            {
                Console.Write("Лифт №{0} на этаже №{1}. ", nextLift.Number, nextLift.Floor);
            }
            Console.WriteLine("");
        }
    }
}
