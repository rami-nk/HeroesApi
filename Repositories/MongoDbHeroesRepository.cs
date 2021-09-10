using System;
using System.Collections.Generic;
using HeroesApi.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HeroesApi.Repositories
{
    public class MongoDbHeroesRepository : IHeroRepository
    {

        private const string DatabaseName = "heroesapi";
        private const string CollectionName = "heroes";
        private readonly IMongoCollection<Hero> _heroesCollection;
        private readonly FilterDefinitionBuilder<Hero> _filterDefinitionBuilder = Builders<Hero>.Filter;

        public MongoDbHeroesRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(DatabaseName);
            _heroesCollection = database.GetCollection<Hero>(CollectionName);   
        }
        public IEnumerable<Hero> GetHeroes()
        {
            return _heroesCollection.Find(new BsonDocument()).ToList();
        }

        public Hero GetHero(long id)
        {
            var filter = _filterDefinitionBuilder.Eq(hero => hero.Id, id);
            return _heroesCollection.Find(filter).SingleOrDefault();
        }

        public void AddHero(Hero hero)
        {
            _heroesCollection.InsertOne(hero);
        }

        public void UpdateHero(Hero hero)
        {
            var filter = _filterDefinitionBuilder.Eq(dbItem => dbItem.Id, hero.Id);
            _heroesCollection.ReplaceOne(filter, hero);
        }

        public void DeleteHero(long id)
        {
            var filter = _filterDefinitionBuilder.Eq(hero => hero.Id, id);
            _heroesCollection.DeleteOne(filter);
        }
    }
}