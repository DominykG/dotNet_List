using System;
using System.Threading;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Title = "Teltonika IoS";
        var MainList = new List<List<int>>();

        Console.Write("Enter main list lenght: ");
        var input = Console.ReadLine();//string input;
        int len;//lenght of main list
        var rand = new Random();

        while (!int.TryParse(input, out len))
        {
            Console.Clear();
            Console.Write("Enter main list lenght: ");
            input = Console.ReadLine();
        }//amount of main list elements

        for (int i = 0; i < len; i++)
        {
            var sublist = new List<int>();
            int top = rand.Next(1, 20);//amount of sublist elements
            for (int j = 0; j < top; j++)
            {
                sublist.Add(rand.Next(1000));//filling values of sublist
            }
            MainList.Add(sublist);
        }
        Display(MainList);
        Console.Write("Press eny key to continue...");
        Console.ReadKey(true);
    }

    static void Menu()
    {
        Console.WriteLine("1 ");
    }

    static void Display(List<List<int>> list)
    {
        Console.WriteLine("List: ");
        foreach(var sublist in list)
        {
            foreach(var value in sublist)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();
        }
    }
}

