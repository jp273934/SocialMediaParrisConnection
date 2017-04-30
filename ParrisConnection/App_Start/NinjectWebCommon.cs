using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.ServiceLayer.Services;
using ParrisConnection.ServiceLayer.Services.Comments.Save;
using ParrisConnection.ServiceLayer.Services.Education.Queries;
using ParrisConnection.ServiceLayer.Services.Education.Save;
using ParrisConnection.ServiceLayer.Services.Email.Queries;
using ParrisConnection.ServiceLayer.Services.Email.Save;
using ParrisConnection.ServiceLayer.Services.Employer.Queries;
using ParrisConnection.ServiceLayer.Services.Employer.Save;
using ParrisConnection.ServiceLayer.Services.Phone.Queries;
using ParrisConnection.ServiceLayer.Services.Phone.Save;
using ParrisConnection.ServiceLayer.Services.ProfilePhoto.Queries;
using ParrisConnection.ServiceLayer.Services.ProfilePhoto.Save;
using ParrisConnection.ServiceLayer.Services.Quote.Queries;
using ParrisConnection.ServiceLayer.Services.Quote.Save;
using ParrisConnection.ServiceLayer.Services.Status.Queries;
using ParrisConnection.ServiceLayer.Services.Status.Save;
using ParrisConnection.ServiceLayer.Services.Wall;
using ParrisConnection.ServiceLayer.ViewModelServices.ProfileView;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ParrisConnection.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(ParrisConnection.App_Start.NinjectWebCommon), "Stop")]

namespace ParrisConnection.App_Start
{
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using System;
    using System.Web;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IDataAccess>().To<DataAccess>();
            kernel.Bind<IWallService>().To<WallService>();
            kernel.Bind<IProfileViewService>().To<ProfileViewService>();
            kernel.Bind<ICommentSaveService>().To<CommentSaveService>();
            kernel.Bind<IEducationQueryService>().To<EducationQueryService>();
            kernel.Bind<IEducationSaveService>().To<EducationSaveService>();
            kernel.Bind<IEmailQueryService>().To<EmailQueryService>();
            kernel.Bind<IEmailSaveService>().To<EmailSaveService>();
            kernel.Bind<IEmployerQueryService>().To<EmployerQueryService>();
            kernel.Bind<IEmployerSaveService>().To<EmployerSaveService>();
            kernel.Bind<IPhoneQueryService>().To<PhoneQueryService>();
            kernel.Bind<IPhoneSaveService>().To<PhoneSaveService>();
            kernel.Bind<IProfilePhotoQueryService>().To<ProfilePhotoQueryService>();
            kernel.Bind<IProfilePhotoSaveService>().To<ProfilePhotoSaveService>();
            kernel.Bind<IQuoteQueryService>().To<QuoteQueryService>();
            kernel.Bind<IQuoteSaveService>().To<QuoteSaveService>();
            kernel.Bind<IStatusQueryService>().To<StatusQueryService>();
            kernel.Bind<IStatusSaveService>().To<StatusSaveService>();
        }        
    }
}
