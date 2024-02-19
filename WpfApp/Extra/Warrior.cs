//using MongoDB.Driver;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace WpfApp.MyClasses
//{
//    public class Warrior : Character
//    {
//        public Warrior()
//        {
//            ClassName = "Warrior";
//            MinStrength = 30;
//            MaxStrength = 250;
//            MinDexterity = 15;
//            MaxDexterity = 80;
//            MinInteligence = 10;
//            MaxInteligence = 50;
//            MinVitality = 25;
//            MaxVitality = 100;
//            Strength = MinStrength;
//            Dexterity = MinDexterity;
//            Inteligence = MinInteligence;
//            Vitality = MinVitality;
//        }

//        public override int Health
//        {
//            get
//            {
//                int x = 2 * Vitality + Strength;
//                return x;
//            }
//        }
//        public override int Mana
//        {
//            get
//            {
//                int x = Inteligence;
//                if (Weapon != null)
//                    x += Weapon.ManaUp;
//                return x;
//            }
//        }
//        public override int PhysicalDamage
//        {
//            get
//            {
//                int x = Strength;
//                if (Weapon != null)
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
