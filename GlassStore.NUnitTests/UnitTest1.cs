using Moq;

namespace GlassStore.NUnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}


//public class BaseRepositoryTests
//{
//    private readonly Mock<ApplicationDbContext> _dbContextMock;
//    private readonly Mock<IMongoCollection<Glass>> _dataMock;
//    private readonly BaseRepository<Glass> _repository;

//    public BaseRepositoryTests()
//    {
//        _dbContextMock = new Mock<ApplicationDbContext>();
//        _dataMock = new Mock<IMongoCollection<Glass>>();
//        _repository = new BaseRepository<Glass>(_dbContextMock.Object);

//        _dbContextMock.Setup(db => db.dbSet<Glass>()).Returns(_dataMock.Object);
//    }

//    [Fact]
//    public async Task GetAllAsync_ShouldReturnAllData()
//    {
//        // Arrange
//        var testData = new List<Glass>
//            {
//                new Glass { Id = "1", Name = "Glass 1" },
//                new Glass { Id = "2", Name = "Glass 2" },
//                new Glass { Id = "3", Name = "Glass 3" }
//            };
//        var expectedData = testData.AsEnumerable();
//        _dataMock.Setup(data => data.FindAsync(It.IsAny<FilterDefinition<Glass>>(), null))
//            .ReturnsAsync(new Mock<IAsyncCursor<Glass>>().Object);
//        _dataMock.Setup(data => data.FindAsync(It.IsAny<FilterDefinition<Glass>>(), null).Result.ToListAsync())
//            .ReturnsAsync(testData);

//        // Act
//        var result = await _repository.GetAllAsync();

//        // Assert
//        Assert.Equal(expectedData, result);
//    }

//    // Add more test methods for other repository methods

//}
