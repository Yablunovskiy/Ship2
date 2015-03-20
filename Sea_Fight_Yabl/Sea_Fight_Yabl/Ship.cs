using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea_Fight_Yabl
{
    public class Palub
    {
        public int X;
        public int Y;
        public char A;


        public Palub(int x = 0, int y = 0, char? P=null)
        {
            X = x;
            Y = y;
            A = P ?? 'O';
        }

        //public void SetPalub(int x, int y, bool P = false)
        //{
        //    this.X = x;
        //    this.Y = y;
        //    if (P==true) this.A = 'X';
        //    else this.A = 'O';
        //}

        public void PrintPalub()
        {
            Console.SetCursorPosition(X, Y);
            Console.WriteLine(A);
        }

        //public override string ToString()
        //{
        //    return String.Format("X : {0}, Y : {1}, A : {2}", X, Y, A);
        //}

        //public void SetX(int x)
        //{
        //    this.X = x;
        //}

        //public void SetY(int y)
        //{
        //    this.Y = y;
        //}

        //public void SetA( char? a = null)
        //{
        //    this.A = a ?? 'O';
        //}

        public int GetX()
        {
            return X;
        }

        public int GetY()
        {
            return Y;
        }
    }

    public class Ship 
    {
        public Dictionary<int, Palub> Sh = new Dictionary<int, Palub>();

        public Ship()
        {
                
        }

        public Ship(int n, int x, int y)
        {
            for (int i = 0; i < n; i++)
            {
                Sh.Add(i, (new Palub(x,y+i)));
            }
        }

        //public void PrintCountPalub()
        //{
        //    Console.WriteLine("Кол-во палуб :" + Sh.Count);
        //    PrintKeyPalub();
        //    Console.WriteLine();
        //}

        //public void PrintKeyPalub()
        //{
        //    for (int i = 0; i < Sh.Count; i++)
        //    {
        //        Console.WriteLine("Номер палубы :" + i);
        //    }
        //}

        //public int SetShi()
        //{
        //    return Sh.Count;
        //}

        //public int GetPalubX (int ind)
        //{
        //    return Sh.Count;
        //}

        public void SetShip(Rectangl G)
        {
            Random rand = new Random();
            int Count = Sh.Count;
            for (int i = 0; i < Count; i++)
            {
                Sh[i].PrintPalub();
            }
            Console.SetCursorPosition(10, 30);
        }

        public void ChekShot(int y, int x)
        {
            int Count = Sh.Count;
            int n = -1;
            bool shot=false;
            for (int i = 0; i < Count; i++)
            {
                if (Sh.ElementAt(i).Value.GetX() == x && Sh.ElementAt(i).Value.GetY() == y)
                {
                    shot = true;
                    n = Sh.ElementAt(i).Key;
                    i=Count;
                }
                else shot = false;
            }
            if (shot)
            {
                Sh.Remove(n);
                Sh.Add(n, (new Palub(x, y, 'X')));
                Sh.ElementAt(n).Value.PrintPalub();

                Console.SetCursorPosition(10, 40);
                
                Console.WriteLine("Ты попал, в палубу : {0}", n+1);
            }
            else Console.WriteLine("Ты промазал");

        }

        public bool ChekShottwo(int y, int x, ref int n)
        {
            int Count = Sh.Count;
            bool shot = false;
            for (int i = 0; i < Count; i++)
            {
                if (Sh.ElementAt(i).Value.GetX() == x && Sh.ElementAt(i).Value.GetY() == y)
                {
                    shot = true;
                    n = Sh.ElementAt(i).Key;
                    i = Count;
                }
                else shot = false;
            }
            if (shot)
            {
                return true;
            }
            return false;
        }
    }
}
