using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            Document document1 = new Document("ОАО \"Только вместе мы большая сила\"", 11, 11, 2021, true);
            document1.Burning();    // вызывается метод абстрактного класса
            ((IManipulate)document1).Burning(); // вызывается метод интерфейса
            Console.WriteLine(document1.ToString());
            Receipt receipt1 = new Receipt("ООО \"Белгород\"", 12, 12, 2020, true, "квитанция");
            Console.WriteLine(receipt1.ToString());
            Check check1 = new Check("ООО \"Белгород\"", 11, 9, 2020, true, "чек");
            Invoice invoice1 = new Invoice("ООО \"Белгород\"", 10, 10, 2020, true, "накладная");
            //оператор is проверяет, может ли переменная быть преобразована в указанный тип, возвращает bool
            Console.WriteLine($"invoice1 {(invoice1 is int ? "" : "не")} может быть преобразована в int");
            Console.WriteLine($"invoice1 {(invoice1 is object ? "" : "не")} может быть преобразована в object");
            IManipulate doc = invoice1 as IManipulate;
            Console.WriteLine($"Преобразование Invoice в Document {((doc != null) ? "" : "не")} завершено");
            Console.WriteLine(invoice1 is IManipulate ? "invoice1 является ссылкой на IManipulate" :
                "invoice1 не является ссылкой на IManipulate");

            Console.WriteLine("``````````Printer`````````");
            Console.WriteLine("`````````Printer`````````");
            Printer printer = new Printer();
            Organization[] organizationsArray = new Organization[] { document1, receipt1, invoice1, check1 };
            foreach (var one in organizationsArray)
            {
                printer.IAmPrinting(one);
            }
            Console.ReadKey();
        }
    }
}