using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandos.Interfaces
{
    internal interface ICommand
    {
        string CodeName { get; set; }
        void Attack();
    }
}
