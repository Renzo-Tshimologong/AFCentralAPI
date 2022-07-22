using Microsoft.EntityFrameworkCore;
using AFCentral.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<StakeholderContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Azure")));
builder.Services.AddDbContext<ProgrammeContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Azure")));

builder.Services.AddDbContext<CurriculumContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Azure")));

builder.Services.AddDbContext<RepositoryContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Azure")));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
