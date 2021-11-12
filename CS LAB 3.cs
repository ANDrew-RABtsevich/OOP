using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public partial class Product
    {
        // поля класса
        private readonly int prodID;
        private string prodName;
        private long prodUPC;
        private double prodPrice;
        private string prodLife;
        private int prodAmount;
        static string storeName;    // статическое поле
        private const double dollarExchangeRate = 2.50;   // поле-константа
        static int objAmount;

        // свойства
        public int ProdID => prodID;    // == { get { return prodID; } }

        public string ProdName
        {
            get => prodName;
            set => prodName = value;
        }

        public long ProdUPC
        {
            get => prodUPC;
            private set => prodUPC = value; // ограничение аксессора не дает изменить поле вне класса
        }

        public double ProdPrice
        {
            get => prodPrice;
            set
            {
                do
                {
                    if (value < 0)
                        Console.WriteLine("Цена продукта не может быть меньше нуля. Попробуйте еще раз.");
                    else
                        prodPrice = value;
                } while (value < 0);
            }
        }

        public string ProdLife
        {
            get => prodLife;
            set => prodLife = value;
        }

        public int ProdAmount
        {
            get => prodAmount;
            set
            {
                do
                {
                    if (value < 0)
                        Console.WriteLine("Количество продукта не может быть отрицательным числом. Попробуйте еще раз.");
                    else
                        prodAmount = value;
                } while (value < 0);
            }
        }

        // методы
        public void SomeMethodDoing()
        {
            Console.WriteLine("Sample Text");
        }
        public static void Info()
        {
            Console.WriteLine($"Объектов создано : {objAmount}");
            Console.WriteLine($"Магазин - {storeName}");
        }
        public double GetCostInDollars(out double cost)
        {
            cost = prodPrice / dollarExchangeRate;
            return cost;
        }
        public override int GetHashCode()   // переопределенный метод GetHashCode для класса Product
        {
            return HashCode.Combine(prodName, prodUPC, prodPrice, prodLife, prodAmount);
        }
        public static Product DefConstructor()  //метод, вызывающий закрытый конструктор
        {
            return new Product();
        }
        public double GetSumPrice()
        {
            double sum = prodAmount * prodPrice;
            return sum;
        }
        public double ChangeDisc(ref double disc)
        {
            disc += 1.5;
            return disc;
        }
        public override bool Equals(object obj) //переопределенный метод сравнения двух объектов
        {
            if (obj is Product objectType)
            {
                if (this.prodID == objectType.prodID && this.prodName == objectType.prodName && this.prodUPC == objectType.prodUPC
                        && this.prodPrice == objectType.prodPrice && this.prodLife == objectType.prodLife
                            && this.prodAmount == objectType.prodAmount)
                {
                    return true;
                }
            }
            return false;
        }
        public override string ToString()
        {
            return $"Наименование - {prodName}, ID - {prodID}, UPC- {prodUPC}, цена - {prodPrice} рубля(ей), " +
                $"срок хранения - {prodLife}, количество - {prodAmount}.";
        }

        // конструкторы
        static Product()    // статический конструктор
        {
            storeName = "Рублик";
            Console.WriteLine("Некий товар был создан");
        }
        private Product()    // закрытый конструктор без параметров
        {
            prodName = "Яблоки";
            prodUPC = 374524153788;
            prodPrice = 0.26;
            prodLife = "5 дней";
            prodAmount = 5;
            prodID = GetHashCode();
            objAmount++;
        }
        public Product(string naMe, long u, int amnt)    // конструктор с параметрами
        {
            prodName = naMe;
            prodUPC = u;
            prodAmount = amnt;
            prodID = HashCode.Combine(naMe, u, amnt);  // вычисление хeш на основе инициализаторов
            objAmount++;
        }
        public Product(string n, long u, string l = "14 дней", double price = 1.1)  // конструктор с параметрами по умолчанию
        {
            prodName = n;
            prodUPC = u;
            prodLife = l;
            prodPrice = price;
            prodID = GetHashCode();
            objAmount++;
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            {
                Product apples = Product.DefConstructor();  //создание первого объекта
                Console.WriteLine(apples.ToString());

                Product nails = new Product("Гвозди", 3546452784556, 100);
                Console.WriteLine($"Тип объекта nails - {nails.GetType()}");
                nails.ProdPrice = 0.05;
                Console.WriteLine($"Общая сумма товара {nails.ProdName} составляет {nails.GetSumPrice()}");
                Product milk = new Product("Молоко домашнее", 354655477754);
                Console.WriteLine($"Цена товара {milk.ProdName} в долларах составляет {milk.GetCostInDollars(out _)}");
                Console.WriteLine($"Введите скидку на товар:");
                double discount = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine($"Исходная скидка: {discount}");
                milk.ChangeDisc(ref discount);
                Console.WriteLine($"Скидка после изменения: {discount}");
                Console.WriteLine(apples.Equals(milk) ? "Объекты равны" : "Объекты не равны");
                milk.SomeMethodDoing();
                milk.SomeMethod();
                Product.Info();
                Console.WriteLine(new string('~', 20));
                // 2 задание - массив объектов
                Product[] products = new Product[3] { apples, nails, milk };
                Console.WriteLine("Задание а)вывести список товаров для заданного наименования\nВведите наименование товара");
                string prod = Console.ReadLine();
                bool flag = false;
                int n = 1;
                foreach (Product product in products)
                {
                    if (prod.Equals(product.ProdName))
                    {
                        Console.WriteLine($"{n}. {product.ProdName}");
                        n++;
                        flag = true;
                    }
                }
                if (!flag)
                {
                    Console.WriteLine("Совпадений не найдено.");
                }
                Console.WriteLine("Задание б)вывести список товаров для заданного наименования, цена которых не превышает" +
                    " заданную\nВведите наименование товара");
                prod = Console.ReadLine();
                Console.WriteLine("Введите цену");
                double price = Convert.ToDouble(Console.ReadLine());
                flag = false;
                n = 1;
                foreach (Product product in products)
                {
                    if (prod.Equals(product.ProdName) && product.ProdPrice <= price)
                    {
                        Console.WriteLine($"{n}. {product.ProdName}");
                        n++;
                        flag = true;
                    }
                }
                if (!flag)
                {
                    Console.WriteLine("Совпадений не найдено.");
                }
                // задание 3 - создание анонимного типа
                Console.WriteLine(new string('~', 20));
                var someProd = new { prodName = "Кабачки", prodPrice = 0.5, prodLife = "14 дней" };
                Console.WriteLine($"Тип объекта someProd - {someProd.GetType()}");
                Console.WriteLine($"Наименование товара - {someProd.prodName}, цена составляет {someProd.prodPrice} рублей, " +
                    $"срок хранения составляет {someProd.prodLife}");
                Console.ReadKey();
            }
        }
    }
}