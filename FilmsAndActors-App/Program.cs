using System;
using System.Windows.Forms;

namespace FilmsAndActors_App
{
    /// <summary>
    /// Main program class for the Films and Actors Windows Forms application.
    /// Provides the entry point for the application and initialises the main form.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the Films and Actors application.
        /// Initialises the Windows Forms application and starts the main form.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Configure application for high DPI settings and modern visual styles
            ApplicationConfiguration.Initialize();
            
            // Start the Windows Forms application with the main form
            Application.Run(new Form1());
        }
    }
}
