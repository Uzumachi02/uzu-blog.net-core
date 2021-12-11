using System.Reflection;
using DbUp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Uzumachi.UzuBlog.Migrations;

public class DatabaseInitializer {

  public static void Migrations(IServiceProvider serviceProvider) {
    using var scope = serviceProvider.CreateScope();

    IConfiguration configuration = scope.ServiceProvider.GetService<IConfiguration>();

    var upgrader =
        DeployChanges.To
          .PostgresqlDatabase(configuration.GetConnectionString("DefaultConnection"))
          .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
          .LogToConsole()
          .Build();

    if( upgrader.IsUpgradeRequired() ) {
      var result = upgrader.PerformUpgrade();
    }
  }
}

