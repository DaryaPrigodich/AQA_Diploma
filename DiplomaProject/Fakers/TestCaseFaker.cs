using Bogus;
using DiplomaProject.Models;

namespace DiplomaProject.Fakers;

public class TestCaseFaker : Faker<TestCase>
{
    public TestCaseFaker()
    {
        RuleFor(m => m.Title, f => f.Company.CatchPhrase());
        RuleFor(m => m.Description, f => f.Company.CatchPhrase());
    }
}
