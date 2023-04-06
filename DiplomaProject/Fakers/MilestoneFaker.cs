using Bogus;
using DiplomaProject.Models;

namespace DiplomaProject.Fakers;

public class MilestoneFaker : Faker<Milestone>
{
    public MilestoneFaker(int lengthOfTitle)
    {
        RuleFor(c => c.Title, f => f.Lorem.Letter(lengthOfTitle));
        RuleFor(c => c.Description, f => f.Company.CatchPhrase());
    }
}
