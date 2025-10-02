using System;
using System.Collections.Generic;

namespace Variant14
{
    // Зручний клас для раціонального числа
    public struct RationalNumber
    {
        public long Num { get; private set; }   // чисельник
        public long Den { get; private set; }   // знаменник (завжди > 0)

        public RationalNumber(long num, long den = 1)
        {
            if (den == 0) throw new ArgumentException("Denominator cannot be zero.");
            // нормалізуємо знак в знаменнику
            if (den < 0) { num = -num; den = -den; }
            long g = Gcd(Math.Abs(num), den);
            Num = num / g;
            Den = den / g;
        }

        // додати ціле число
        public static RationalNumber operator +(RationalNumber r, long k)
        {
            return new RationalNumber(r.Num + k * r.Den, r.Den);
        }

        // додати два дроби
        public static RationalNumber operator +(RationalNumber a, RationalNumber b)
        {
            return new RationalNumber(a.Num * b.Den + b.Num * a.Den, a.Den * b.Den);
        }

        public override string ToString()
        {
            if (Den == 1) return Num.ToString();
            return $"{Num}/{Den}";
        }

        // Евклідов алгоритм для НСД
        private static long Gcd(long a, long b)
        {
            if (a == 0) return b;
            while (b != 0)
            {
                long t = a % b;
                a = b;
                b = t;
            }
            return a;
        }
    }

    // Масив дробів з індексатором і оператором ++
    public class FractionArray
    {
        private List<RationalNumber> data;

        public int Length => data.Count;

        public FractionArray(int size)
        {
            if (size < 0) throw new ArgumentException(nameof(size));
            data = new List<RationalNumber>(size);
            for (int i = 0; i < size; i++) data.Add(new RationalNumber(0, 1)); // 0/1
        }

        public FractionArray(IEnumerable<RationalNumber> items)
        {
            data = new List<RationalNumber>(items);
        }

        // Індексатор
        public RationalNumber this[int i]
        {
            get
            {
                if (i < 0 || i >= data.Count) throw new IndexOutOfRangeException();
                return data[i];
            }
            set
            {
                if (i < 0 || i >= data.Count) throw new IndexOutOfRangeException();
                data[i] = value;
            }
        }

        // ++ : додає 1 до всіх дробів (реалізація префіксного і постфіксного через один метод)
        public static FractionArray operator ++(FractionArray arr)
        {
            if (arr == null) throw new ArgumentNullException(nameof(arr));
            for (int i = 0; i < arr.data.Count; i++)
            {
                arr.data[i] = arr.data[i] + 1; // додаємо ціле 1
            }
            return arr;
        }

        public override string ToString()
        {
            return "[" + string.Join(", ", data) + "]";
        }
    }

    class Program
    {
        static void Main()
        {
            // Приклад використання
            var fracs = new FractionArray(new[]
            {
                new RationalNumber(1, 2),
                new RationalNumber(3, 4),
                new RationalNumber(-2, 3)
            });

            Console.WriteLine("Початковий массив: " + fracs);
            // Індексація
            Console.WriteLine($"fracs[1] = {fracs[1]}"); // 3/4

            // Збільшуємо всі дроби на 1 оператором ++
            ++fracs;
            Console.WriteLine("Після ++: " + fracs);

            // Можна змінити елемент через індексатор
            fracs[0] = new RationalNumber(7, 5);
            Console.WriteLine("Після зміни fracs[0]: " + fracs);
        }
    }
}