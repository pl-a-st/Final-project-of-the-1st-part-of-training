﻿using System;
using System.Collections.Generic;

namespace Final_project_of_the_1st_part_of_training
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Существует парадная на K этажей. K вводится с клавиатуры. Предполагается, что в этой парадной имеется лифта разной грузоподъемности: " +
                "2 мелких на 200 кг, и 2 грузовых на 400 кг. На каждом этаже есть по 4 квартиры, в каждой живет от 0 до 5 жителей (генерируется). " +
                "Находится ли житель дома или вне дома на старте - тоже генерируется.   Программа представляет собой меню для пользователя со следующими пунктами: " +
                "1. Имитировать вызов лифта 2. Показать где находятся жильцы 3. Выход.   С выходом - всё понятно. Программа заканчивается. " +
                "Показать где находятся жильцы - вывести сообщение о том, дома ли находятся люди, проживающие на каждом этаже и где их и сколько." +
                " Имитировать вызов лифта. Берется рандомный житель, которому надо куда-то доехать. Если он находится вне дома, то он едет к себе домой на этаж. " +
                "Если же он дома - он едет вниз до первого. Для каждой поездки генерируется масса, вдруг житель решил ехать с креслом и т.д. К жителю приезжает ближайший к нему лифт. " +
                "Изначальное положение лифтов относительно этажей - случайное. Если житель по массе не помещается в лифт, он оставляет этот лифт на своем этаже и вызывает следующий," +
                " пока не уедет на грузовом. После каждой поездки нужно выводить сообщение где находится какой лифт, куда приехал жилец и из какой он квартиры.");
            Console.Write("Введите число этажей: ");
            int floorCount = Convert.ToInt32(Console.ReadLine());
            Generate generate = new Generate();
            List<Flat> flats = generate.ListFlats(floorCount);
            List<Resident> residents = generate.ListResidets(flats);
            List<Lift> lifts = generate.ListLift(floorCount);
            LiftSet liftSet = new LiftSet(lifts);
            Menu(liftSet, flats, residents, floorCount);

        }
        static void Menu(LiftSet liftSet, List<Flat> flats, List<Resident> residents, int floorCount)
        {
            Generate generate = new Generate();
            Console.WriteLine("");
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Имитировать вызов лифта.");
            Console.WriteLine("2. Показать где находятся жильцы.");
            Console.WriteLine("3. Выход.");
            Console.Write("Введите номер пунта меню:");
            string menuItem = Console.ReadLine();
            if (menuItem == "1")
            {
                Random rnd = new Random();
                liftSet.CallLiftCalculateSendPrint(flats, residents[rnd.Next(0,residents.Count+1)]);
                Menu(liftSet, flats, residents, floorCount);
            }
            if (menuItem == "2")
            {
                residents[0].SortPrintListResident(residents,floorCount);
                Menu(liftSet, flats, residents, floorCount);
            }
            if (menuItem == "3")
            {
                Environment.Exit(0);
            }
            Console.WriteLine("Вы ввели значение не из меню.");
            Menu(liftSet, flats, residents, floorCount);
        }

    }
}
