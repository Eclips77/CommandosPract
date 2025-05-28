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

    private List<ICommand> commands;
    private List<IWeapon> weapons;
    private List<Enemy> enemies;

    public void Run()
    {
        Console.WriteLine("Starting game...");
        InitializeGame();
        ShowMainMenu();
    }

    private void InitializeGame()
    {
        commands = commandFactory.GetAllCommands();
        weapons = weaponFactory.GetAllWeapons();
        enemies = enemyFactory.GetAllEnemies();

        commandFactory.CreateCommand("command");
        commandFactory.CreateCommand("aircommand");

        weaponFactory.CreateWeapon("m16");
        weaponFactory.CreateWeapon("knife");

        enemyFactory.CreateEnemy("Ali");
        enemyFactory.CreateEnemy("Kassem");
    }

    private void ShowMainMenu()
    {
        Console.WriteLine("=== Main Menu ===");
        Console.WriteLine("1. List all enemies");
        Console.WriteLine("2. Attack enemy");
        Console.WriteLine("3. Exit");

        string input = Console.ReadLine();
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
                return;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }

        ShowMainMenu();
    }

    private void ListEnemies()
    {
        foreach (var enemy in enemies)
        {
            Console.WriteLine($"{enemy.Name} - Health: {enemy.Health} - Alive: {enemy.IsAlive}");
        }
    }

    private void AttackEnemy(int choice)
    {
        if (commands.Count == 0 || enemies.Count == 0) return;

        var attacker = commands[0];
        var target = enemies[choice];

        attacker.Attack();
        target.TakeDamage(40);
        Console.WriteLine($"Attacked {target.Name}, new health: {target.Health}");
    }
}
