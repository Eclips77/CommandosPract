using System;
using System.Collections.Generic;
using Commandos.Interfaces;
using Commandos.Weapons;

namespace Commandos
{
    //factory class for create an enemies
    internal class EnemyFactory
    {
        private List<Enemy> enemies = new List<Enemy>();

        public Enemy CreateEnemy(string name)
        {
            Enemy enemy = new Enemy(name);
            enemy.Scream();
            enemies.Add(enemy);
            return enemy;
        }

        public List<Enemy> GetAllEnemies()
        {
            return enemies;
        }
    }

    //factory class for creating a weapons
    internal class WeaponFactory : IWeaponFactory
    {
        private readonly Dictionary<string, Func<IWeapon>> weaponCreators = new Dictionary<string, Func<IWeapon>>();
        private  List<IWeapon> weapons = new List<IWeapon>();

        public WeaponFactory()
        {
            Register("m16", () => new Gun("M16", 29, "Colt"));
            Register("ak47", () => new Gun("AK47", 30, "Kalashnikov"));
            Register("stone", () => new Stone("Stone", 2.5, "Gray"));
            Register("knife", () => new Knife("SteelBlade", "Steel", "Gerber", "Black", "0.5"));
        }

        public void Register(string weaponType, Func<IWeapon> creator)
        {
            weaponCreators[weaponType.ToLower()] = creator;
        }

        public IWeapon CreateWeapon(string weaponType)
        {
            if (weaponCreators.TryGetValue(weaponType.ToLower(), out var creator))
            {
                var weapon = creator();
                weapons.Add(weapon);
                return weapon;
            }
            throw new ArgumentException($"Weapon type '{weaponType}' not registered.");
        }

        public List<IWeapon> GetAllWeapons()
        {
            return this.weapons;
        }
    }

    //factory class for creating a commado units
    internal class CommandsFactory : ICommandFactory
    {
        private readonly Dictionary<string, Func<ICommand>> commandCreators = new Dictionary<string, Func<ICommand>>();
        private  List<ICommand> commands = new List<ICommand>();

        public CommandsFactory()
        {
            Register("command", () => new Commando("Golani", "G-01"));
            Register("aircommand", () => new AirCommando("Eagle", "A-01"));
            Register("sea", () => new SeaCommando("Shayetet", "S-01"));
        }

        public void Register(string commandType, Func<ICommand> creator)
        {
            commandCreators[commandType.ToLower()] = creator;
        }

        public ICommand CreateCommand(string commandType)
        {
            if (commandCreators.TryGetValue(commandType.ToLower(), out var creator))
            {
                var command = creator();
                commands.Add(command);
                return command;
            }
            throw new ArgumentException($"Command type '{commandType}' not registered.");
        }

        public List<ICommand> GetAllCommands()
        {
            return this.commands;
        }
    }
}
