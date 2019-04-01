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
                    //Dict = SortDictionary(Dict);
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

    static void Display(Dictionary<int, List<int>> dict)
    {
        Console.WriteLine("List: ");

        List<int> MainListElem = new List<int>(dict.Keys);//keys to list, basically main list elements
        
        char MainItem = 'A';

        foreach (int value in MainListElem)
        {
            Console.WriteLine("Item " + MainItem + " " + value);
            char SubItem = 'a';
            dict.TryGetValue(value, out List<int> sublist);

            foreach (int val in sublist)
            {
                Console.WriteLine(" Subitem " + MainItem + SubItem + " " + val);
                SubItem++;
            }
            MainItem++;
        }
    }

    static Dictionary<int, List<int>> GenerateDictionary()
    {
        var dict = new Dictionary<int, List<int>>();
        var rand = new Random();
        
        int len = Input("Enter main list lenght(int): ");//lenght of main list
        
        for (int i = 0; i < len; i++)
        {
            int main = rand.Next(1, 999);//values of MainList
            var SubList = new List<int>();
            int sub = rand.Next(10);//amount of SubList elements

            for (int j = 0; j < sub; j++)
                SubList.Add(rand.Next(1, 999));//values of SubList

            dict.Add(main, SubList);
        }
        return dict;
    }

    static int SumList(List<int> list)
    {
        
        return 0;
    }

    /*static Dictionary<int, List<int>> SortDictionary(Dictionary<int, List<int>> dict)
    {
        var ListToSort = new List<int>();

        var newDict = new Dictionary<int, List<int>>();

        Display(dict);

        var input = Console.ReadLine();

        Console.WriteLine("\nWhatlist You wan to sort?");
        Console.WriteLine("If you want to sort MainList (Type \"m\")\n" +
                          "If you want to sort sublist enter main list element");



        if(input == "m")
        {
            int cou = dict.Count;
            List<int> MainListElem = new List<int>(dict.Keys);
            MainListElem.Sort();
            for(int i = 0; i < cou; i++)
            {
                newDict.Add(MainListElem[i], );
            }
        }


        return newDict;
    }*/

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
}

