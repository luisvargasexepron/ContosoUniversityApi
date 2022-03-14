using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ContosoUniversityApi.Models;
using FluentAssertions;
using Xunit;

namespace ContosoUniversityApi.IntegrationTests.Tests;

public class InstructorsControllerTests : IClassFixture<ContosoUniversityApiFixture>
{
    private readonly HttpClient _client;

    public InstructorsControllerTests(ContosoUniversityApiFixture fixture) =>
        _client = fixture.HttpClient;


    [Fact]
    public async Task TestGetById()
    {
        var result = await _client.GetStringAsync("api/Instructors/1");
        result.Should().Be("{\"id\":1,\"lastName\":\"Abercrombie\",\"firstName\":\"Kim\"," +
                           "\"hireDate\":\"1995-03-11T00:00:00\",\"fullName\":\"Abercrombie, Kim\"," +
                           "\"courseInstructors\":null,\"courses\":null,\"officeAssignment\":null}");
    }
}