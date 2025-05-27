using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Commando comando = new Commando("golani", "123");
            AirCommando air = new AirCommando("f16", "shaf");
            Weapon weapon = new Weapon("m16", "usa", 40);
            comando.Walk();
            comando.Hide();
            comando.Attack();
            List<Commando> comandos = new List<Commando>();
            comandos.Add(comando);
            comandos.Add(air);
            foreach(Commando c in comandos)
            {
               c.SayName("general");
            }


            
        }
    }
}
