using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Задание 1 - типы данных
            //a - все возможные примитивные типы данных, ввод и вывод через консоль
            sbyte sbyte_var = -101;
            Console.WriteLine($"Значение переменной типа sbyte: {sbyte_var}");
            byte byte_var = 205;
            Console.WriteLine($"Значение переменной типа byte: {byte_var}");
            short short_var = -30000;
            Console.WriteLine($"Значение переменной типа short: {short_var}");
            ushort ushort_var = 60000;
            Console.WriteLine($"Значение переменной типа ushort: {ushort_var}");
            int int_var = -5;
            Console.WriteLine($"Значение переменной типа int: {int_var}");
            uint uint_var = 5u;
            Console.WriteLine($"Значение переменной типа uint: {uint_var}");
            long long_var = -50L;
            Console.WriteLine($"Значение переменной типа long: {long_var}");
            ulong ulong_var = 50ul;
            Console.WriteLine($"Значение переменной типа ulong: {ulong_var}");
            char char_var = 'A';
            Console.WriteLine($"Значение переменной типа char: {char_var}");
            float float_var = 10.1f;
            Console.WriteLine($"Значение переменной типа float: {float_var}");
            double double_var = 100.1d;
            Console.WriteLine($"Значение переменной типа double: {double_var}");
            Console.WriteLine("Введите значение double переменной");
            double double_var2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Значение переменной типа double, введенное через консоль: {double_var}");
            bool bool_var = true;
            Console.WriteLine($"Значение переменной типа bool: {bool_var}");
            decimal decimal_var = 104.33m;
            Console.WriteLine($"Значение переменной типа decimal: {decimal_var}");
            Console.WriteLine("Введите строку");
            string string_var = Console.ReadLine();
            Console.WriteLine($"Значение переменной типа string, введенное через консоль: {string_var}");
            object object_var_float = 567.1F;
            Console.WriteLine($"Значение переменной типа object (float в данном случае): {object_var_float}");
            Console.WriteLine("Введите переменную типа object");
            object object_var = Console.ReadLine();
            Console.WriteLine($"Значение переменной типа object, введенное через консоль: {object_var}");
            Console.WriteLine("...нажмите любую клавишу...");

            Console.Read();

            //b - операции явного и неявного приведения типов
            int_var = (int)char_var;
            int_var = byte_var;
            uint_var = (ushort)char_var;
            uint_var = ushort_var;

            float_var = (float)decimal_var;
            float_var = (float)double_var;
            float_var = byte_var;

            decimal_var = (decimal)short_var;
            decimal_var = int_var;
            decimal somevar1 = (decimal)short_var;
            decimal somevar2 = int_var;

            ushort_var = (ushort)sbyte_var;
            ushort_var = char_var;
            int some = 20;
            bool b = Convert.ToBoolean(some);
            Console.WriteLine($"Приведение типов с помощью класса Convert\n было: {some}    -   стало: {b}");
            Console.WriteLine("...нажмите любую клавишу...\n");
            Console.Read();
            Console.Read();
            //c - упаковка и распаковка значимых типов
            int variable1 = 10;
            object o = variable1; //Упаковка
            int variable2 = (int)o; //Распаковка 
            //d - неявная типизация
            var variable = 99;
            int sum = 101 + variable;
            Console.WriteLine($"Сумма {variable} и 101 равна {sum}");
            Console.ReadLine();
            //e - работа с Nullable переменной
            int? i1 = 5;
            Nullable<int> ii = 7;
            int? i2 = null;
            /*1)Проверка на равенство*/
            Console.WriteLine(i1 == i2 ? "Переменная i1 равна i2" : "Переменная i1 не равна i2");
            /*2)Преобразование*/
            if (i1.HasValue)
            {
                char i3 = (char)i1;
            }
            /*3)null-объединение*/
            Console.WriteLine($"{i1 ?? 2}; {i2 ?? 10}");
            /*Метод GetValueOrDefault()*/
            Console.WriteLine($"Метод GetValueOrDefault() возвращает значение Nullable переменной или значение переменной данного типа " +
                $"по умолчанию:\nпеременная i1 — {i1.GetValueOrDefault()}; переменная i2 — {i2.GetValueOrDefault()}");
            Console.WriteLine("...нажмите любую клавишу...");
            Console.ReadLine();
            //f - var error?
            var someVar = 100;
            char someInt = 'n';
            someVar = someInt;
            //Задание 2 - строки
            //a - сравнение строковых литералов
            Console.WriteLine(String.Equals("Oh", "Ho") ? $"Строковый литерал 1 равен строковому литералу 2" :
                $"Строковый литерал 1 не равен строковому литералу 2");
            Console.ReadLine();
            //b - строки на основе String и операции над ними
            string string1 = new string('e', 5);
            string string2 = new string(new char[] { 'h', 'e', 'l', 'l', 'o', ' ', 'w', 'o', 'r', 'l', 'd' });
            string string3 = new string('!', 3);
            string string4 = string.Concat(string2, string3);//сцепление
            string string5 = string.Copy(string1);//копирование
            string string6 = string2.Substring(0, 2);//выделение подстроки
            string[] words = string2.Split(new char[] { ' ' });//разделение строки на слова
            string string7 = string1.Insert(2, string6);//вставка подстроки в заданную позицию
            string string8 = string1.Replace(string6, "");//удаление заданной подстроки
            Console.WriteLine($"Строки до сцепления: \n{string2}\n{string3}\nРезультирующая строка: {string4}");
            Console.ReadLine();
            Console.WriteLine($"Копируемая строка: {string1}\nКопия строки: {string5}");
            Console.ReadLine();
            Console.WriteLine($"Строка-оригинал: {string2}\nВыделенная подстрока: {string6}");
            Console.ReadLine();
            Console.WriteLine($"Строка до разделения на слова: {string2}\nСлова в этой строке:");
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
            Console.ReadLine();
            Console.WriteLine($"Первоначальная строка: {string1}\nСтрока после вставки в первоначальную строку подстроки {string6}:\n" +
                $"{string7}");
            Console.ReadLine();
            Console.WriteLine($"Строка с подстрокой: {string7}\nСтрока с удаленной подстрокой {string6}: {string8}");
            Console.ReadLine();
            //c - пустые и null строки
            string null_string = null;
            string emp_string = "";
            Console.WriteLine($"Значение строки 1 равно {null_string}; значение строки 2 равно: {emp_string}.");
            Console.WriteLine(string.IsNullOrEmpty(null_string) ? "Строка 1 пустая или имеет значение null" :
                "Строка 1 не пустая и не имеет значение null");
            Console.WriteLine(string.IsNullOrEmpty(emp_string) ? "Строка 2 пустая или имеет значение null" :
                "Строка 2 не пустая и не имеет значение null");
            Console.WriteLine($"Длина строки 2 равна {emp_string.Length}");
            Console.WriteLine(emp_string == string.Empty ? "Строка 2 пустая" : "Строка 2 не пустая");
            Console.ReadLine();
            //d - StringBuilder
            StringBuilder myStr = new StringBuilder("lolomg");
            Console.WriteLine($"Первоначальная строка: {myStr}");
            myStr.Remove(3, 3);//удаление определенных позиций
            Console.WriteLine($"Строка после удаления позиций: {myStr}");
            myStr.Append("!");//добавление в конец
            myStr.Insert(0, "?");//добавление на заданную позицию
            Console.WriteLine($"Строка после вставки символов в начало и в конец: {myStr}");
            Console.ReadLine();
            //Задание 3 - массивы 
            //a - матрица
            Console.WriteLine("\nМатрица:");
            int[,] arr = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int rows = arr.GetUpperBound(0) + 1;
            int cols = arr.GetUpperBound(1) + 1;
            for (int y = 0; y < rows; y++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{arr[y, j]}\t");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
            //b - одномерный массив строк
            string[] array = { "съешь еще", "этих мягких", "французских булок" };
            Console.WriteLine("Одномерный массив строк:");
            foreach (string el in array)
            {
                Console.WriteLine(el);
            }
            Console.WriteLine($"Длина массива строк равна {array.Length}");
            int n;
            do
            {
                Console.Write("Введите номер элемента: ");
                n = int.Parse(Console.ReadLine());
                if ((n > array.Length) || (n < 1))
                {
                    Console.WriteLine("Такого элемента нет. Повторите попытку");
                }
            } while ((n > array.Length) || (n < 1));
            Console.Write("Введите новое значение элемента: ");
            string new_ = Console.ReadLine();
            Console.WriteLine($"Изначальное значение элемента {n} - {array[n - 1]}");
            array[n - 1] = new_;
            Console.WriteLine($"Новое значение элемента {n} - {array[n - 1]}");
            Console.ReadLine();
            //c - ступенчатый массив
            Console.WriteLine("Заполнение ступенчатого массива:");
            float[][] arrayOfFloat = new float[][] { new float[2], new float[3], new float[4] };
            for (int f = 0; f < arrayOfFloat.Length; f++)
            {
                Console.WriteLine($"{f + 1}-я строка({arrayOfFloat[f].Length} вещественных числа):");
                for (int j = 0; j < arrayOfFloat[f].Length; j++)
                {
                    arrayOfFloat[f][j] = float.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine("Вывод массива:");
            foreach (float[] row in arrayOfFloat)
            {
                foreach (float el in row)
                {
                    Console.Write($"{el} \t");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
            //d - неявно типизированные переменные для хранения массива и строки
            var s = "Хто я?";
            Console.WriteLine($"s — {s.GetType()}");
            var mas = new[] { 1, 2, 3 };
            Console.WriteLine($"mas — {mas.GetType()}");
            Console.ReadLine();
            //Задание 4 - кортежи
            //a - задать кортеж из 5 элементов 
            ValueTuple<int, string, char, string, ulong> tuple1 = (10, "uwu", 'e', "owo", 42ul);
            (int, string, char, string, ulong) tuple2 = (10, "uwu", 'e', "owo", 42ul);
            var tuple3 = (10, "uwu", 'e', "owo", 42ul);
            //b - вывод кортежа
            Console.WriteLine("Вывод кортежа полностью: {0}, {1}, {2}, {3}, {4}", tuple1.Item1, tuple1.Item2, tuple1.Item3, tuple1.Item4,
                tuple1.Item5);
            Console.WriteLine($"Вывод кортежа частично:\n1-й элемент: {tuple1.Item1}; 3-й элемент: {tuple1.Item3}; 4-й элемент: " +
                $"{tuple1.Item4}");
            Console.ReadLine();
            //d - распаковка кортежа
            var (first_var, sec_var, third_var, fourth_var, fifth_var) = tuple2;
            Console.WriteLine($"Распакованные в переменные элементы кортежа: {first_var}, {sec_var}, {third_var}, {fourth_var}, " + $"{fifth_var}");

            int intVar; string stringVar1; char charVar; string stringVar2; ulong ulongVar;
            (intVar, _, charVar, stringVar2, _) = tuple3;
            //e - сравнение двух кортежей
            Console.WriteLine(Object.Equals(tuple1, tuple2) ? "Кортежи равны" : "Кортежи не равны");
            Console.ReadLine();
            //Задание 5 - локальная функция
            int[] mass = new int[] { 1, 1, 5, 8, 3, 9, 4, 12 };
            string str = "Хорошая строка";
            var Tuple = Func(mass, str);
            Console.WriteLine($"Функция возвращает кортеж:\nминимальный элемент массива: {Tuple.Item1}\nмаксимальный элемент массива: " +
                $"{Tuple.Item2}\nсумма элементов массива: {Tuple.Item3}\nпервая буква строки: {Tuple.Item4}");
            Console.ReadLine();
            (int, int, int, string) Func(int[] m, string st)
            {
                int min = m.Min();
                int max = m.Max();
                int summ = m.Sum();
                string letter = st.Substring(0, 1);
                return (min, max, summ, letter);
            }
            //Задание 6 - checked/unchecked
            int one = 1;
            int Func1()
            {
                checked //генерирует ошибку OverflowException при переполнении
                {
                    int int1 = 2147483647 + one;
                    return int1;
                }
            }
            int Func2()
            {
                unchecked // при переполнении представляет число со знаком минус
                {
                    int int2 = 2147483647 + one;
                    return int2;
                }
            }
            Console.WriteLine(Func1());
            Console.WriteLine(Func2());
            Console.ReadKey();
        }
    }
}