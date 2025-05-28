using Commandos.Interfaces;
using System;

namespace Commandos.Weapons
{
    public class Knife : IBreakable,IWeapon
    {
        public string Name { get; set; }
        public string MetalType { get; }
        public string Producer { get; }
        public string Color { get; }
        public string Weight { get; }
        private int MaxHits = 5;
        private int CurrentHits;

        public bool IsBroken => CurrentHits >= MaxHits;

        public Knife(string name, string metalType, string producer, string color, string weight)
        {
            this.Name = name;
            this.MetalType = metalType;
            this.Producer = producer;
            this.Color = color;
            this.Weight = weight;
            //this.CurrentHits = 0;
        }

        public void Attack()
        {
            if (!this.IsBroken)
            {
                this.CurrentHits++;
                Console.WriteLine($"{this.Name}(Knife was hit! {this.CurrentHits}/{this.MaxHits}");

                if (this.IsBroken)
                {
                    Console.WriteLine($"{this.Name} is now broken!");
                }
            }
            else
            {
                Console.WriteLine($"{this.Name} is already broken.");
            }
        }

    }
}
