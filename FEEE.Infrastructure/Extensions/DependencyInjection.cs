using FEEE.Application.Interfaces;
using FEEE.Domain.Interfaces;
using FEEE.Domain.Repositories;
using FEEE.Infrastructure.Persistence.Context;
using FEEE.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FEEE.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<ICityRepository, CityRepository>();
        services.AddScoped<ISectionRepository, SectionRepository>();
        services.AddScoped<IYearRepository, YearRepository>();
        services.AddScoped<ISubjectRepository, SubjectRepository>();
        services.AddScoped<IStudentPromotionRepository, StudentPromotionRepository>();
        services.AddScoped<IStudentSubjectRepository, StudentSubjectRepository>();
        services.AddScoped<IStudentArchiveRepository, StudentArchiveRepository>();
        services.AddScoped<IOperationTypeRepository, OperationTypeRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ISemesterRepository, SemesterRepository>();
        services.AddScoped<IHigherYearRequestRepository, HigherYearRequestRepository>();


        return services;
    }
}
