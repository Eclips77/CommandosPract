using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandos
{
    public  class Commando
    {
        protected  string Name;
        public string CodeName { get; set; }
        public string[] Tools = {"hammer","chisel","rope","bag","water"};
        string Status = "standing";

        public Commando(string name, string codeName)
        {
            this.Name = name;
            this.CodeName = codeName;
        }
        public  void Walk()
        {
            Console.WriteLine($"the soliderstatus is {this.Status}");
            this.Status = "walk";
        }
        public  void Hide()
        {
            this.Status = "hide";
            Console.WriteLine($"the solider status is {this.Status}");
        }
        public  virtual void Attack()
        {
            Console.WriteLine($"comando {this.Name} is attacking on the graund!");
        }
        public  void SayName(string commanderRank)
        {
            if (commanderRank.ToLower().Equals("general"))
            {
                Console.WriteLine($"the comando name is {this.Name}:");
            }
            else if (commanderRank.ToLower().Equals("colonel"))
                Console.WriteLine($"the comando code is {this.CodeName}");
            else
            {
                Console.WriteLine("eccses deined!");
            }
        }



    }
}
