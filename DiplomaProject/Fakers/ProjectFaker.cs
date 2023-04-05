using Bogus;
using DiplomaProject.Models;

namespace DiplomaProject.Fakers;

public class ProjectFaker : Faker<Project>
{
    private const int MinCodeLength = 2;
    private const int MaxCodeLength = 9;

    private readonly int CodeLength = new Faker().Random.Number(MinCodeLength, MaxCodeLength);

    public ProjectFaker()
    {
        RuleFor(c => c.Title, f => f.Lorem.Word());
        RuleFor(c => c.Code, f => f.Lorem.Letter(CodeLength));
    }
}
