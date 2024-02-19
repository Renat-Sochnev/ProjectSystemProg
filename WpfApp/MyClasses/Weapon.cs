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
    public class Weapon
    {
        public Weapon(string name, int l = 1)
        {
            Name = name;
        }
        public ObjectId _id;
        public string Name { get; set; }
        [BsonIgnoreIfDefault]
        public int Strenght { get; set; }
        [BsonIgnoreIfDefault]
        public int Dexterity { get; set; }
        [BsonIgnoreIfDefault]
        public int Inteligence { get; set; }
        [BsonIgnoreIfDefault]
        public int Vitality { get; set; }
        [BsonIgnoreIfDefault]
        public int Health { get; set; }
        [BsonIgnoreIfDefault]
        public int Mana { get; set; }
        [BsonIgnoreIfDefault]
        public int PhysicalDamage { get; set; }
        [BsonIgnoreIfDefault]
        public int Armor { get; set; }
        [BsonIgnoreIfDefault]
        public int MagicDamage { get; set; }
        [BsonIgnoreIfDefault]
        public int MagicDefense { get; set; }
        [BsonIgnoreIfDefault]
        public double ProcentCriticalChance { get; set; }
        [BsonIgnoreIfDefault]
        public double ProcentCriticalDamage { get; set; }
        [BsonIgnoreIfDefault]
        public int StaticCriticalChance { get; set; }
        [BsonIgnoreIfDefault]
        public int StaticCriticalDamage { get; set; }
        [BsonIgnoreIfDefault]
        public bool DualAvailable { get; set; }
        [BsonIgnoreIfDefault]
        public bool ShieldAvailable { get; set; }

    }
}
