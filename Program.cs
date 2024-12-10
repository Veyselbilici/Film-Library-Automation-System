using FinalProject.Aplication;
using FinalProject.Infstructure.Database.Mssql;

namespace FinalProject
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var dbContext = new FinalProjectDbContext();

            var userMaganer = new UserManager(dbContext);
            var reviewManager = new ReviewManager(dbContext);
            var movieManager = new MovieManager(dbContext);
            var watchListManager = new WatchListManager(dbContext);

            Application.Run(new LoginForm(movieManager,reviewManager,userMaganer,watchListManager));
        }
    }
}