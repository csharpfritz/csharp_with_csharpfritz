using Microsoft.Extensions.Logging.Abstractions;
using MyCollectionSite.Controllers;
using MyCollectionSite.Models;

namespace test;

public class WhenNavigatingToTheHomePage
{

    [Fact]
    public void ShouldGetItemsFromCollection()
    {

        // arrange
        var repo = new Moq.Mock<ICollectionRepository>();
        var sut = new HomeController(
            NullLogger<HomeController>.Instance, 
            repo.Object
        );

        // act
        _ = sut.Index();

        // assert
        repo.Verify(r => r.Get(), Moq.Times.Once);

    }


}