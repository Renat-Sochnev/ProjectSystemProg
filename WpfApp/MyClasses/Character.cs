using Amazon.Util.Internal.PlatformServices;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WpfApp.MyPages;

namespace WpfApp.MyClasses
{
    [BsonIgnoreExtraElements]
    public class Character
    {
        //public static Character Create(string ClassName)
        //{
        //    Character character = new Character();
        //    switch (ClassName)
        //    {
        //        case "Warrior":
        //            character = new Warrior();
        //            break;
        //        case "Rogue":
        //            character = new Rogue();
        //            break;
        //        case "Wizard":
        //            character = new Wizard();
        //            break;
        //    }
        //    return character;
        //}

        public Character(string className)
        {
            ClassName = className;
        }
        public Character(string className, int minStrength, int maxStrength, int minDexterity, int maxDexterity,
            int minInteligence, int maxInteligence, int minVitality, int maxVitality)
        {
            ClassName = className;
            Strength = minStrength;
            MaxStrength = maxStrength;
            Dexterity = minDexterity;
            MaxDexterity = maxDexterity;
            Inteligence = minInteligence;
            MaxInteligence = maxInteligence;
            Vitality = minVitality;
            MaxVitality = maxVitality;
        }

        public ObjectId _id;
        public string ClassName { get; set; }
        [BsonIgnoreIfNull]
        public string Name { get; set; }
        [BsonIgnoreIfDefault]
        public int MinStrength { get; set; }
        public int MaxStrength { get; set; }
        public int Strength { get; set; }
        [BsonIgnoreIfDefault]
        public int MinDexterity { get; set; }
        public int MaxDexterity { get; set; }
        public int Dexterity { get; set; }
        [BsonIgnoreIfDefault]
        public int MinInteligence { get; set; }
        public int MaxInteligence { get; set; }
        public int Inteligence { get; set; }
        [BsonIgnoreIfDefault]
        public int MinVitality { get; set; }
        public int MaxVitality { get; set; }
        public int Vitality { get; set; }

        [BsonIgnoreIfDefault]
        public int StatPoints { get; set; }

        [BsonIgnoreIfDefault]
        public int Level { get; set; }

        [BsonIgnoreIfDefault]
        public int Experience { get; set; }
        public int Health
        {
            get
            {
                int x = 0;
                if (ClassName == "WARRIOR")
                    x = 2 * Vitality + Strength;
                if (ClassName == "ROGUE")
                    x = (int)(1.5 * Vitality + 0.5 * Strength);
                if (ClassName == "WIZARD")
                    x = (int)(1.4 * Vitality + 0.2 * Strength);
                if (Weapon != null)
                    x += Weapon.Health;
                return x;
            }
        }
        public int Mana
        {
            get
            {
                int x = 0;
                if (ClassName == "WARRIOR")
                    x = Inteligence;
                if (ClassName == "ROGUE")
                    x = (int)(1.2 * Inteligence);
                if (ClassName == "WIZARD")
                    x = (int)(1.5 * Inteligence);
                if (Weapon != null)
                    x += Weapon.Mana;
                return x;
            }
        }
        public int PhysicalDamage
        {
            get
            {
                int x = 0;
                if (ClassName == "WARRIOR")
                    x = Strength;
                if (ClassName == "ROGUE")
                    x = (int)(0.5 * Strength + 0.5 * Dexterity);
                if (ClassName == "WIZARD")
                    x = (int)(0.5 * Strength);
                if (Weapon != null)
                    x += Weapon.PhysicalDamage;
                return x;
            }
        }
        public int Armor
        {
            get
            {
                int x = 0;
                if (ClassName == "WARRIOR")
                    x = Dexterity;
                if (ClassName == "ROGUE")
                    x = (int)(1.5 * Dexterity);
                if (ClassName == "WIZARD")
                    x = (int)(1 * Dexterity);
                if (Weapon != null)
                    x += Weapon.Armor;
                return x;
            }
        }
        public int MagicDamage
        {
            get
            {
                int x = 0;
                if (ClassName == "WARRIOR")
                    x = (int)(0.2 * Inteligence);
                if (ClassName == "ROGUE")
                    x = (int)(0.2 * Inteligence);
                if (ClassName == "WIZARD")
                    x = (int)(1 * Inteligence);
                if (Weapon != null)
                    x += Weapon.MagicDamage;
                return x;
            }
        }
        public int MagicDefense
        {
            get
            {
                int x = 0;
                if (ClassName == "WARRIOR")
                    x = (int)(0.5 * Inteligence);
                if (ClassName == "ROGUE")
                    x = (int)(0.5 * Inteligence);
                if (ClassName == "WIZARD")
                    x = (int)(1 * Inteligence);
                if (Weapon != null)
                    x += Weapon.MagicDefense;
                return x;
            }
        }
        public int CriticalChance
        {
            get
            {
                int x = 0;
                if (ClassName == "WARRIOR")
                    x = (int)(0.2 * Dexterity);
                if (ClassName == "ROGUE")
                    x = (int)(0.2 * Dexterity);
                if (ClassName == "WIZARD")
                    x = (int)(0.2 * Dexterity);
                if(Weapon != null)
                {
                    x += (int)(x * Weapon.ProcentCriticalChance);
                    if (Weapon.StaticCriticalChance > 0)
                        x = Weapon.StaticCriticalChance;
                }
                return x;
            }
        }
        public int CriticalDamage
        {
            get
            {
                int x = 0;
                if (ClassName == "WARRIOR")
                    x = (int)(0.1 * Dexterity);
                if (ClassName == "ROGUE")
                    x = (int)(0.1 * Dexterity);
                if (ClassName == "WIZARD")
                    x = (int)(0.1 * Dexterity);
                if (Weapon != null)
                {
                    x += (int)(x * Weapon.ProcentCriticalDamage);
                    if (Weapon.StaticCriticalDamage > 0)
                        x = Weapon.StaticCriticalDamage;
                }
                return x;
            }
        }

        [BsonIgnoreIfNull]
        public Weapon Weapon { get; set; }

        public void EquipWeapon(Weapon weapon)
        {
            UnequipWeapon();
            Weapon = weapon;
            Strength += Weapon.Strenght;
            MinStrength += Weapon.Strenght;
            MaxStrength += Weapon.Strenght;
            Dexterity += Weapon.Dexterity;
            MinDexterity += Weapon.Dexterity;
            MaxDexterity += Weapon.Dexterity;
            Inteligence += Weapon.Inteligence;
            MinInteligence += Weapon.Inteligence;
            MaxInteligence += Weapon.Inteligence;
            Vitality += Weapon.Vitality;
            MinVitality += Weapon.Vitality;
            MaxVitality += Weapon.Vitality;
        }
        public void UnequipWeapon()
        {
            if (Weapon == null)
                return;
            Strength -= Weapon.Strenght;
            MinStrength -= Weapon.Strenght;
            MaxStrength -= Weapon.Strenght;
            Dexterity -= Weapon.Dexterity;
            MinDexterity -= Weapon.Dexterity;
            MaxDexterity -= Weapon.Dexterity;
            Inteligence -= Weapon.Inteligence;
            MinInteligence -= Weapon.Inteligence;
            MaxInteligence -= Weapon.Inteligence;
            Vitality -= Weapon.Vitality;
            MinVitality -= Weapon.Vitality;
            MaxVitality -= Weapon.Vitality;
            Weapon = null;
        }
    }
}
