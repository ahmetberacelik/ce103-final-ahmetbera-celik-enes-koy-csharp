/**
 * @file Program.cs
 * @brief Entry point for the library system application.
 */
using LibrarysystemLibrary;
internal class Program
{
    /**
    * @brief The main method that serves as the entry point for the application.
    * @param args Command-line arguments.
    */
    private static void Main(string[] args)
    {
        Librarysystem librarySystem = new Librarysystem();
        librarySystem.MainMenu();
    }
}
