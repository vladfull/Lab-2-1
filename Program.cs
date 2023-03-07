using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;



try
{
    // Task 1 variant 15
    //Вивести вміст списку по N елементів в рядку так, щоб висновок
    //відбувався по спіралі, тобто кожен другий рядок повинен
    //виводитись задом наперед.
    do
    {
        Console.WriteLine("Task 1");
        var numList = new List<int>();
        Console.WriteLine("Введіть елементи списку(якщо бажаєте завершити, напишіть 'stop'):");
        while (true)
        {
            string num = Console.ReadLine();
            if (num != "stop")
            {
                numList.Add(int.Parse(num));
            }
            else break;
        }
        Console.Write("Введіть розмір спіралі n: ");
        int n = int.Parse(Console.ReadLine());
        int index = 0;
        List<int> output = new List<int>();
        Console.WriteLine();

        for (int i = 0; i < numList.Count / n; i++)
        {
            if (i % 2 == 0)
            {
                output = numList.GetRange(index, n).ToList();
                foreach (int j in output) Console.Write(j + " ");
                Console.WriteLine();
                index += n;
            }
            else
            {
                output = numList.GetRange(index, n).ToList();
                output.Reverse();
                foreach (int j in output) Console.Write(j + " ");
                index += n;
                Console.WriteLine();
            }
        }
        Console.WriteLine();
        foreach (var i in numList)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
        // Task 2
        //    Дано масив словників.Реалізувати пошук по ключах кожного
        //    словника і вивести кількість знайдених результатів на екран.
        //    Вхідний словник: = [{ 'id': 1, 'success': True, 'name': 'Oleh'}, { 'id': 2, 'success': False, 'name': 'Roma'}, { 'id': 3, 'success': True, 'name': 'Sasha'}]
        //    Вихідний результат: Порахувати скільки словників мають значення success == True
        Console.WriteLine("Task 2");
        bool successful = true;
        bool unsuccessful = false;
        Dictionary<string, object>[] arrayDict = new Dictionary<string, object>[3]
        {
        new Dictionary<string, object>()
        {
            {"id", 1},
            {"success", successful},
            {"name", "Oleh"},
        },
        new Dictionary<string, object>()
        {
            {"id", 2},
            {"success", unsuccessful},
            {"name", "Roma"},
        },
        new Dictionary<string, object>()
        {
            {"id", 3},
            {"success", successful},
            {"name", "Sasha"},
        }
        };
        Console.WriteLine("Введіть значення ключа:");
        string userKey = Console.ReadLine();
        Console.WriteLine("Введіть значення, кількість якого хотіли б перевірити:");
        string userValue = Console.ReadLine();
        int count = 0;
        for (int i = 0; i < arrayDict.Length; i++)
        {
            Console.WriteLine($"Person {i + 1}:");
            foreach (KeyValuePair<string, object> j in arrayDict[i])
            {
                if (j.Key == userKey) Console.WriteLine($"{j.Key}: {j.Value}");
                if (j.Value.ToString() == userValue) count++;
            }
        }
        Console.WriteLine($"Значення {userKey} == {userValue} зустрічалось {count} разів");
        Console.WriteLine("Task 3");
        Random rnd = new Random();
        var linqList = new List<int>();
        Console.WriteLine("Введіть к-сть чисел:");
        int x = int.Parse(Console.ReadLine());
        Console.WriteLine("Введіть діапазон:");
        int diap1 = int.Parse(Console.ReadLine());
        int diap2 = int.Parse(Console.ReadLine());
        for(int i = 0; i < x; i++)
        {
            linqList.Add(rnd.Next(diap1, diap2 + 1));
        }
        Console.WriteLine("Вхідна послідовність:");
        foreach(int i in linqList)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
        Console.WriteLine("Вихідна послідовність:");
        var result = linqList.Where(n => n % 2 != 0).Distinct().ToList();
        foreach (int i in result)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
        Console.Write("Continue?(y/n): ");
        string answear = Console.ReadLine();
        if (answear == "n" | answear == "N") break;
        
    } while(true);
}
catch(FormatException)  
{
    Console.WriteLine("Невірний формат. Спробуйте ще раз");
}