using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Dynamic.Core;

namespace Seamas.EFQuery.Test;


public class Tests
{
    private DbContextOptions<MovieDbContext> _options;
    
    [SetUp]
    public void Setup()
    {
        // TODO: Replace with your actual connection string
        var connectionString = "";
        _options = new DbContextOptionsBuilder<MovieDbContext>()
            .UseNpgsql(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .Options;
    }

    [Test]
    public void Test1()
    {
        using var context = new MovieDbContext(_options);
        var searchOption = new SearchOption
        {
            Title = "你好",
            Name = "张三",
            Likes = 20,
            Alias = "比较像",
            TestLike = new []{ 50, 60 }
        };

        var (cond, param) = QueryAttributeHelper.Visit(searchOption);
        var movies = context.Set<Movie>()
            .Where(cond, param)
            .Where(item => item.Likes > 10)
            .ToList();
        
        Console.WriteLine();
    }
}