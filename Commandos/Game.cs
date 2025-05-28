using Commandos.Interfaces;
using Commandos;
using System.Collections.Generic;
using System;
using System.Security.Principal;

internal class Game
{
    private CommandsFactory commandFactory = new CommandsFactory();
    private WeaponFactory weaponFactory = new WeaponFactory();
    private EnemyFactory enemyFactory = new EnemyFactory();

    private List<ICommand> commandsList;
    //private List<IWeapon> weaponsList;
    private List<Enemy> enemiesList;

    public void Run()
    {
        Console.WriteLine("Starting game...");
        InitializeGame();
        ShowMainMenu();
    }

    private void InitializeGame()
    {
        
        var comand = commandFactory.CreateCommand("command");
        var air = commandFactory.CreateCommand("aircommand");

        var m16 =weaponFactory.CreateWeapon("m16");
        var knife = weaponFactory.CreateWeapon("knife");
        comand.EquipWeapon(m16);
        air.EquipWeapon(knife);

        enemyFactory.CreateEnemy("Ali");
        enemyFactory.CreateEnemy("Kassem");
        commandsList = commandFactory.GetAllCommands();
        //weaponsList = weaponFactory.GetAllWeapons();
        enemiesList = enemyFactory.GetAllEnemies();
    }

    private void ShowMainMenu()
    {
        while (true)
        {
            Console.WriteLine("=== Main Menu ===");
            Console.WriteLine("1. List all enemies");
            Console.WriteLine("2. Attack enemy");
            Console.WriteLine("3. Show all commandos and thier weapons");
            Console.WriteLine("4. Exit");

            string input = Console.ReadLine();
            Console.Clear();
            switch (input)
            {
                case "1":
                    ListEnemies();
                    break;
                case "2":
                    Console.WriteLine("enter enemy number to attack");
                    int choice = (int.Parse(Console.ReadLine()));
                    AttackEnemy(choice);
                    break;
                case "3":
                    ShowUnitWeapons();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice enter any key to continue");
                    Console.ReadLine();
                    Console.Clear();
                    break;
            }
   
        }
    }

    private void ListEnemies()
    {
        foreach (var enemy in enemiesList)
        {
            Console.WriteLine($"{enemy.Name} - Health: {enemy.Health} - Alive: {enemy.IsAlive}");
        }
    }

    private void AttackEnemy(int choice)
    {
        if (commandsList.Count == 0 || enemiesList.Count == 0) Console.WriteLine("invalidChoice");

        var attacker = commandsList[0];
        var target = enemiesList[choice];

        attacker.Attack();
        target.TakeDamage(40);
        Console.WriteLine($"Attacked {target.Name}, new health: {target.Health}");
    }

    private void ShowUnitWeapons()
    {
        Console.WriteLine("=== Units and Their Weapons ===");

        foreach (var command in commandsList)
        {
            Console.WriteLine($"Unit: {command.CodeName}");

            if (command.Weapon != null)
            {
                Console.WriteLine($"  Weapon: {command.Weapon.Name}");

                var shootable = command.Weapon as IShootable;
                if (shootable != null)
                {
                    Console.WriteLine($"  Ammo left: {shootable.Ammo}");
                }

                var breakable = command.Weapon as IBreakable;
                if (breakable != null)
                {
                    Console.WriteLine($"  Is broken: {breakable.IsBroken}");
                }
            }
            else
            {
                Console.WriteLine("  No weapon equipped.");
            }

            Console.WriteLine();
        }
    }
}
