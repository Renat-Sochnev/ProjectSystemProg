using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WpfApp.MyClasses.WeaponClasses
{
    public class Dagger : Weapon
    {
        public Dagger(string name, int l = 1) : base(name, l)
        {
            PhysicalDamage = 6;
            Dexterity = 12;
            DualAvailable = true;
            ProcentCriticalChance = 0.6;
            ProcentCriticalDamage = 0.7;
        }
    }
}
