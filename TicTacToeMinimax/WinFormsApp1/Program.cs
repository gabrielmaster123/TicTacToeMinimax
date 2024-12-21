namespace WinFormsApp1
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
            
            Game game = new Game();
            Form1 form = new Form1(game);

            //game.PrintGame(form.GameLabel);
            
            Application.Run(form);
        }
        
    }
}