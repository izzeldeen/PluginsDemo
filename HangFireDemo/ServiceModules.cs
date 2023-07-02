using Autofac;
using BLogic;

namespace HangFireDemo
{
    public class ServiceModules : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<MerchantService>().As<ITaskServices>();
        }
    }
}
