using System;

namespace CSharpTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите задачу для проверки (1-5) или 0 для выхода:");
                Console.WriteLine("1. Площадь и периметр прямоугольника");
                Console.WriteLine("2. Конвертация валют (рубли в доллары)");
                Console.WriteLine("3. Средняя температура за неделю");
                Console.WriteLine("4. Средний балл 3-х студентов");
                Console.WriteLine("5. Транспонирование матрицы 3x3");
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
                    default: Console.WriteLine("Неверный ввод. Нажмите любую клавишу..."); Console.ReadKey(); break;
                }

                Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
                Console.ReadKey();
            }
        }

        // Задача 1
        static void Task1()
        {
            Console.WriteLine("--- Задача 1: Прямоугольник ---");
            Console.Write("Введите длину прямоугольника: ");
            double length = double.Parse(Console.ReadLine().Replace('.', ','));

            Console.Write("Введите ширину прямоугольника: ");
            double width = double.Parse(Console.ReadLine().Replace('.', ','));

            double area = length * width;
            double perimeter = 2 * (length + width);

            Console.WriteLine($"Площадь: {area}");
            Console.WriteLine($"Периметр: {perimeter}");
        }

        // Задача 2
        static void Task2()
        {
            Console.WriteLine("--- Задача 2: Конвертация валют ---");
            // Для примера возьмем фиксированный курс, или можно запросить его у пользователя
            Console.Write("Введите текущий курс доллара (сколько рублей за 1$): ");
            double rate = double.Parse(Console.ReadLine().Replace('.', ','));

            Console.Write("Введите количество рублей для конвертации: ");
            double rubles = double.Parse(Console.ReadLine().Replace('.', ','));

            double dollars = rubles / rate;
            Console.WriteLine($"{rubles} руб. по курсу {rate} = {dollars:F2} $");
        }

        // Задача 3
        static void Task3()
        {
            Console.WriteLine("--- Задача 3: Средняя температура ---");
            double sum = 0;
            for (int i = 1; i <= 7; i++)
            {
                Console.Write($"Введите температуру для дня {i}: ");
                // Replace используется, чтобы можно было вводить числа с запятой (например, 23,5)
                sum += double.Parse(Console.ReadLine().Replace('.', ','));
            }

            double average = sum / 7;
            Console.WriteLine($"Средняя температура за неделю: {average:F2} градусов.");
        }

        // Задача 4
        static void Task4()
        {
            Console.WriteLine("--- Задача 4: Средний балл студентов ---");
            for (int student = 1; student <= 3; student++)
            {
                Console.WriteLine($"\nВведите 5 оценок для студента {student}:");
                double sum = 0;
                for (int grade = 1; grade <= 5; grade++)
                {
                    Console.Write($"Оценка {grade}: ");
                    sum += double.Parse(Console.ReadLine());
                }
                Console.WriteLine($"Средняя оценка студента {student}: {sum / 5:F2}");
            }
        }

        // Задача 5
        static void Task5()
        {
            Console.WriteLine("--- Задача 5: Транспонирование матрицы ---");
            int[,] matrix = new int[3, 3];

            Console.WriteLine("Введите 3 строки матрицы (по 3 числа через пробел):");
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Строка {i + 1}: ");
                string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < 3; j++)
                {
                    matrix[i, j] = int.Parse(input[j]);
                }
            }

            // Создаем транспонированную матрицу
            int[,] transposed = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    transposed[i, j] = matrix[j, i]; // Меняем столбцы и строки местами
                }
            }

            Console.WriteLine("\nБыло:              Стало:");
            for (int i = 0; i < 3; i++)
            {
                // Вывод исходной матрицы
                for (int j = 0; j < 3; j++) Console.Write($"{matrix[i, j]} ");

                Console.Write("       =>       ");

                // Вывод транспонированной матрицы
                for (int j = 0; j < 3; j++) Console.Write($"{transposed[i, j]} ");

                Console.WriteLine();
            }
        }
    }
}