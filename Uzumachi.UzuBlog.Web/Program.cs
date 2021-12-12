using Npgsql;
using System.Data;
using Uzumachi.UzuBlog.Migrations;

var builder = WebApplication.CreateBuilder(args);

Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// dependency injection
builder.Services.AddTransient<IDbConnection>(_ => new NpgsqlConnection(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if( app.Environment.IsDevelopment() ) {
  GeneratorScripts generator = new();

  generator.Run();

  using( var scope = app.Services.CreateScope() ) {
    DatabaseInitializer.Migrations(scope.ServiceProvider);
  }

  app.UseDeveloperExceptionPage();
} else {
  app.UseExceptionHandler("/Home/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
