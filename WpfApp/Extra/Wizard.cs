//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml.Linq;

//namespace WpfApp.MyClasses
//{
//    internal class Wizard : Character
//    {
//        public Wizard()
//        {
//            ClassName = "Wizard";
//            MinStrength = 15;
//            MaxStrength = 45;
//            MinDexterity = 20;
//            MaxDexterity = 80;
//            MinInteligence = 35;
//            MaxInteligence = 250;
//            MinVitality = 15;
//            MaxVitality = 70;
//            Strength = MinStrength;
//            Dexterity = MinDexterity;
//            Inteligence = MinInteligence;
//            Vitality = MinVitality;
//        }

//        public override int Health
//        {
//            get
//            {
//                int x = (int)(1.4 * Vitality + 0.2 * Strength);
//                return x;
//            }
//        }
//        public override int Mana
//        {
//            get
//            {
//                int x = (int)(1.5 * Inteligence);
//                if (Weapon != null)
//                    x += Weapon.ManaUp;
//                return x;
//            }
//        }
//        public override int PhysicalDamage
//        {
//            get
//            {
//                int x = (int)(0.5 * Strength);
//                if(Weapon != null)
//                    x += Weapon.PhysicalDamage;
//                return x;
//            }
//        }
//        public override int Armor
//        {
//            get
//            {
//                int x = Dexterity;
//                return x;
//            }
//        }
//        public override int MagicDamage
//        {
//            get
//            {
//                int x = Inteligence;
//                return x;
//            }
//        }
//        public override int MagicDefense
//        {
//            get
//            {
//                int x = Inteligence;
//                return x;
//            }
//        }
//        public override int CriticalChance
//        {
//            get
//            {
//                int x = (int)(0.2 * Dexterity);
//                return x;
//            }
//        }
//        public override int CriticalDamage
//        {
//            get
//            {
//                int x = (int)(0.1 * Dexterity);
//                return x;
//            }
//        }
//    }
//}
