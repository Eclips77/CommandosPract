using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commandos.Interfaces;

namespace Commandos
{
    internal class AirCommando : Commando,ICommand
    {
        public AirCommando(string name, string codeName) : base(name, codeName) { }
        public void parachuting()
        {
            Console.WriteLine("the air commando is parachuting..");
        }

        public override void Attack()
        {
            Console.WriteLine($"comando{this.Name} is in air strike! ");
        }
    }
}
