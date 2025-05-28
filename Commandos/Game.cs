using Commandos.Interfaces;
using Commandos;
using System.Collections.Generic;
using System;

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

        weaponFactory.CreateWeapon("gun");
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
                AttackEnemy();
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

    private void AttackEnemy()
    {
        if (commands.Count == 0 || enemies.Count == 0) return;

        var attacker = commands[0];
        var target = enemies[0];

        attacker.Attack();
        target.TakeDamage(40);
        Console.WriteLine($"Attacked {target.Name}, new health: {target.Health}");
    }
}
