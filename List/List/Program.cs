using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Title = "Teltonika IoS";
        
        Menu();

        //Dictionary<int, List<int>> Dict = GenerateDictionary();

        //Display(Dict);
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

            //int cou = Dict.Count;                   

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
                case 0:
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
        const int MainMax = 1001;//Max amount of main list elements
        int len;
        int main;

        do
        {
            len = Input("Enter main list lenght(int, Max = 1000 ): ");//lenght of main list\
            Console.Clear();
        } while (len >= MainMax);
        
        for (int i = 0; i < len; i++)
        {
            do
            {
                main = rand.Next(1, MainMax);//generate values of MainList
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
            Console.Clear();
            Console.Write(msg);
            stringinp = Console.ReadLine();
        }

        Console.WriteLine();

        return intinp;
    }

    static Dictionary<int, List<int>> SortDictionary(Dictionary<int, List<int>> dict)
    {
        var newDict = new Dictionary<int, List<int>>();

        Display(dict);

        Console.WriteLine("\nWhatlist You wan to sort?\n" +
                          "If you want to sort MainList type \"m\"\n" +
                          "If you want to sort sublist type \"s\"");
        string input1 = Console.ReadLine();

        while(true)
        {
            if (input1 == "m" || input1 == "s")
                break;

            Console.WriteLine("Wrong input! Please try again.\n\n" +
                              "Whatlist You wan to sort?\n" +
                              "If you want to sort MainList type \"m\"\n" +
                              "If you want to sort sublist type \"s\"");
            input1 = Console.ReadLine();
            Console.Clear();
        }
        
        if(input1 == "m")
        {
            int cou = dict.Count;
            List<int> MainListElem = new List<int>(dict.Keys);
            MainListElem.Sort();
            for(int i = 0; i < cou; i++)
            {
                newDict.Add(MainListElem[i], dict[MainListElem[i]]);
            }

            return newDict;
        }

        if(input1 == "s")
        {
            int input2 = Input("Input main list value for sublist you want to sort: ");
            dict[input2].Sort();
            return dict;
        }

        return dict;
    }

    static int SumList(List<int> list)
    {
        
        return 0;
    }
}

