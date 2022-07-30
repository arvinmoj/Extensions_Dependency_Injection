# region Using
using Microsoft.Extensions.DependencyInjection;
# endregion \ Using

namespace Application
{
    public static class Program : Object
    {
        static Program()
        {
        }

        public static void Main()
        {

            #region Pure DependencyInjection
            // Logger.Interfaces.ILogger
            //     logger = new Logger.Logger();

            // Logger.SomeClass someClass =
            //     new Logger.SomeClass(logger: logger);

            // string fullName = "Senior Martian";
            // someClass.DoSomething(fullName: fullName);
            # endregion \ Pure DependencyInjection

            RegisterServices();

            IServiceScope scope = MyServiceProvider.CreateScope();
            string fullName = "Senior Martian";
            scope.ServiceProvider.GetRequiredService<Logger.SomeClass>()
                .DoSomething(fullName: fullName);

            DisposeServiceProvider();

            #region Console Read Line 
            Console.WriteLine("Press [Enter] To Exit ...");
            Console.ReadLine();
            # endregion \ Console Read Line 

        }

        // Service Provider
        private static ServiceProvider MyServiceProvider { get; set; }

        // Register Services
        # region RegisterServicesFunction
        private static void RegisterServices()
        {

            var services = new ServiceCollection();

            // services.AddScoped<Logger.SomeClass>();
            // services.AddScoped<Logger.Interfaces.ILogger, Logger.Logger>();

            // services.AddSingleton<Logger.SomeClass>();
            // services.AddSingleton<Logger.Interfaces.ILogger , Logger.Logger>();

            services.AddTransient<Logger.SomeClass>();
            services.AddTransient<Logger.Interfaces.ILogger, Logger.Logger>();

            MyServiceProvider =
                services.BuildServiceProvider(validateScopes: true);

        }
        # endregion \ RegisterServicesFunction

        // Dispose Service Provider
        #region  DisposeServiceProvider
        private static void DisposeServiceProvider()
        {
            if (MyServiceProvider != null)
            {
                MyServiceProvider.Dispose();
            }
        }
        #endregion \ DisposeServiceProvider
    }
}