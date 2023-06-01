using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Helpers.Abstracts;
using BusinessLayer.Helpers.Concrete;
using BusinessLayer.Helpers.Concrete.Uploader;
using BusinessLayer.ValidationRule.Announcements;
using BusinessLayer.ValidationRule;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using BusinessLayer.Abstract.AbstractUow;
using BusinessLayer.Concrete.ConcreteUow;
using DataAccessLayer.Abstract.AbstractUow;
using DataAccessLayer.EntityFramework.EntityFrameworkUow;
using DataAccessLayer.UnitOfWork;
using DTOLayer.DTOs.ContactUsDTOs;

namespace BusinessLayer.Container
{
    public static  class Extensions
    {
        public static void ContainerDependencies(IServiceCollection services)
        {
            services.AddScoped<IFileOperationsAbstract,FileOperations>();
            services.AddScoped<IMailer,Mailer>();

            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentDal, EfCommentDal>();

            services.AddScoped<IDestinationService, DestinationManager>();
            services.AddScoped<IDestinationDal, EfDestinationDal>();

            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUserDal, EfAppUserDal>();

            services.AddScoped<IReservationService, ReservationManager>();
            services.AddScoped<IReservationDal, EfReservationDal>();

            services.AddScoped<IGuideService, GuideManager>();
            services.AddScoped<IGuideDal, EfGuideDal>();

            services.AddScoped<IContactUsService, ContactUsManager>();
            services.AddScoped<IContactUsDal, EfContactUsDal>();

            services.AddScoped<IAnnouncementService, AnnouncementManager>();
            services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();

           
            services.AddScoped<IAccountService, AccountManager>();
            services.AddScoped<IAccountDal, EfAccountDal>();

            services.AddScoped<IRoleService, RoleManager>();
            services.AddScoped<IRoleDal, EfRoleDal>();

            services.AddScoped<IUowDal, UnitOfWorkDal>();

            services.AddScoped<IExcelService, ExcelManager>();
            services.AddScoped<IPdfService, PdfManager>();

            

        }

        public static void CustomValidator(this IServiceCollection services) 
        {

            services.AddTransient<IValidator<Destination>, DestinationValidator>();
            services.AddTransient<IValidator<AnnouncementAddDTO>, AnnouncementAddValidator>();
            services.AddTransient<IValidator<AnnouncementUpdateDTO>, AnnouncementUpdateValidator>();
            services.AddTransient<IValidator<AddContactUsDTO>, ContactUsValidator>();
        }
    }
}
