using System;
using System.Collections.Generic;
using System.Text;

namespace Final_project_of_the_1st_part_of_training
{
    public class Generate
    {
        public List<Flat> ListFlats(int floorCount)
        {
            const int FLAT_COUNT_IN_FLOOR = 4;
            const int MIN_FLATS_CAPACITY = 0;
            const int MAX_FLATS_CAPACITY = 5;
            Random rnd = new Random();
            List<Flat> flats = new List<Flat>();
            for (int i = 0; i < floorCount; i++)
            {
                for (int j = 0; j < FLAT_COUNT_IN_FLOOR; j++)
                {
                    int capacity = rnd.Next(MIN_FLATS_CAPACITY, MAX_FLATS_CAPACITY + 1);
                    Flat flat = new Flat(i + 1, capacity, j + 1);
                    flats.Add(flat);
                }
            }
            return flats;
        }
        public List<Resident> ListResidets(List<Flat> flats)
        {
            const int MIN_WT_RESIDENT = 15;
            const int MAX_WT_RESIDENT = 120;
            Random rnd = new Random();
            List<Resident> residents = new List<Resident>();
            foreach (Flat nextFlat in flats)
            {
                for (int i = 0; i < nextFlat.Capacity; i++)
                {
                    int wt = rnd.Next(MIN_WT_RESIDENT, MAX_WT_RESIDENT + 1);
                    Resident resident = new Resident(wt, Name(), Location());
                    resident.PutInAnFlat(nextFlat);
                    residents.Add(resident);
                    nextFlat.AddResident(resident);
                }
            }
            return residents;
        }
        public List<Lift> ListLift(int floorCount)
        {
            const int FIRST_FLOOR_NUMBER = 1;
            const int LIFT_COUNT = 4;
            Random rnd = new Random();
            List<Lift> lifts = new List<Lift>();
            int[] liftingCapacity = { 200, 200, 400, 400 };
            for (int i =0; i<LIFT_COUNT;i++)
            {
                Lift lift = new Lift(i + 1, rnd.Next(FIRST_FLOOR_NUMBER, floorCount + 1), liftingCapacity[i]);
                lifts.Add(lift);
            }
            return lifts;
        }
        public string Name()
        {
            Random rnd = new Random();
            string[] names = { "Сергей", "Петр", "Борис", "Владислав", "Галя" };
            return names[rnd.Next(0, names.Length)];
        }
        public Location Location()
        {
            Random rnd = new Random();
            Location location;
            const int LOCATION_HOME = 1;
            const int LOCATION_STREET = 2;
            location = (Location)rnd.Next(LOCATION_HOME, LOCATION_STREET + 1);
            return location;
        }
        public Cargo Cargo()
        {
            Random rnd = new Random();
            List<Cargo> cargos = new List<Cargo>
            {
               new Cargo() {name="Чемодан урановых бревен",wt=200},
               new Cargo() {name="Воображаемый друг",wt=0},
               new Cargo() {name="Пять томов большой советской энциклопедии",wt=80},
               new Cargo() {name="Унитаз",wt=20},
               new Cargo() {name="Чувство собственной важности",wt=90},
               new Cargo() {name="Ведерочко ртути",wt=150}
            };
            return cargos[rnd.Next(0, cargos.Count)];
        }
    }
}
