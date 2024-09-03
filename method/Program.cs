using System;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using System.IO;

namespace method
{
    

    class Program
    {
        static void Main(string[] args)
        {
            string file = @"D:\L3-204SKOCHIK\cdev_Text.txt"; // количество элементов для вставки

            if (!File.Exists(file))
            {
                Console.WriteLine("Файл не найден.");
                return;
            }

            // Считайте количество строк в файле
            string[] lines = File.ReadAllLines(file);
            int numberOfElements = lines.Length; // количество элементов для вставки

            // Сравнение для List<T>
            List<int> list = new List<int>();
            Stopwatch listStopwatch = new Stopwatch();

            // Вставка в начало
            listStopwatch.Start();
            for (int i = 0; i < numberOfElements; i++)
            {
                list.Insert(0, i);
            }
            listStopwatch.Stop();
            Console.WriteLine($"List<T>: Вставка в начало заняла {listStopwatch.ElapsedMilliseconds} ms");

            // Вставка в середину
            list.Clear();
            listStopwatch.Reset();
            listStopwatch.Start();
            for (int i = 0; i < numberOfElements; i++)
            {
                list.Insert(list.Count / 2, i);
            }
            listStopwatch.Stop();
            Console.WriteLine($"List<T>: Вставка в середину заняла {listStopwatch.ElapsedMilliseconds} ms");

            // Вставка в конец
            list.Clear();
            listStopwatch.Reset();
            listStopwatch.Start();
            for (int i = 0; i < numberOfElements; i++)
            {
                list.Add(i);
            }
            listStopwatch.Stop();
            Console.WriteLine($"List<T>: Вставка в конец заняла {listStopwatch.ElapsedMilliseconds} ms");

            // Сравнение для LinkedList<T>
            LinkedList<int> linkedList = new LinkedList<int>();
            Stopwatch linkedListStopwatch = new Stopwatch();

            // Вставка в начало
            linkedListStopwatch.Start();
            for (int i = 0; i < numberOfElements; i++)
            {
                linkedList.AddFirst(i);
            }
            linkedListStopwatch.Stop();
            Console.WriteLine($"LinkedList<T>: Вставка в начало заняла {linkedListStopwatch.ElapsedMilliseconds} ms");

            // Вставка в середину
            linkedList.Clear();
            linkedListStopwatch.Reset();
            linkedListStopwatch.Start();
            LinkedListNode<int> middleNode = null;
            for (int i = 0; i < numberOfElements; i++)
            {
                if (i == 0)
                {
                    linkedList.AddFirst(i);
                    middleNode = linkedList.First;
                }
                else
                {
                    middleNode = GetMiddleNode(linkedList);
                    linkedList.AddAfter(middleNode, i);
                }
            }
            linkedListStopwatch.Stop();
            Console.WriteLine($"LinkedList<T>: Вставка в середину заняла {linkedListStopwatch.ElapsedMilliseconds} ms");

            // Вставка в конец
            linkedList.Clear();
            linkedListStopwatch.Reset();
            linkedListStopwatch.Start();
            for (int i = 0; i < numberOfElements; i++)
            {
                linkedList.AddLast(i);
            }
            linkedListStopwatch.Stop();
            Console.WriteLine($"LinkedList<T>: Вставка в конец заняла {linkedListStopwatch.ElapsedMilliseconds} ms");
        }

        // Метод для поиска узла в середине списка
        static LinkedListNode<int> GetMiddleNode(LinkedList<int> list)
        {
            var current = list.First;
            int middleIndex = list.Count / 2;
            for (int i = 0; i < middleIndex; i++)
            {
                current = current.Next;
            }
            return current;
        }
    }   
}
