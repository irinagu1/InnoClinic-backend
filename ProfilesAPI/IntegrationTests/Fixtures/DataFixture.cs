using Bogus;
using Entities.Models;

namespace IntegrationTests.Fixtures;

public class DataFixture
{
    public static List<Doctor> GetDoctors(int count, bool useNewSeed = false)
        => GetDoctorFaker(useNewSeed).Generate(count);

    public static Doctor GetDoctor(bool useNewSeed = false)
        => GetDoctors(1, useNewSeed)[0];

    private static Faker<Doctor> GetDoctorFaker(bool useNewSeed)
    {
        var seed = 0;
        if(useNewSeed)
            seed = Random.Shared.Next(10, int.MaxValue);

        var faker = new Faker<Doctor>()
            .RuleFor(d => d.DoctorId, v => v.Random.Guid().ToString())
            .RuleFor(d => d.EntityStatus, v => "Created")
            .RuleFor(d => d.FirstName, (f, t) => f.Name.FirstName())
            .RuleFor(d => d.LastName, (f, t) => f.Name.LastName())
            .RuleFor(d => d.DateOfBirth, v => DateOnly.FromDateTime(v.Date.Past()))
            .RuleFor(d => d.SpecializationId, v => Convert.ToString(v.Random.Int(1,100)))
            .RuleFor(d => d.OfficeId, v => Convert.ToString(v.Random.Int(1,100)))
            .RuleFor(d => d.CareerStartYear, v => v.Random.Int(1950, 2026))
            .RuleFor(d => d.Status, v => "At work")
            .UseSeed(seed);
        
        return faker;
    }

}