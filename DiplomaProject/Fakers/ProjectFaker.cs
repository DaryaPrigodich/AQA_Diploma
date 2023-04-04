using Bogus;
using DiplomaProject.Models;

namespace DiplomaProject.Fakers;

public class ProjectFaker : Faker<Project>
{
    public ProjectFaker()
    {
        RuleFor(c => c.Title, f => f.Lorem.Word());
        RuleFor(c => c.Code, f => f.Lorem.Word());
    }
}
