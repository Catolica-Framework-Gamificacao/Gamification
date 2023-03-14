namespace Api;

public static class AppConfiguration
{
    private static IConfigurationRoot config;
    
    public static IConfigurationRoot Config
    {
        get
        {
            if (config == null)
            {
                IConfigurationBuilder builder = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);
                config = builder.Build();
            }
            return config;
        }
    }

    public static IConfigurationSection AppSettings => Config.GetSection("appsettings");

    #region "Database configuration'
    public static string DatabaseConnectionString => AppSettings["Database:ConnectionString"];
    public static int DatabaseMajorVersion => int.Parse(AppSettings["Database:MajorVersion"]);
    public static int DatabaseMinorVersion => int.Parse(AppSettings["Database:MinorVersion"]);
    #endregion
    
    public static string JwtKey => AppSettings["JWT:Key"];
}