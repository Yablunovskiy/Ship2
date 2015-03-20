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
    public class Flotilla
    {
        public ObservableCollection<Ship> Flot;

        public Flotilla()
        {
            Flot = new ObservableCollection<Ship>();
            Flot.Add(new Ship(4 ,11, 12));
            Flot.Add(new Ship(3, 13, 11));
            Flot.Add(new Ship(3, 18, 16));
            Flot.Add(new Ship(2, 15, 15));
            Flot.Add(new Ship(2, 19, 11));
            Flot.Add(new Ship(2, 16, 18));
            Flot.Add(new Ship(1, 13, 18));
            Flot.Add(new Ship(1, 11, 20));
            Flot.Add(new Ship(1, 20, 20));
            Flot.Add(new Ship(1, 17, 12));
        }

        //public void PrintCountShips(int ind)
        //{
        //    Flot.ElementAt(ind).PrintCountPalub();
        //}


        public void Arrangement(Rectangl R, int ind)
        {
            Flot.ElementAt(ind).SetShip(R);
        }

        public void Compare(int y, int x)
        {
            int n = -1;// номер палубы
            bool shot=false;
            for (int i = 0; i < Flot.Count; i++)
            {
                if (Flot.ElementAt(i).ChekShottwo(y, x, ref n))
                {
                    Console.WriteLine("Ты попал, в палубу : {0}", n + 1);
                    Console.WriteLine("Караблю из {0} палуб.", Flot.ElementAt(i).Sh.Count);
                    Flot.ElementAt(i).Sh.Remove(n);
                    Console.WriteLine("\t\t Нажми любую клавишу");
                    Flot.ElementAt(i).Sh.Add(n, (new Palub(x, y, 'X')));
                    Flot.ElementAt(i).Sh.ElementAt(n).Value.PrintPalub();
                    shot = true;

                    Flot.CollectionChanged += Flot_CollectionChanged;  // ВОТ СДЕСЬ не Срабатывае я изменяю Содержимое но сообщение не приходит
                    break;
                }
                
            }
            if (!shot)
            {
                Console.WriteLine("Ты промазал");
                Console.WriteLine("\t\t Нажми любую клавишу");
            }
        }

        public void Flot_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
                Console.WriteLine("Добавил");
            if (e.Action == NotifyCollectionChangedAction.Reset)
                Console.WriteLine("Существенно изменил!!!");
            if (e.Action == NotifyCollectionChangedAction.Replace)
                Console.WriteLine("Один или несколько изменены!!!");
        }

    }
}
