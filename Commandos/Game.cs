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
    private List<IWeapon> weaponsList;
    private List<Enemy> enemiesList;

    public void Run()
    {
        Console.WriteLine("Starting game...");
        InitializeGame();
        ShowMainMenu();
    }

    private void InitializeGame()
    {
        commandsList = commandFactory.GetAllCommands();
        weaponsList = weaponFactory.GetAllWeapons();
        enemiesList = enemyFactory.GetAllEnemies();

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
        foreach (var enemy in enemiesList)
        {
            Console.WriteLine($"{enemy.Name} - Health: {enemy.Health} - Alive: {enemy.IsAlive}");
        }
    }

    private void AttackEnemy(int choice)
    {
        if (commandsList.Count == 0 || enemiesList.Count == 0) return;

        var attacker = commandsList[0];
        var target = enemiesList[choice];

        attacker.Attack();
        target.TakeDamage(40);
        Console.WriteLine($"Attacked {target.Name}, new health: {target.Health}");
    }
}
