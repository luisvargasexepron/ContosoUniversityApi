using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AppContext = ContosoUniversityApi.Data.AppContext;

namespace ContosoUniversityApi.IntegrationTests;

public class ContosoUniversityApiFixture : IDisposable
{
    private WebApplicationFactory<Program> _factory;
    public HttpClient HttpClient => _factory.CreateClient();

    public ContosoUniversityApiFixture()
    {
        _factory = new WebApplicationFactory<Program>();
    }

    public void Dispose()
    {
        // TODO: Find a better way to handle db disposing
        var db = _factory.Services
            .GetService<IServiceScopeFactory>()
            ?.CreateScope().ServiceProvider.GetService<AppContext>();
        db.Database.EnsureDeletedAsync();
        db.Database.CloseConnection();
        
        _factory.Dispose();
    }
}