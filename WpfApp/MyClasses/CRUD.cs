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
        public static void CreateCharacter(Character character)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Game");
            var collection = database.GetCollection<Character>("CharacterCollection");
            collection.InsertOne(character);
        }

        public static Character GetCharacter(string name)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Game");
            var collection = database.GetCollection<Character>("CharacterCollection");
            var character = collection.Find(x => x.Name == name).FirstOrDefault();
            if (character == null)
                return null;
            else
                return character;
        }

        public static List<Character> GetAllCharacters()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Game");
            var collection = database.GetCollection<Character>("CharacterCollection");
            return collection.Find("{}").ToList();
        }
        public static List<Character> GetBaseCharacters()
        {
            return GetAllCharacters().Where(x => x.Name == null).ToList();
        }

        public static List<Character> GetNamedCharacters()
        {
            return GetAllCharacters().Where(x => x.Name != null).ToList();
        }

        public static void UpdateCharacter(Character character)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Game");
            var collection = database.GetCollection<Character>("CharacterCollection");
            var filter = Builders<Character>.Filter.Eq(x => x._id, character._id);
            //var filter = new BsonDocument("Name", character.Name);
            //var updateSettings = new BsonDocument("$set", new BsonDocument
            //{
            //    { "Strength", character.Strength },
            //    { "Dexterity", character.Dexterity },
            //    { "Inteligence", character.Inteligence },
            //    { "Vitality", character.Vitality },
            //    { "Expirience", character.Expirience },
            //    { "Level", character.Level },
            //    { "StatPoints", character.StatPoints },
            //});
            //collection.UpdateOne(filter, updateSettings);
            collection.ReplaceOne(filter, character);
        }
    }
}
