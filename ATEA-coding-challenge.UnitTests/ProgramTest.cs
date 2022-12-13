using ATEA_coding_challenge.Extensions;
using ATEA_coding_challenge.Extensions.Interfaces;

namespace ATEA_coding_challenge.UnitTests;

[TestFixture]
public class Tests
{
    private string[] _args, _moreThanTwoNumbers, _twoNulls;
    private IWrapper _wrapperNulls, _wrapperTooMany;
    [SetUp]
    public void Setup()
    {
        _args = new[] {"Cupcake","Cake"};
        _moreThanTwoNumbers = new[] { "Banana", "Apple", "Chinotto" };
        _twoNulls = new string[] { null, null };
        _wrapperNulls = new ExtensionWrapper(_twoNulls);
        _wrapperTooMany = new ExtensionWrapper(_moreThanTwoNumbers);
    }

    [Test]
    public void AreArgumentsIntReturnString()
    {
        var result = _args.SumFirstTwoArgs();
        Assert.That(result, Is.Not.Empty);
    }
    
    [Test]
    public void AreArgumentsFloatReturnString()
    {
        var result = _args.SumFirstTwoArgs();
        Assert.That(result, Is.Not.Empty);
    } 
    
    [Test]
    public void AreArgumentsStringReturnString()
    {
        var result = _args.SumFirstTwoArgs();
        Assert.That(result, Is.Not.Empty);
    }
    
    [Test]
    public void AreArgumentsTooManyThrowException()
    {
        Assert.That(() => _wrapperTooMany.WriteResult(_moreThanTwoNumbers), 
            Throws.Exception
                .TypeOf<Exception>()
                .With.Property("Message")
                .EqualTo("Wrong number of arguments."));
    }
    
    [Test]
    public void AreArgumentsNullThrowException()
    {
        Assert.That(() => _twoNulls.SumFirstTwoArgs(), 
            Throws.Exception
                .TypeOf<Exception>()
                .With.Property("Message")
                .EqualTo("Either one or both arguments are null."));
    }
}