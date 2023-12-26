
using NLog;

namespace MotoDepotJobsCreator
{
    internal static class Program
    {
        public static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var config = new NLog.Config.LoggingConfiguration();
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "application.log" };
            var errorLogfile = new NLog.Targets.FileTarget("errorLogfile") { FileName = "error.log" };
            config.AddRule(LogLevel.Debug, LogLevel.Info, logfile);
            config.AddRule(LogLevel.Warn, LogLevel.Fatal, errorLogfile);
            NLog.LogManager.Configuration = config;

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Main());
        }
    }


}