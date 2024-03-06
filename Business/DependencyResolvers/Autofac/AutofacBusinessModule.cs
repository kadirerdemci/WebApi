using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Helper;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    //Bu teknolojiyi NuGet'ten indirdik Ioc kontrolün AutoFac tarafından yapılabilmesi için 
    //aşağıda görüldüğü gibi interface ve sınıflarımızı tanımladık 
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
   
            builder.RegisterType<FileHelperManager>().As<IFileHelper>().SingleInstance();
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();




          
            builder.RegisterType<EfUsersDal>().As<IUserDal>().SingleInstance();
      





            //bu kod bloğu diyor ki bu diğer kodları çalıştırmadan önce bi git bak İnterceptorler varmı
            //Varsa eğer interceptorlardaki validation,cashe,loglama vs gibi sınıfları çalıştırır
            //sonra ilgili sınıfların methodlarını çalıştırır
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
