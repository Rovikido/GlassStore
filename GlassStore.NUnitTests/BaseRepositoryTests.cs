using GlassStore.Server.Domain;
using GlassStore.Server.Domain.Models.Glass;
using GlassStore.Server.Repositories.Implementations;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

[TestFixture]
public class BaseRepositoryTests
{
    private IMongoCollection<Glasses>? _collection;
    private BaseRepository<Glasses>? _repository;

    [SetUp]
    public void Setup()
    {
        var settings = new MongoSettings { ConnectionString = "mongodb://localhost:27017", DatabaseName = "TestDatabase" };
        var options = Options.Create(settings);

        var context = new ApplicationDbContext(options);

        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);
        _collection = database.GetCollection<Glasses>("Glasses");

        _repository = new BaseRepository<Glasses>(context);

        // Очистите коллекцию перед каждым тестом
        _collection.DeleteMany(new BsonDocument());
    }

    [Test]
    public async Task GetAllAsync_ShouldReturnAllItems()
    {
        var glasses = new Glasses();
        await _collection.InsertOneAsync(glasses);

        var result = (await _repository!.GetAllAsync()).ToList();
        //var result = await _repository!.GetAllAsync();

        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result[0].ToString(), Is.EqualTo(glasses.ToString()));
        Assert.That(result[0].Id, Is.EqualTo(glasses.Id));
    }
}

//using NUnit.Framework;
//using Moq;
//using MongoDB.Driver;
//using System.Collections.Generic;
//using System.Threading;
//using System.Threading.Tasks;
//using GlassStore.Server.Domain.Models.Glass;
//using GlassStore.Server.Repositories.Implementations;
//using GlassStore.Server.Repositories.Interfaces;

//[TestFixture]
//public class BaseRepositoryTests
//{
//    private Mock<IMongoCollection<Glasses>>? _mockCollection;
//    private Mock<ApplicationDbContext>? _mockContext;
//    private Mock<IAsyncCursor<Glasses>>? _mockCursor;
//    private Glasses? _glasses;
//    private BaseRepository<Glasses>? _repository;

//    [SetUp]
//    public void Setup()
//    {
//        _glasses = new Glasses();
//        _mockCollection = new Mock<IMongoCollection<Glasses>>();
//        _mockContext = new Mock<ApplicationDbContext>();
//        _mockCursor = new Mock<IAsyncCursor<Glasses>>();

//        _mockContext.Setup(c => c.dbSet<Glasses>()).Returns(_mockCollection.Object);
//        _mockCursor.SetupSequence(c => c.MoveNext(It.IsAny<CancellationToken>()))
//            .Returns(true)
//            .Returns(false);
//        _mockCursor.Setup(c => c.Current).Returns(new List<Glasses> { _glasses });
//        _mockCollection.Setup(c => c.FindAsync(
//            It.IsAny<FilterDefinition<Glasses>>(),
//            It.IsAny<FindOptions<Glasses, Glasses>>(),
//            It.IsAny<CancellationToken>()
//        )).ReturnsAsync(_mockCursor.Object);

//        _repository = new BaseRepository<Glasses>(_mockContext.Object);
//    }

//    [Test]
//    public async Task GetAllAsync_ShouldReturnAllItems()
//    {
//        var result = (await _repository!.GetAllAsync()).ToList();

//        Assert.That(result.Count, Is.EqualTo(1));
//        Assert.That(result[0], Is.EqualTo(_glasses));
//    }
//}