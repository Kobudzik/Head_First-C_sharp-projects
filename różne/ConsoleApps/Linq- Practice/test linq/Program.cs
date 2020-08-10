using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace test_linq
{
    class Program
    {
        class Invader
        {
            public Point Location;
            public string Name;

            public Invader(Point location, string name)
            {
                Location = location;
                Name = name;
            }
        }
        static void Main(string[] args)
        {
            Random _random = new Random();
            List<Invader> _invaders = new List<Invader>();

            _invaders.Add(new Invader(new Point(7, 4),"first"));
            _invaders.Add(new Invader(new Point(7, 2), "second"));
            _invaders.Add(new Invader(new Point(7, 9), "third"));
            _invaders.Add(new Invader(new Point(3, 99), "fourth"));
            _invaders.Add(new Invader(new Point(3, 53), "fifth"));

            var shootingInvader =      //wybranie najnizszego aliena z losowej kolumny
            from invader in _invaders
            group invader by invader.Location.X into shootingInvadersGroupColumns
            orderby shootingInvadersGroupColumns.Key descending   //sorotwanie KEY malejąco czyli X malejąco- u samej gory max
            select shootingInvadersGroupColumns.First();
            // select shootingInvadersGroups.ElementAt(_random.Next(0, shootingInvadersGroups.Count())); //wybranie najnizszego aliena z grupy


            Invader najnizszy = shootingInvader.ElementAt(_random.Next(0, shootingInvader.Count()));

            foreach (Invader invader in _invaders)
            {
                Console.Write("X= {0}, Y={1} {2} {3}",invader.Location .X, invader.Location.Y, invader.Name,"\n");
            }



            Console.Write(najnizszy.Name);
            Console.ReadKey();


        }
    }
}
