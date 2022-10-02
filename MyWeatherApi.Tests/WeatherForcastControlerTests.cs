using Microsoft.Extensions.Logging;
using MyWeatherApi.Controllers;

namespace MyWeatherApi.Tests;

public class Tests
{
    private WeatherForecastController myController;
    private ILogger<WeatherForecastController> _logger;

    [SetUp]
    public void Setup()
    {
        this._logger = Mock.Of<ILogger<WeatherForecastController>>();
        this.myController = new WeatherForecastController(_logger);
    }

    [Test]
    public void WeatherForecast_Get_Should_Return_Data()
    {
        Assert.IsNotNull(this.myController.Get());
    }
    
    [Test]
    public void WeatherForecast_Get_By_ZipCode_Given_NoArgument_Throw_ArgumentException()
    {
        Assert.Throws<ArgumentNullException>(() => this.myController.GetByZipCode(null));
    }
    
    [Test]
    public void WeatherForecast_Get_By_ZipCode_Given_ZipCode_Return_Data()
    {
        Assert.IsInstanceOf(typeof(WeatherForecast),this.myController.GetByZipCode("92220"));
    }
}