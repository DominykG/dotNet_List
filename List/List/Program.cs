using System;
using System.Threading;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Title = "Teltonika IoS";

        Console.Write("Enter main list lenght: ");
        var input = Console.ReadLine();//string input;
        int len;//lenght of main list

        while (!int.TryParse(input, out len))
        {
            Console.Clear();
            Console.Write("Enter main list lenght: ");
            input = Console.ReadLine();
        }//amount of main list elements

        var rand = new Random();

        var Dict = new Dictionary<int, List<int>>();

        for (int i = 0; i < len; i++)
        {
            int main = rand.Next(999);
            var SubList = new List<int>();
            //int sub = 3;
            int sub = rand.Next(10);//amount of SubList elements

            for (int j = 0; j < sub; j++)
            {
                SubList.Add(rand.Next(999));//filling values of SubList
            }
            Dict.Add(main, SubList);
        }

        Display(Dict);
        Console.Write("Press eny key to continue...");
        Console.ReadKey(true); 

        /*
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
            var SubList = new List<int>();
            int sub = rand.Next(1, 20);//amount of SubList elements
            for (int j = 0; j < sub; j++)
            {
                SubList.Add(rand.Next(1000));//filling values of SubList
            }
            MainList.Add(SubList);
        }
        Display(MainList);
        Console.Write("Press eny key to continue...");
        Console.ReadKey(true);
        */
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

    static void Display(Dictionary<int, List<int>> dict)
    {
        Console.WriteLine("List: ");

        var MainListElem = new List<int>(dict.Keys);//keys to list, basically main list elements
        
        char MainItem = 'A';

        List<int> sublist;

        foreach(var value in MainListElem)
        {
            Console.WriteLine("Item " + MainItem + " " + value);
            char SubItem = 'a';
            dict.TryGetValue(value, out sublist);

            foreach(var val in sublist)
            {
                Console.WriteLine("    Item " + MainItem + SubItem + " " + val);
                SubItem++;
            }
            MainItem++;
        }
    }
}

