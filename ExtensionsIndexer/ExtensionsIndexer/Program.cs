using System;

namespace ExtensionsIndexer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Library library = new Library();

            //Book book1 = new Book("Xemse", 150);
            //library[102] = book1;
            //Console.WriteLine(library[0]);

            //string str = "Test";
            //Console.WriteLine(str.IsFirstCharUpper());

            //int value = 10;
            //Console.WriteLine(value.GetPower(2));

            int[] array = { 2, 4, 5, 6, 3, 4, 5, 7, 8 };
            int[] myNewArray = array.EventNumbers();
            foreach (var item in myNewArray)
            {
                Console.WriteLine(item);
            }
        }
    }

    #region Indexer

    public class Library
    {
        private Book[] books;

        public Library()
        {
            books = new Book[100];
        }

        public Book this[int index]
        {
            get
            {

                return books[index];
            }
            set
            {
                try
                {
                    books[index] = value;
                }
                catch (Exception)
                {
                    Console.WriteLine("Index was outside bound range.");
                }
            }
        }
    }

    public class Book
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public Book(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return Name + ": " + Price;
        }
    }

    #endregion

    #region Extension methods

    public static class Extensions
    {
        public static bool IsFirstCharUpper(this string value)
        {
            return char.IsUpper(value, 0);
        }

        public static bool IsGreaterThan(this int value, int value1)
        {
            return value > value1;
        }

        public static double GetPower(this int value, int value1)
        {
            return Math.Pow(value, value1);
        }

        #region Task

        public static int[] EventNumbers(this int[] array)
        {
            int[] newArray = new int[array.Length];

            int index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    newArray[index] = array[i];
                    index++;
                }
            }

            Array.Resize(ref newArray, index);
            return newArray;
        }

        #endregion
    }

    #endregion


}
