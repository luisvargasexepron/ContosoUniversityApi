using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ContosoUniversityApi.Models;
using FluentAssertions;
using Xunit;

namespace ContosoUniversityApi.IntegrationTests.Tests;

public class StudentControllerTests : IClassFixture<ContosoUniversityApiFixture>
{
    private readonly HttpClient _client;

    public StudentControllerTests(ContosoUniversityApiFixture fixture) =>
        _client = fixture.HttpClient;


    [Fact]
    public async Task TestGetById()
    {
        var result = await _client.GetFromJsonAsync<Student>("api/Students/1");
        result.id.Should().Be(1);
        result.firstName.Should().Be("Carson");
        result.lastName.Should().Be("Alexander");
        result.fullName.Should().Be("Alexander, Carson");
        result.enrollmentDate.Should().Be(DateTime.Parse("9/1/2016 12:00:00 AM"));
    }
}