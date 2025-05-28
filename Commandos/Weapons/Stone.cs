using Commandos.Interfaces;
using System;

namespace Commandos.Weapons
{
    public class Stone : IBreakable ,IWeapon
    {
        public string Name { get; set; }
        public double Weight { get; }
        public string Color { get; }
        public int MaxHits { get; }
        private int CurrentHits;

        public bool IsBroken => CurrentHits >= MaxHits;

        public Stone(string name, double weight, string color, int maxHits = 5)
        {
            this.Name = name;
            this.Weight = weight;
            this.Color = color;
            this.MaxHits = maxHits;
            this.CurrentHits = 0;
        }

        public void Hit()
        {
            if (!IsBroken)
            {
                CurrentHits++;
                Console.WriteLine($"{this.Name} was hit! {this.CurrentHits}/{this.MaxHits}");

                if (IsBroken)
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
