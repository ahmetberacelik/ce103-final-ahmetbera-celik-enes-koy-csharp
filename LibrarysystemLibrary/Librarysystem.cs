/**
 * @file Librarysystem.cs
 * @brief Contains the definition of the Librarysystem class.
 */
using System.Text.RegularExpressions; /** Contains the classes and functionalities related to the library system. */
/** 
 * @brief Contains classes that define the library system's functionalities.
 */
namespace LibrarysystemLibrary
{
    /**
     * @brief Represents the Library System.
     * 
     * The Librarysystem class serves as the main class for the library system.
     * It encapsulates various functionalities related to catalog search, reservations, events, and library information.
     */
    public class Librarysystem
    {
        public bool IsTestMode { get; set; } = false;
        /**
         *@brief An array to store reserved items.
         */
        String[] reservedItems = new String[15];

        int reservedItemCount = 0; /** The count of reserved items in the library. */

        String[] books = { "Crime and Punishment", "Martin Eden", "Ruh Adam", "Uncle Vanya", "Kinyas ve Kayra" }; /** An array containing the names of available books in the library. */
        String[] movies = { "Seven", "Into the Wild", "Donnie Darko", "The Prestige", "Batman Begins" }; /** An array containing the names of available movies in the library. */
        String[] musics = { "Castle of Glass", "Mockingbird", "Turn the Page", "Ohne Dich", "Nothing Else Matters" }; /** An array containing the names of available music in the library. */

        String[] originalBooks = { "Crime and Punishment", "Martin Eden", "Ruh Adam", "Uncle Vanya", "Kinyas ve Kayra" }; /** An array containing the original list of available books in the library. */
        String[] originalMovies = { "Seven", "Into the Wild", "Donnie Darko", "The Prestige", "Batman Begins" }; /** An array containing the original list of available movies in the library. */
        String[] originalMusics = { "Castle of Glass", "Mockingbird", "Turn the Page", "Ohne Dich", "Nothing Else Matters" }; /** An array containing the original list of available music in the library. */

        String[] registered_user_name = { "Ahmet Bera Celik", "Enes Koy", "Ugur Coruh", "Yakup Eroglu", "Hasan Basri Taskin" }; /** An array containing the names of registered library users. */

        String active_user = "Example User"; /** The username of the currently active library user. */

        string userName; /** A variable to store the username during certain operations. */

        string eventNo; /** A variable to store the event number during event registration. */

