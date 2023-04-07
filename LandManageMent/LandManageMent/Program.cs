namespace LandManageMent
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //dotnet ef dbcontext scaffold "server =(local); database = SenLand;uid=hoang;pwd=123;Trustservercertificate=true" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());


        }

        
    }
}