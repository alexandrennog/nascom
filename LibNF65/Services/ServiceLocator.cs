using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibNF65.Services
{
    public static class ServiceLocator
    {
        private static IServiceProvider _serviceProvider;

        public static void Configure(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public static T GetService<T>() where T : class
        {
            return _serviceProvider.GetService(typeof(T)) as T
                   ?? throw new InvalidOperationException($"Serviço do tipo {typeof(T).Name} não encontrado.");
        }
    }


}
