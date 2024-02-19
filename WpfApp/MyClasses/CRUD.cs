using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static MongoDB.Bson.Serialization.Serializers.SerializerHelper;

namespace WpfApp.MyClasses
{
    public class CRUD
    {
        private static void CreateCharacter(Character character, string nameCollection)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Game");
            var collection = database.GetCollection<Character>(nameCollection);
            collection.InsertOne(character);
        }
        public static void CreateNamedCharacter(Character character)
        {
            CreateCharacter(character, "CharacterCollection");
        }
        public static void CreateBaseCharacter(Character character)
        {
            CreateCharacter(character, "BaseCharacterCollection");
        }


        private static List<Character> GetAllCharacters(string nameCollection)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Game");
            var collection = database.GetCollection<Character>(nameCollection);
            return collection.Find("{}").ToList();
        }
        public static List<Character> GetBaseCharacters()
        {
            return GetAllCharacters("BaseCharacterCollection");
        }
        public static List<Character> GetNamedCharacters()
        {
            return GetAllCharacters("CharacterCollection");
        }


        public static Character GetCharacter(string name)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Game");
            var collection = database.GetCollection<Character>("CharacterCollection");
            var character = collection.Find(x => x.Name == name).FirstOrDefault();
            return character;
        }
        public static void UpdateCharacter(Character character)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Game");
            var collection = database.GetCollection<Character>("CharacterCollection");
            var filter = Builders<Character>.Filter.Eq(x => x._id, character._id);
            collection.ReplaceOne(filter, character);
        }

        public static void CreateWeapon(Weapon weapon)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Game");
            var collection = database.GetCollection<Weapon>("WeaponCollection");
            weapon = weapon as Weapon;
            collection.InsertOne(weapon);
        }
        public static List<Weapon> GetAllWeapons()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Game");
            var collection = database.GetCollection<Weapon>("WeaponCollection");
            return collection.Find("{}").ToList();
        }
    }
}
