using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandos.Interfaces
{
    public interface ICommand
    {
        string CodeName { get; set; }
        IWeapon Weapon { get;}
        void EquipWeapon(IWeapon weapon);
        void Attack();
    }
}
