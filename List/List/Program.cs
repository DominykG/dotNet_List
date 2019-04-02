using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Title = "Teltonika IoS";
        
        Menu();

        Console.Write("\nPress eny key to continue...");
        Console.ReadKey(true); 
    }

    private static int Menu()
    {
        Dictionary<int, List<int>> Dict = GenerateDictionary();

        while(true)
        {
            Console.WriteLine("1. Generate new list with sublists");
            Console.WriteLine("2. Display list and sublists");
            Console.WriteLine("3. Sort chosen list elements");
            Console.WriteLine("4. Sum chosen list elements");
            Console.WriteLine("0. Exit");
                       
            int choice = Input("Enter choice(int): ");               

            switch (choice)
            {
                case 1:
                    Dict.Clear();
                    Dict = GenerateDictionary();
                    break;
                case 2:
                    Display(Dict);
                    break;
                case 3:
                    Dict = SortDictionary(Dict);
                    break;
                case 4:
                    SumList(Dict);
                    break;
                case 0:
                    Dict.Clear();
                    return 0;

                default:
                    Console.WriteLine("Wrong input!");
                    break;
            }

            Console.Write("\nPress eny key to continue...");
            Console.ReadKey(true);
            Console.Clear();
        }
    }

    static Dictionary<int, List<int>> GenerateDictionary()
    {
        var dict = new Dictionary<int, List<int>>();
        var rand = new Random();
        const int MainMax = 10;//Max amount of main list elements
        int len = rand.Next(1, MainMax);//length
        int main;
        
        for (int i = 0; i < len; i++)
        {
            do
            {
                main = rand.Next(1, MainMax * 10);//generate values of MainList
            }while (dict.ContainsKey(main));

            var SubList = new List<int>();
            int sub = rand.Next(15);//generate amount of SubList elements

            for (int j = 0; j < sub; j++)
                SubList.Add(rand.Next(1, 1000));//generate values of SubList

            dict.Add(main, SubList);
        }
        return dict;
    }

    static void Display(Dictionary<int, List<int>> dict)
    {
        Console.WriteLine("List: ");

        List<int> MainListElem = new List<int>(dict.Keys);//keys to list, basically main list elements

        foreach (int value in MainListElem)
        {
            Console.WriteLine("Item " + value);
            dict.TryGetValue(value, out List<int> sublist);

            foreach (int val in sublist)
            {
                Console.WriteLine(" Subitem " + val);
            }
        }
    }

    static int Input(string msg)
    {
        Console.Write(msg);
        var stringinp = Console.ReadLine();
        int intinp;

        while (!int.TryParse(stringinp, out intinp))
        {
            Console.Write(msg);
            stringinp = Console.ReadLine();
        }

        Console.WriteLine();

        return intinp;
    }

    static Dictionary<int, List<int>> SortDictionary(Dictionary<int, List<int>> dict)
    {
        List<int> AcceptableInputs = new List<int>{-2, -1, 0, 1, 2};

        Display(dict);
        
        int WhatToSort;
        do
        {
            WhatToSort = Input("\nWhatlist You wan to sort?\n" +
                          "If you want to sort MainList type \"1\" ascending, \"-1\" descending\n" +
                          "If you want to sort sublist type \"2\" ascending, \"-2\" descending\n" +
                          "If you want to cancel type \"0\"");
        } while (!AcceptableInputs.Contains(WhatToSort));

        if (WhatToSort == 1 || WhatToSort == -1)
        {
            var newDict = new Dictionary<int, List<int>>();
            List<int> MainListElem = new List<int>(dict.Keys);
            int cou = dict.Count;

            MainListElem.Sort();

            if (WhatToSort == -1)
                MainListElem.Reverse();

            for(int i = 0; i < cou; i++)
            {
                newDict.Add(MainListElem[i], dict[MainListElem[i]]);
            }

            return newDict;
        }

        if(WhatToSort == 2 || WhatToSort == -2)
        {
            int ChooseSubList;

            do
            {
                ChooseSubList = Input("Input main list value for sublist you want to sort: ");
            } while (!dict.ContainsKey(ChooseSubList));

            dict[ChooseSubList].Sort();

            if(WhatToSort == -2)
                dict[ChooseSubList].Reverse();

            return dict;
        }

        else
        {
            return dict;
        }
    }

    static void SumList(Dictionary<int, List<int>> dict)
    {
        List<int> AcceptableInputs = new List<int> { 0, 1, 2 };

        Display(dict);

        int WhatToSum;
        do
        {
            WhatToSum = Input("\nWhatlist You wan to sort?\n" +
                          "If you want to sum MainList type \"1\"\n" +
                          "If you want to sum sublist type \"2\"\n" +
                          "If you want to cancel type \"0\"");
        } while (!AcceptableInputs.Contains(WhatToSum));

        if (WhatToSum == 1)
        {
            List<int> MainListElem = new List<int>(dict.Keys);
            int mainSum = 0;

            foreach(var elem in MainListElem)
            {
                mainSum += elem;
            }

            Console.WriteLine("Sum of MainList is " + mainSum);
        }

        if (WhatToSum == 2)
        {
            int ChooseSubList;
            int subSum = 0;

            do
            {
                ChooseSubList = Input("Input main list value for sublist you want to sort: ");
            } while (!dict.ContainsKey(ChooseSubList));

            foreach (var elem in dict[ChooseSubList])
            {
                subSum += elem;
            }

            Console.WriteLine("Sum of SubList is " + subSum);
        }
    }
}