        const String events = "Upcoming Library Events\n" + /** A constant string containing information about upcoming library events. */
            "1 - Reading incentive program for children (Two days later, 5 p.m)\n" +
            "2 - Book chat with the author (Five days later, 10 a.m)\n";
        /** 
         * 
         * @brief A constant string containing information about library locations and hours. 
         */
        const String lib_infos = "Library Location and Hours Informations\n" +
            "Public Library (In city center) --> Available for Monday to Saturday. Weekdays --> 8.00 to 22.00\n" +
            "Private Library (Next to the public cultural center )--> Avaliable for 7/24 hours\n" +
            "Public Library (Inside main campus) --> Available for Monday to Saturday. Weekdays --> 8.00 to 22.00\n";
        /**
        * @brief Reads a line from the console input.
        */
        public void take_enter_input()
        {
            Console.ReadLine();
        }
        /**
        * @brief Clears the console screen if the application is not in test mode.
        */
        public void ClearScreen()
        {
            if (!IsTestMode)
            {
                Console.Clear();
            }
        }
        /**
        * @brief Displays the main menu and handles user input for various library functionalities.
        * 
        * The function continuously presents the main menu options and processes the user's choice.
        * It includes options for catalog search, reservation and renewal, event and workshop schedule,
        * library information, and exit. It handles input validation and redirects to the corresponding
        * functions based on the user's choice.
        * 
        * @return True if the main menu is running successfully, otherwise false.
        */
        public bool MainMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                ClearScreen();
                Console.WriteLine("1. Catalog Search");
                Console.WriteLine("2. Reservation And Renewal");
                Console.WriteLine("3. Event And Workshop Schedule");
                Console.WriteLine("4. Library Information");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice (1-5):");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid choice. Please enter a number.");
                    take_enter_input();
                    continue;
                }
                switch (choice)
                {
                    case 1:
                        catalog_search_menu();
                        break;
                    case 2:
                        if (!ReservationScreenLogin()) break;
                        ReservationAndRenewal();
                        break;
                    case 3:
                        EventAndWorkshopSchedule();
                        break;
                    case 4:
                        LibraryInformations();
                        break;
                    case 5:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        take_enter_input();
                        break;
                }
            }
            return true;
        }
        /**
        * @brief Displays the catalog search menu and handles user input for searching books, movies, or music.
        * 
        * The function continuously presents the catalog search menu options and processes the user's choice.
        * It includes options for searching books, movies, music, and exit. It redirects to the corresponding
        * search functions based on the user's choice.
        * 
        * @return True if the catalog search menu is running successfully, otherwise false.
        */
        public bool catalog_search_menu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                ClearScreen();
                Console.WriteLine("1. Search Books");
                Console.WriteLine("2. Search Movies");
                Console.WriteLine("3. Search Music");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice (1-4):");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid choice. Please enter a number.");
                    take_enter_input();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        SearchBooks();
                        break;
                    case 2:
                        SearchMovies();
                        break;
                    case 3:
                        SearchMusic();
                        break;
                    case 4:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        take_enter_input();
                        break;
                }
            }
            return true;
        }
        /**
        * @brief Searches for a book in the library catalog based on user input.
        * 
        * The function prompts the user to enter the name of the book they want to search.
        * It then checks if the book is available in the catalog and provides appropriate feedback.
        * 
        * @return True if the book is found and available, otherwise false.
        */
        public bool SearchBooks()
        {
            ClearScreen();
            Console.WriteLine("Please write book name you want to search, please pay attention to upper and lower case letters.");
            Console.WriteLine("(A correct example: Crime and Punishment):");

            string bookQuery = Console.ReadLine();

            for (int i = 0; i < books.Length; i++)
            {
                if (books[i].Equals(bookQuery))
                {
                    Console.WriteLine($"The book {books[i]} is available.");
                    take_enter_input();
                    return true;
                }
            }

            Console.WriteLine("Sorry... The book you are looking for is not available.");
            take_enter_input();
            return false;
        }
        /**
        * @brief Searches for a movie in the library catalog based on user input.
        * 
        * The function prompts the user to enter the name of the movie they want to search.
        * It then checks if the movie is available in the catalog and provides appropriate feedback.
        * 
        * @return True if the movie is found and available, otherwise false.
        */
        public bool SearchMovies()
        {
            ClearScreen();
            Console.WriteLine("Please write movie name you want to search, please pay attention to upper and lower case letters.");
            Console.WriteLine("(A correct example: Into the Wild):");

            string movieQuery = Console.ReadLine();

            for (int i = 0; i < movies.Length; i++)
            {
                if (movies[i].Equals(movieQuery))
                {
                    Console.WriteLine($"The movie {movies[i]} is available.");
                    take_enter_input();
                    return true;
                }
            }

            Console.WriteLine("Sorry... The movie you are looking for is not available.");
            take_enter_input();
            return false;
        }
        /**
        * @brief Searches for a music in the library catalog based on user input.
        * 
        * The function prompts the user to enter the name of the music they want to search.
        * It then checks if the music is available in the catalog and provides appropriate feedback.
        * 
        * @return True if the music is found and available, otherwise false.
        */
        public bool SearchMusic()
        {
            ClearScreen();
            Console.WriteLine("Please write music name you want to search, please pay attention to upper and lower case letters.");
            Console.WriteLine("(A correct example: Castle of Glass):");

            string musicQuery = Console.ReadLine();

            for (int i = 0; i < musics.Length; i++)
            {
                if (musics[i].Equals(musicQuery))
                {
                    Console.WriteLine($"The music {musics[i]} is available.");
                    take_enter_input();
                    return true;
                }
            }

            Console.WriteLine("Sorry... The music you are looking for is not available.");
            take_enter_input();
            return false;
        }
    }