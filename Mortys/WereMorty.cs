using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RandM_1._0.Attack;

namespace RandM_1._0.Mortys
{
    public class WerewolfMorty : IMorty
    {
        public int Health { get; set; } = 25;
        public void Scream()
        {
            Console.WriteLine("RAAAAAAWWWWOOOOOoooOOOwwww");
        }

        public void Hurt(Attack attack) //_.0.Attack.(whatever the guide says) keeps appearing
        {
            if (attack.Type == DamageType.Piercing || attack.Type == DamageType.Shocking)
            {
                Health -= (int)Math.Floor(attack.Damage * 1.5);
            }
            else if (attack.Type == DamageType.Bludgeoning || attack.Type == DamageType.Psych)
            {
                Health -= (int)Math.Ceiling(attack.Damage * 0.5);
            }
            else
            {
                Health -= attack.Damage;
            }
        }
        public Attack Attack()
        {
            return new Attack(5, 10, DamageType.Slashing, "Paw Slap");
        }
    }
}
