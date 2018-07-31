using Mapster;

namespace XamarinFormsMVP.Configuration
{
    public class GlobalConfiguration
    {
        public static void Configure()
        {
            ConfigureMapster();
        }

        private static void ConfigureMapster()
        {
            TypeAdapterConfig.GlobalSettings.Scan(System.Reflection.Assembly.GetExecutingAssembly());
        }
    }
}
