using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandos
{
    internal class Weapon
    {
        public string Name;
        public string Producer;
        int AmmoCap;

        public Weapon(string name,string producer,int ammoCap)
        {
            this.Name = name;
            this.Producer = producer;
            this.AmmoCap = ammoCap;
        }
        public void Shoot()
        {
            if (this.AmmoCap > 0)
            {
                this.AmmoCap--;
                Console.WriteLine($"shooting boom boom! {this.AmmoCap} ammo left:");
            }
            else
            {
                Console.WriteLine("no ammo left please reload");
            }
            
        }
    }
}
