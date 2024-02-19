using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.MyClasses.WeaponClasses
{
    public class Wand : Weapon
    {
        public Wand(string name, int l = 1) : base(name, l)
        {
            PhysicalDamage += 2;
            Mana += 15;
            Inteligence += 10;
            ShieldAvailable = true;
            StaticCriticalChance = 5;
            StaticCriticalDamage = 300;
            if(l == 2)
            {
                Health += 13;
                MagicDefense += 5;
            }
            if(l == 3)
            {
                MagicDamage += 7;
                MagicDefense += 2;
                Mana += 5;
                Vitality += 5;
            }
        }
    }
}
