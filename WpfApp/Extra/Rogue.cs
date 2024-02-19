//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml.Linq;

//namespace WpfApp.MyClasses
//{
//    public class Rogue : Character
//    {
//        public Rogue()
//        {
//            ClassName = "Rogue";
//            MinStrength = 20;
//            MaxStrength = 65;
//            MinDexterity = 30;
//            MaxDexterity = 250;
//            MinInteligence = 15;
//            MaxInteligence = 70;
//            MinVitality = 20;
//            MaxVitality = 80;
//            Strength = MinStrength;
//            Dexterity = MinDexterity;
//            Inteligence = MinInteligence;
//            Vitality = MinVitality;
//        }

//        public override int Health
//        {
//            get
//            {
//                int x = (int)(1.5 * Vitality + 0.5 * Strength);
//                return x;
//            }
//        }
//        public override int Mana
//        {
//            get
//            {
//                int x = (int)(1.2 * Inteligence);
//                if (Weapon != null)
//                    x += Weapon.ManaUp;
//                return x;
//            }
//        }
//        public override int PhysicalDamage
//        {
//            get
//            {
//                int x = (int)(0.5 * Strength + 0.5 * Dexterity);
//                if (Weapon != null)
//                    x += Weapon.PhysicalDamage;
//                return x;
//            }
//        }
//        public override int Armor
//        {
//            get
//            {
//                int x = (int)(1.5 * Dexterity);
//                return x;
//            }
//        }
//        public override int MagicDamage
//        {
//            get
//            {
//                int x = (int)(0.2 * Inteligence);
//                return x;
//            }
//        }
//        public override int MagicDefense
//        {
//            get
//            {
//                int x = (int)(0.5 * Inteligence);
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
