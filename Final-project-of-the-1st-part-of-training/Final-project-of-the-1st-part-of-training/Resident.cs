using System;
using System.Collections.Generic;
using System.Text;
public enum Location
{
    home=1,
    street
}
public struct Cargo
{
    public string name;
    public int wt;
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
        public Flat Flat
        { get; private set; }
        public Cargo Cargo
        { get; private set; }
        public Resident(int wt, string name,Location location)
        {
            Name = name;
            Wt = wt;
            Location = location;
        }
        public void PutInAnFlat(Flat flat)
        {
            Flat = flat;
        }
        public void ChangeLocation(Location location)
        {
            Location = location;
        }
        public void AddCargo(Cargo cargo)
        {
            Cargo = cargo;
        }
        public void Print ()
        {
            string location;
            if (Location == Location.home)
            {
                location = "находится дома";
            }
            else
            {
                location = "рыщет по улице в поисках новой жертвы";
            }
            Console.WriteLine("Житель {0} квартиры {1} {2}.",Name,Flat.Number,location);
        }
        public void SortPrintListResident(List<Resident>residents, int floorCount)
        {
            List<List<Resident>> sortResidents = new List<List<Resident>>();
            for()
            foreach(Resident nextResident in residents)
            {

            }
        }
    }
}
