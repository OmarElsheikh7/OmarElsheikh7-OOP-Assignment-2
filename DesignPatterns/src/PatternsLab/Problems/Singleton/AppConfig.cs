using System.Runtime.CompilerServices;

namespace PatternsLab.Problems.Singleton;

public sealed class AppConfig
{
    public static int LoadCount;

    public string DbConnection { get; set; }
    public string Theme { get; set; }

    private static readonly AppConfig _instance = new AppConfig();

    private AppConfig()
    {
        LoadCount++;
        Console.WriteLine($"[AppConfig] Loading settings from disk... (load #{LoadCount})");
        Thread.Sleep(300);
        DbConnection = "Server=localhost;Db=School";
        Theme = "Light";
    }

    public static AppConfig GetApp() => _instance;
}

public class DatabaseService
{
    public AppConfig Config = AppConfig.GetApp();

    public void Connect() => Console.WriteLine($"Connecting to {Config.DbConnection}");
}

public class UiService
{
    public AppConfig Config = AppConfig.GetApp();

    public void Render() => Console.WriteLine($"UI is using theme: {Config.Theme}");
}
