using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonsAndDragonsAPIs.Services
{
    public class MongoDbService
    {
        private readonly IMongoDatabase mongoDatabase;

        #region Contructors
        public MongoDbService()
        {
            string connectionsString = Environment.GetEnvironmentVariable("MongoConnectionString");
            string dbName = Environment.GetEnvironmentVariable("MongoDatabase");

            IMongoClient mongoClient = new MongoClient(connectionsString);
            mongoDatabase = mongoClient.GetDatabase(dbName);
        }
        #endregion

        #region Private Functions
        private IMongoCollection<T> GetCollection<T>()
        {
            IMongoCollection<T> collection = mongoDatabase.GetCollection<T>("Test");
            return collection;
        }
        #endregion

        #region Public Functions
        public List<BsonDocument> GetAllCollection()
        {
            IMongoCollection<BsonDocument> collection = GetCollection<BsonDocument>();

            FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Empty;

            ProjectionDefinition<BsonDocument> projection =
                Builders<BsonDocument>.Projection
                .Include("firstname")
                .Exclude("_id");

            IFindFluent<BsonDocument, BsonDocument> result =
                collection
                .Find<BsonDocument>(filter)
                .Project<BsonDocument>(projection);

            //long myCount = result.Count();
            return result.ToList<BsonDocument>();
        }

        //public GlobalVehicle GetGlobalVehicle(string country, string vehicleId)
        //{
        //    IMongoCollection<GlobalVehicle> collection = GetModelsCollection<GlobalVehicle>();

        //    FilterDefinition<GlobalVehicle> filter =
        //        Builders<GlobalVehicle>.Filter.And(
        //             Builders<GlobalVehicle>.Filter.In<string>("COUNTRY_ID", GetCountryCodes(country)),
        //             Builders<GlobalVehicle>.Filter.Eq<string>("VEHICLE_ID", vehicleId));

        //    ProjectionDefinition<GlobalVehicle> projection =
        //        Builders<GlobalVehicle>.Projection
        //        .Include("HS")
        //        .Include("HT")
        //        .Include("UT")
        //        .Include("AV")
        //        .Exclude("_id");

        //    IFindFluent<GlobalVehicle, GlobalVehicle> result =
        //        collection
        //        .Find<GlobalVehicle>(filter)
        //        .Project<GlobalVehicle>(projection);

        //    IList<GlobalVehicle> list = result.ToList<GlobalVehicle>();
        //    GlobalVehicle vehicle = (result.Count() > 0) ? list[0] : null;
        //    return vehicle;
        //}

        //public List<OptionMapping> GetGlobalOptions()
        //{
        //    IMongoCollection<OptionMapping> collection = GetOptionsCollection<OptionMapping>();

        //    FilterDefinition<OptionMapping> filter =
        //            Builders<OptionMapping>.Filter.Empty;

        //    ProjectionDefinition<OptionMapping> projection =
        //        Builders<OptionMapping>.Projection
        //        .Exclude("_id");

        //    IFindFluent<OptionMapping, OptionMapping> result =
        //        collection.Find<OptionMapping>(filter).Project<OptionMapping>(projection);

        //    return result.ToList<OptionMapping>();
        //}

        //public string GetGlobalOption(string country, string hs, string ht, string oegCode)
        //{
        //    IMongoCollection<OptionMapping> collection = GetOptionsCollection<OptionMapping>();

        //    FilterDefinition<OptionMapping> filter =
        //        Builders<OptionMapping>.Filter.And(
        //            Builders<OptionMapping>.Filter.In<string>("COUNTRY_ID", GetCountryCodes(country)),
        //            Builders<OptionMapping>.Filter.Eq<string>("HS", hs),
        //            Builders<OptionMapping>.Filter.Eq<string>("HT", ht),
        //            Builders<OptionMapping>.Filter.Or(
        //                Builders<OptionMapping>.Filter.Eq<string>("OEG_CODE", oegCode),
        //                Builders<OptionMapping>.Filter.Eq<string>("EQUIP_DESCRIPTION", oegCode)));

        //    ProjectionDefinition<OptionMapping> projection =
        //        Builders<OptionMapping>.Projection
        //        .Exclude("_id")
        //        .Exclude("COUNTRY_ID")
        //        .Exclude("AV_DESCRIPTION")
        //        .Exclude("AV_EXCLUSIONS");

        //    IFindFluent<OptionMapping, OptionMapping> result =
        //        collection.Find<OptionMapping>(filter).Project<OptionMapping>(projection);

        //    IList<OptionMapping> list = result.ToList<OptionMapping>();
        //    string option = (list.Count > 0) ? string.Join(",", list[0].QapterOption) : "";
        //    return option;
        //}

        //public string ClearCollection(string collectionName)
        //{
        //    IMongoCollection<Object> collection = mongoDatabase.GetCollection<Object>(collectionName);

        //    FilterDefinition<Object> filter =
        //        Builders<Object>.Filter.Empty;

        //    DeleteResult deleteResult = collection.DeleteMany(filter);
        //    return deleteResult.DeletedCount + " document(s) were deleted.";
        //}

        public void AddDocuments(List<BsonDocument> newDocuments, string vehicleCollectionName)
        {
            IMongoCollection<BsonDocument> collection = mongoDatabase.GetCollection<BsonDocument>(vehicleCollectionName);

            collection.InsertMany(newDocuments);
        }

        //public void PopulateOptionsCollection(List<OptionMapping> newOptionsData, string optionsCollectionName)
        //{
        //    IMongoCollection<OptionMapping> collection = mongoDatabase.GetCollection<OptionMapping>(optionsCollectionName);

        //    collection.InsertMany(newOptionsData);
        //}
        #endregion
    }
}
