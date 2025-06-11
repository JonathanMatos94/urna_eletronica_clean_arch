using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using urna_eletronica.UI.Forms;
using urna_eletronica.Data.Context;

namespace urna_eletronica.UI
{
    public static class Program
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
            System.Windows.Forms.Application.Run(new TelaLogin()); // Ensure 'Application' refers to 'System.Windows.Forms.Application'
        }      

    }
}