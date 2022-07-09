using System;
using System.Collections.Generic;
using DojoProject.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.EntityFrameworkCore;
using DojoProject.Infrastructure.Context;
using Microsoft.Extensions.DependencyInjection;
using DojoProject.Domain.Ports;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DojoProject.Api.Tests;

class IntegrationTestBuilder : WebApplicationFactory<Program>
{

    readonly Guid _id;

    public Guid Id => this._id;

    public IntegrationTestBuilder()
    {
        _id = Guid.NewGuid();
    }

    protected override IHost CreateHost(IHostBuilder builder)
    {
        var rootDb = new InMemoryDatabaseRoot();

        builder.ConfigureServices(services =>
        {
            services.RemoveAll(typeof(DbContextOptions<PersistenceContext>));
            services.AddDbContext<PersistenceContext>(options =>
                    options.UseInMemoryDatabase("Testing", rootDb));

        });

        SeedDatabase(builder.Build().Services);

        return base.CreateHost(builder);


    }

    void SeedDatabase(IServiceProvider services)
    {
        /*
        var People = new List<Person>
            {
                new Person
                {
                    Id = _id, Address = "Cra 12 # 12 - 21", Name = "John", Age = "21"
                }
            };
        

        using (var scope = services.CreateScope())
        {
            var personRepo = scope.ServiceProvider.GetRequiredService<IGenericRepository<Person>>();
            foreach (var person in People)
            {
                personRepo.AddAsync(person).Wait();
            }
        }
        */
    }
}