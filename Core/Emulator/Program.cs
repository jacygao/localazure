using KeyController;
using Emulator.Controllers.KeyVault.KeyController;
using Emulator.Controllers.KeyVault.CertificateController;
using Emulator.Providers.StoreProvider;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IStoreProvider, InMemoryStoreProvider>();

// Register the IController implementation
builder.Services.AddScoped<KeyController.IController, KeyControllerImpl>();
builder.Services.AddScoped<CertificateController.IController, CertificateControllerImpl>();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API V1"
    });

    c.TagActionsBy(api =>
    {
        if (api.GroupName != null)
        {
            return new[] { api.GroupName };
        }
        if (api.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
        {
            return new[] { controllerActionDescriptor.ControllerName };
        }
        throw new InvalidOperationException("Unable to determine tag for endpoint.");
    });
    c.DocInclusionPredicate((name, api) => true);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
