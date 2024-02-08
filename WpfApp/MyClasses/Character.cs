using Amazon.Util.Internal.PlatformServices;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.MyClasses
{
    [BsonIgnoreExtraElements]
    public class Character
    {
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
        public Character(string name, string className, int minStrength, int maxStrength, int minDexterity, int maxDexterity,
            int minInteligence, int maxInteligence, int minVitality, int maxVitality)
            :this(className, minStrength, maxStrength, minDexterity, maxDexterity,
            minInteligence, maxInteligence, minVitality, maxVitality)
        {
            Name = name;
            MinStrength = minStrength;
            MinDexterity = minDexterity;
            MinInteligence = minInteligence;
            MinVitality = minVitality;
        }

        [BsonIgnore]
        public ObjectId _id;
        [BsonIgnoreIfNull]
        public string Name { get; set; }
        public string ClassName { get; set; }
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
        public int Expirience { get; set; }

        public int Health
        {
            get
            {
                if (ClassName == "WARRIOR")
                {
                    return 2 * Vitality + Strength;
                }
                if (ClassName == "ROGUE")
                {
                    return (int)(1.5 * Vitality + 0.5 * Strength);
                }
                if (ClassName == "WIZARD")
                {
                    return (int)(1.4 * Vitality + 0.2 * Strength);
                }
                return 0;
            }
        }


        public int Mana
        {
            get
            {
                if (ClassName == "WARRIOR")
                {
                    return Inteligence;
                }
                if (ClassName == "ROGUE")
                {
                    return (int)(1.2 * Inteligence);
                }
                if (ClassName == "WIZARD")
                {
                    return (int)(1.5 * Inteligence);
                }
                return 0;
            }
        }



        public int PhysicalDamage
        {
            get
            {
                if (ClassName == "WARRIOR")
                {
                    return Strength;
                }
                if (ClassName == "ROGUE")
                {
                    return (int)(0.5 * Strength + 0.5 * Dexterity);
                }
                if (ClassName == "WIZARD")
                {
                    return (int)(0.5 * Strength);
                }
                return 0;
            }
        }

        public int Armor
        {
            get
            {
                if (ClassName == "WARRIOR")
                {
                    return Dexterity;
                }
                if (ClassName == "ROGUE")
                {
                    return (int)(1.5 * Dexterity);
                }
                if (ClassName == "WIZARD")
                {
                    return (int)(1 * Dexterity);
                }
                return 0;
            }
        }


        public int MagicDamage
        {
            get
            {
                if (ClassName == "WARRIOR")
                {
                    return (int)(0.2 * Inteligence);
                }
                if (ClassName == "ROGUE")
                {
                    return (int)(0.2 * Inteligence);
                }
                if (ClassName == "WIZARD")
                {
                    return (int)(1 * Inteligence);
                }
                return 0;
            }
        }


        public int MagicDefense
        {
            get
            {
                if (ClassName == "WARRIOR")
                {
                    return (int)(0.5 * Inteligence);
                }
                if (ClassName == "ROGUE")
                {
                    return (int)(0.5 * Inteligence);
                }
                if (ClassName == "WIZARD")
                {
                    return (int)(1 * Inteligence);
                }
                return 0;
            }
        }


        public int CriticalChanse
        {
            get
            {
                if (ClassName == "WARRIOR")
                {
                    return (int)(0.2 * Dexterity);
                }
                if (ClassName == "ROGUE")
                {
                    return (int)(0.2 * Dexterity);
                }
                if (ClassName == "WIZARD")
                {
                    return (int)(0.2 * Dexterity);
                }
                return 0;
            }
        }


        public int CriticalDamage
        {
            get
            {
                if (ClassName == "WARRIOR")
                {
                    return (int)(0.1 * Dexterity);
                }
                if (ClassName == "ROGUE")
                {
                    return (int)(0.1 * Dexterity);
                }
                if (ClassName == "WIZARD")
                {
                    return (int)(0.1 * Dexterity);
                }
                return 0;
            }
        }
    }
}
