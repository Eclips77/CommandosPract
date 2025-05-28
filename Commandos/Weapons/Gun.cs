using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus.DataSets;
using Commandos.Interfaces;

namespace Commandos.Weapons
{
    internal class Gun : IWeapon, IShootable
    {
        public string Name { get; set; }
        public int Ammo { get; set; }
        string Producer;
        public Gun(string name,int ammo,string producer)
        {
            this.Name = name;
            this.Ammo = ammo;
            this.Producer = producer;
        }
        public void Attack()
        {
            if (Ammo > 0)
            {
                this.Ammo--;
                Console.WriteLine($"{this.Name} fired! Ammo left: {this.Ammo}");
            }
            else
            {
                Console.WriteLine($"{this.Name} is out of ammo!");
            }

        }

        public  void Print()
        {
            Console.WriteLine($"gun name: {this.Name}\n" +
                $"ammo left: {this.Ammo}\n" +
                $"gun producer: {this.Producer}");
        }
    }
}
