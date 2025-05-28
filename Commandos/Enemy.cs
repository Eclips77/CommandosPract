using System;

namespace Commandos
{
    internal class Enemy
    {
        public string Name { get; private set; }
        public int Health { get; private set; } = 100;
        public bool IsAlive { get; private set; } = true;

        public Enemy(string name)
        {
            Name = name;
        }

        public void Scream()
        {
            Console.WriteLine("im enemy!!!");
        }

        public void TakeDamage(int damage)
        {
            if (!IsAlive) return;

            Health -= damage;
            if (Health <= 0)
            {
                Health = 0;
                IsAlive = false;
            }
        }
    }
}
