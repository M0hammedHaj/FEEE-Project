using FEEE.Application.Extensions;
using FEEE.Application.Interfaces;
using FEEE.Application.UseCases.HigherYearRequests.CancelHigherYearRequestService;
using FEEE.Application.UseCases.HigherYearRequests.CreateHigherYearRequestServices;
using FEEE.Application.UseCases.HigherYearRequests.GetHigherYearRequestByIdUseCase;
using FEEE.Application.UseCases.HigherYearRequests.GetHigherYearRequestsService;
using FEEE.Application.UseCases.HigherYearRequests.UpdateHigherYearRequestService;
using FEEE.Application.UseCases.OldStudent.GetAllOldStudent;
using FEEE.Application.UseCases.OldStudent.GetByIdOldStudent;
using FEEE.Infrastructure.Extensions;
using FEEE.Infrastructure.Persistence.Context;
using FEEE.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler =
            System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });
builder.Services.AddDbContext<WinDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WinConnection")));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();

builder.Services.AddScoped<IOldStudentRepository, OldStudentRepository>();
builder.Services.AddScoped<ListOldStudentsService>();
builder.Services.AddScoped<GetOldStudentByIdService>();

builder.Services.AddScoped<CreateHigherYearRequestService>();
builder.Services.AddScoped<GetAllHigherYearRequestsService>();
builder.Services.AddScoped<GetHigherYearRequestByIdUseCase>();
builder.Services.AddScoped<UpdateHigherYearRequestService>();
builder.Services.AddScoped<CancelHigherYearRequestService>();


builder.Services.AddInfrastructure(builder.Configuration);
QuestPDF.Settings.License = LicenseType.Community;
var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
