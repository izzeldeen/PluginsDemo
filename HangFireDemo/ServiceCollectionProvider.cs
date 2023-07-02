using BLogic;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangFireDemo
{
    public static  class ServiceCollectionProvider
    {
        public static Func<Type, Type, IServiceCollection> RegisterService;
        public static IServiceCollection ServiceCollections;
        public static ServiceProvider ServiceProvider;
        public static Func<IServiceCollection ,ServiceProvider> buildService = (serviceCollection) =>  serviceCollection.BuildServiceProvider();
    }
}
