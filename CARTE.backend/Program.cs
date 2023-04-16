using CARTE.backend.Core.Domain;
using CARTE.backend.Core.Domain.Interfaces;
using CARTE.backend.Core.Infrastructure;
using CARTE.backend.Core.Infrastructure.Card.Commands.CreateCard;
using CARTE.backend.Core.Infrastructure.Card.Commands.DeleteCard;
using CARTE.backend.Core.Infrastructure.Card.Commands.UpdateCard;
using CARTE.backend.Core.Infrastructure.Card.Queries.GetBusinessCardDetail;
using CARTE.backend.Core.Infrastructure.Card.Queries.GetListCards;
using CARTE.backend.Core.Infrastructure.Users.Commands.CreateUser;
using CARTE.backend.Core.Infrastructure.Users.Commands.LoginUser;
using CARTE.backend.Core.Infrastructure.Users.Commands.SetLocation;
using CARTE.backend.Core.Infrastructure.Users.Queries.GetUserDetail;
using CARTE.backend.Core.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DBContext>(opt => opt
    .UseNpgsql(builder.Configuration.GetConnectionString("DbConnection")));

using (var scope = builder.Services.BuildServiceProvider())
{
    try
    {
        var context = scope
            .GetRequiredService<DBContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception ex)
    {
        var logger = scope.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while app initialization");
    }
}

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IBusinessCardContext).Assembly));
    config.AddProfile(new AssemblyMappingProfile(typeof(IUserContext).Assembly));
});

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});

builder.Services.AddScoped<IBusinessCardContext>(provider => provider.GetService<DBContext>());
builder.Services.AddScoped<IUserContext>(provider => provider.GetService<DBContext>());

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetUserDetailQueryHandler>());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<LoginUserCommandHandler>());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateUserCommandHandler>());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<SetLocationCommandHandler>());

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetListCardsQueryHandler>());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetBusinessCardQueryHandler>());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateCardCommandHandler>());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<UpdateCardCommandHandler>());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<DeleteCardCommandHandler>());

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
