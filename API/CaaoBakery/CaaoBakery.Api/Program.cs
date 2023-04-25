using CaaoBakery.Api.Filters;
using CaaoBakery.Api.Middleware;
using CaaoBakery.Application;
using CaaoBakery.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{


    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

   

    builder.Services.AddControllers(options=> options.Filters.Add<ErrorHandlingFilterAttribute>());

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();
{
    app.UseMiddleware<ErrorHandlingMiddleware>();
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}




