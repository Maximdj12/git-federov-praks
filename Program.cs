using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpTasks2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Включаем поддержку кириллицы в консоли для корректного отображения
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите задачу (1-5) или 0 для выхода:");
                Console.WriteLine("1. Массив: обратный порядок и число, близкое к среднему");
                Console.WriteLine("2. Двумерный массив оценок студентов");
                Console.WriteLine("3. Массив до первого повторения");
                Console.WriteLine("4. Телефонная книга (Словарь)");
                Console.WriteLine("5. Подсчет слов (Словарь)");
                Console.Write("Ваш выбор: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1": Task1(); break;
                    case "2": Task2(); break;
                    case "3": Task3(); break;
                    case "4": Task4(); break;
                    case "5": Task5(); break;
                    case "0": return;
                    default: Console.WriteLine("Неверный ввод."); break;
                }

                Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
                Console.ReadKey();
            }
        }

        // Задача 1
        static void Task1()
        {
            Console.WriteLine("--- Задача 1 ---");
            Console.Write("Введите размер массива N: ");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            double sum = 0;

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Введите элемент {i}: ");
                arr[i] = int.Parse(Console.ReadLine());
                sum += arr[i];
            }

            double average = sum / n;
            Console.WriteLine($"\nСреднее арифметическое: {average:F2}");

            // Поиск ближайшего к среднему
            int closest = arr[0];
            for (int i = 1; i < n; i++)
            {
                if (Math.Abs(arr[i] - average) < Math.Abs(closest - average))
                {
                    closest = arr[i];
                }
            }
            Console.WriteLine($"Число, максимально близкое к среднему: {closest}");

            // Вывод в обратном порядке
            Console.Write("Массив в обратном порядке: ");
            for (int i = n - 1; i >= 0; i--)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        // Задача 2
        static void Task2()
        {
            Console.WriteLine("--- Задача 2 ---");
            Console.Write("Введите количество студентов (p): ");
            int p = int.Parse(Console.ReadLine());
            Console.Write("Введите количество предметов (m): ");
            int m = int.Parse(Console.ReadLine());

            int[,] grades = new int[p, m];

            for (int i = 0; i < p; i++)
            {
                Console.WriteLine($"\nВвод оценок для студента {i + 1}:");
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"Предмет {j + 1}: ");
                    grades[i, j] = int.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("\nСредние значения:");
            for (int i = 0; i < p; i++)
            {
                double sum = 0;
                for (int j = 0; j < m; j++)
                {
                    sum += grades[i, j];
                }
                Console.WriteLine($"Студент {i + 1}: {(sum / m):F2}");
            }
        }

        // Задача 3
        static void Task3()
        {
            Console.WriteLine("--- Задача 3 ---");
            List<int> numbers = new List<int>();

            while (true)
            {
                Console.Write("Введите число (ввод остановится при повторе): ");
                int num = int.Parse(Console.ReadLine());

                if (numbers.Contains(num))
                {
                    Console.WriteLine($"Число {num} уже есть в массиве. Завершение.");
                    break;
                }

                numbers.Add(num);
            }

            Console.Write("Полученный массив: ");
            Console.WriteLine(string.Join(", ", numbers));
        }

        // Задача 4
        static void Task4()
        {
            Console.WriteLine("--- Задача 4: Телефонная книга ---");
            Dictionary<string, string> phoneBook = new Dictionary<string, string>();

            while (true)
            {
                Console.WriteLine("\nДоступные команды: 'добавить', 'поиск', 'просмотр', 'выход'");
                Console.Write("Введите команду: ");
                string command = Console.ReadLine().ToLower();

                if (command == "выход") break;

                switch (command)
                {
                    case "добавить":
                        Console.Write("Введите имя: ");
                        string name = Console.ReadLine();
                        Console.Write("Введите номер телефона: ");
                        string phone = Console.ReadLine();
                        phoneBook[name] = phone; // Добавляет или обновляет
                        Console.WriteLine("Контакт сохранен.");
                        break;

                    case "поиск":
                        Console.Write("Введите имя для поиска: ");
                        string searchName = Console.ReadLine();
                        if (phoneBook.TryGetValue(searchName, out string foundPhone))
                            Console.WriteLine($"Номер {searchName}: {foundPhone}");
                        else
                            Console.WriteLine("Контакт не найден.");
                        break;

                    case "просмотр":
                        Console.WriteLine("Все контакты:");
                        foreach (var contact in phoneBook)
                        {
                            Console.WriteLine($"{contact.Key}: {contact.Value}");
                        }
                        break;

                    default:
                        Console.WriteLine("Неизвестная команда.");
                        break;
                }
            }
        }

        // Задача 5
        static void Task5()
        {
            Console.WriteLine("--- Задача 5: Словарь {string:int} ---");
            Dictionary<string, int> inventory = new Dictionary<string, int>();

            Console.WriteLine("Вводите названия предметов (например, 'яблоко', 'банан').");
            Console.WriteLine("Для выхода введите 'стоп'.");

            while (true)
            {
                Console.Write("\nВведите слово: ");
                string word = Console.ReadLine().ToLower();

                if (word == "стоп") break;

                // Логика: если есть - увеличиваем счетчик, если нет - создаем с 1
                if (inventory.ContainsKey(word))
                {
                    inventory[word]++;
                }
                else
                {
                    inventory[word] = 1;
                }

                // Выводим текущее состояние словаря для наглядности
                Console.Write("Текущий словарь: { ");
                foreach (var item in inventory)
                {
                    Console.Write($"{item.Key}:{item.Value} ");
                }
                Console.WriteLine("}");
            }
        }
    }
}