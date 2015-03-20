using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using Sea_Fight_Yabl;

namespace Sea_Fight_Yabl
{
    internal class Program
    {
        private static void Main()
        {
            int X1 = 10, X2 = 40, Y = 10, L = 11;

            Rectangl G = new Rectangl(X1, Y, L);
            G.Border();
            Rectangl C = new Rectangl(X2, Y, L);
            C.Border();
            ABC a = new ABC();
            Flotilla A = new Flotilla();
            Hashtable Kod = new Hashtable();
            
            while (true)
            {
                Console.Clear();
                G.Border();
                C.Border();
                int n = 0;
                char c;
                int b = 0;
                for (int i = 0; i < A.Flot.Count; i++)
                {
                    A.Arrangement(G, i);
                }
                try
                {
                    while (n < 1 || n > 10)
                    {

                        Console.WriteLine("Введите букву и цифру");
                        c = Console.ReadKey().KeyChar;
                        b = a.GetKod(Char.ToUpper(c));
                        n = Convert.ToInt32(Console.ReadLine());
                        if (n < 1 || n > 10)
                        {
                            Console.WriteLine("Цифра должна быть от 1 до 10");
                            Console.WriteLine("Попробуй снова.");
                        }
                    }
                    Shot(b + 10, n + 10, ref A);
                }
                catch (Exception ex )
                {
                    // Ошибка ввода
                    Console.WriteLine(ex.Message + " Попробуйте снова!!!\n");
                }
                Console.ReadKey();
            }
        }

        static public void Shot(int y, int x, ref Flotilla A)
        {
            A.Compare(y, x);
        }
    }
}