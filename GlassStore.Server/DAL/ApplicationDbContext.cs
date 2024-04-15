
using GlassStore.Server.Domain;
using GlassStore.Server.Domain.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Runtime;
//using MongoDB.Entities;
//using Microsoft.EntityFrameworkCore;
//using MongoDB.EntityFrameworkCore.Extensions;



public class ApplicationDbContext
{

    private readonly IMongoDatabase _mongoDatabase;
    private readonly IOptions<MongoSettings> _DBSettings;

    public IMongoCollection<Glass> Glass;

    //private readonly ILogger<ApplicationDbContext> _logger; 

    public IMongoCollection<T> dbSet<T>()
    {
        return _mongoDatabase.GetCollection<T>(_DBSettings.Value.CollectionName);
    }


    public ApplicationDbContext(IOptions<MongoSettings> DBSettings)
    {
        //if (TestConnection(DBSettings))
        //{
        //    _logger.LogInformation("MongoDB connection established");
        //}
        //else
        //{
        //    _logger.LogError("MongoDB connection failed");
        //}
        _DBSettings = DBSettings;

        var mongoClient = new MongoClient(DBSettings.Value.ConnectionString);
        _mongoDatabase = mongoClient.GetDatabase(DBSettings.Value.DatabaseName);
        
        OnConfiguring();
        
    }


    protected void OnConfiguring()
    {
        Glass = dbSet<Glass>();
    }



    //public bool TestConnection(IOptions<MongoSettings> DBSettings)
    //{
    //    try
    //    {
    //        var mongoClient = new MongoClient(DBSettings.Value.ConnectionString);
    //        var mongoDatabase = mongoClient.GetDatabase(DBSettings.Value.DatabaseName);
    //        return mongoDatabase.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait(1000);
    //    }
    //    catch
    //    {
    //        return false;
    //    }
    //}
}
