using FEEE.Application.UseCases.City.CreateCity;
using FEEE.Application.UseCases.City.GetCityById;
using FEEE.Application.UseCases.City.ListCities;
using FEEE.Application.UseCases.City.UpdateCity;
using FEEE.Application.UseCases.HigherYearRequests.CreateHigherYearRequestServices;
using FEEE.Application.UseCases.HigherYearRequests.GetHigherYearRequestByIdUseCase;
using FEEE.Application.UseCases.HigherYearRequests.GetHigherYearRequestsService;
using FEEE.Application.UseCases.OperationType.CreateOperationType;
using FEEE.Application.UseCases.OperationType.GetOperationTypeById;
using FEEE.Application.UseCases.OperationType.GetOperationTypes;
using FEEE.Application.UseCases.OperationType.UpdateOperationType;
using FEEE.Application.UseCases.Section.CreateSection;
using FEEE.Application.UseCases.Section.GetSectionById;
using FEEE.Application.UseCases.Section.ListSections;
using FEEE.Application.UseCases.Section.UpdateSection;
using FEEE.Application.UseCases.Student.ArchiveStudent;
using FEEE.Application.UseCases.Student.CreateStudent;
using FEEE.Application.UseCases.Student.GetStudentById;
using FEEE.Application.UseCases.Student.ListStudents;
using FEEE.Application.UseCases.Student.SearchStudents;
using FEEE.Application.UseCases.Student.UpdateStudent;
using FEEE.Application.UseCases.StudentArchive.CreateStudentArchive;
using FEEE.Application.UseCases.StudentArchive.GetAllStudentsArchive;
using FEEE.Application.UseCases.StudentArchive.GetByOperationType;
using FEEE.Application.UseCases.StudentArchive.GetStudentArchivesByStudentId;
using FEEE.Application.UseCases.StudentPromotion.CreateStudentPromotion;
using FEEE.Application.UseCases.StudentPromotion.GetStudentPromotionsByStudentId;
using FEEE.Application.UseCases.StudentSubject.FailStudentSubject;
using FEEE.Application.UseCases.StudentSubject.GetStudentSubjects;
using FEEE.Application.UseCases.StudentSubject.PassStudentSubject;
using FEEE.Application.UseCases.Subject.CreateSubject;
using FEEE.Application.UseCases.Subject.DeleteSubject;
using FEEE.Application.UseCases.Subject.GetSubjectbyId;
using FEEE.Application.UseCases.Subject.GetSubjects;
using FEEE.Application.UseCases.Subject.UpdateSubject;
using FEEE.Application.UseCases.User.CreateUser;
using FEEE.Application.UseCases.User.DeleteUser;
using FEEE.Application.UseCases.User.GetAllUsers;
using FEEE.Application.UseCases.User.GetUserById;
using FEEE.Application.UseCases.Year.CreateYear;
using FEEE.Application.UseCases.Year.GetYearById;
using FEEE.Application.UseCases.Year.ListYears;
using FEEE.Application.UseCases.Year.UpdateYear;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;



namespace FEEE.Application.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
     this IServiceCollection services)
        {
            // MediatR
            services.AddMediatR(Assembly.GetExecutingAssembly());

            // Validators
            services.AddValidatorsFromAssembly(
                Assembly.GetExecutingAssembly());

            // User UseCases
            services.AddScoped<CreateUserService>();
            services.AddScoped<GetAllUsersService>();
            services.AddScoped<GetUserByIdService>();
            services.AddScoped<DeleteUserService>();

            // Student UseCases
            services.AddScoped<CreateStudentService>();
            services.AddScoped<UpdateStudentService>();
            services.AddScoped<GetStudentByIdService>();
            services.AddScoped<ListStudentsService>();
            services.AddScoped<ArchiveStudentService>();

            //Year UseCases
            services.AddScoped<CreateYearService>();
            services.AddScoped<GetYearByIdService>();
            services.AddScoped<ListYearsService>();
            services.AddScoped<UpdateYearService>();

            //City Usecase
            services.AddScoped<CreateCityService>();
            services.AddScoped<GetCityByIdService>();
            services.AddScoped<ListCitiesService>();
            services.AddScoped<UpdateCityService>();

            // Operation type
            services.AddScoped<CreateOperationTypeService>();
            services.AddScoped<GetOperationTypeByIdService>();
            services.AddScoped<ListOperationTypesService>();
            services.AddScoped<UpdateOperationTypeService>();

            //section
            services.AddScoped<CreateSectionService>();
            services.AddScoped<GetSectionByIdService>();
            services.AddScoped<ListSectionsService>();
            services.AddScoped<UpdateSectionService>();

            // Student
            services.AddScoped<CreateStudentService>();
            services.AddScoped<UpdateStudentService>();
            services.AddScoped<GetStudentByIdService>();
            services.AddScoped<ListStudentsService>();
            services.AddScoped<ArchiveStudentService>();
            services.AddScoped<SearchStudentsService>();

            // StudentArchive
            services.AddScoped<CreateStudentArchiveService>();
            services.AddScoped<GetStudentArchivesByStudentIdService>();
            services.AddScoped<GetStudentArchiveByOperationTypeService>();
            services.AddScoped<GetAllStudentsArchivesService>();

            // StudentPromotion
            services.AddScoped<CreateStudentPromotionService>();
            services.AddScoped<GetStudentPromotionsByStudentIdService>();


            // StudentSubject
            services.AddScoped<FailStudentSubjectService>();
            services.AddScoped<PassStudentSubjectService>();
            services.AddScoped<GetStudentSubjectsService>();

            // Subject
            services.AddScoped<CreateSubjectService>();
            services.AddScoped<UpdateSubjectService>();
            services.AddScoped<DeleteSubjectService>();
            services.AddScoped<GetSubjectByIdService>();
            services.AddScoped<GetAllSubjectsService>();

            services.AddScoped<CreateHigherYearRequestService>();
            services.AddScoped<GetHigherYearRequestsService>();
            services.AddScoped<GetHigherYearRequestByIdUseCase>();
            return services;
        }

    }
}
