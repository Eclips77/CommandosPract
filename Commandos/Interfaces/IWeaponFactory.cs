using Commandos.Interfaces;

interface IWeaponFactory
{
    IWeapon CreateWeapon(string weaponType);
}

interface ICommandFactory
{
    ICommand CreateCommand(string commandType);
}