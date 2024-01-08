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
        /**
* @brief Displays the reservation and renewal menu and handles user input for reserving, restoring, and viewing reservations.
* 
* The function continuously presents the reservation and renewal menu options and processes the user's choice.
* It includes options for reserving items, restoring items, viewing reservations, and exit. It redirects to the corresponding
* functions based on the user's choice.
* 
* @return True if the reservation and renewal menu is running successfully, otherwise false.
*/
        public bool ReservationAndRenewal()
        {
            bool isRunning = true;
            while (isRunning)
            {
                ClearScreen();
                Console.WriteLine("1. Reserve Items");
                Console.WriteLine("2. Restore Items");
                Console.WriteLine("3. View Reservation");
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
                        ReserveItems();
                        break;
                    case 2:
                        RestoreItems();
                        break;
                    case 3:
                        ViewReservation();
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
        * @brief Handles user login for reservation, prompting the user to register with their username.
        * 
        * The function prompts the user to enter their username and checks if the entered username
        * is registered. If registered, it welcomes the user and sets the active user for reservations.
        * If not registered, it notifies the user to check their entry.
        * 
        * @return True if the user is successfully logged in, otherwise false.
*/
        public bool ReservationScreenLogin()
        {
            ClearScreen();
            Console.WriteLine("Please register with your user name.");
            Console.WriteLine("Write your user name:");
            string temporaryUsername = Console.ReadLine();
            foreach (var registeredUserName in registered_user_name)
            {
                if (registeredUserName.Equals(temporaryUsername))
                {
                    Console.WriteLine($"Welcome {registeredUserName}");
                    take_enter_input();
                    active_user = registeredUserName;
                    return true;
                }
            }

            Console.WriteLine("The username you entered is not registered. Please check your entry.");
            take_enter_input();
            return false;
        }
        /**
        * @brief Displays the reservation menu and handles user input for reserving books, movies, or music.
        * 
        * The function continuously presents the reservation menu options and processes the user's choice.
         * It includes options for reserving books, movies, music, and exit. It redirects to the corresponding
        * reserve functions based on the user's choice.
        * 
        * @return True if the reservation menu is running successfully, otherwise false.
*/
        public bool ReserveItems()
        {
            bool isRunning = true;
            while (isRunning)
            {
                ClearScreen();
                Console.WriteLine("1. Reserve Books");
                Console.WriteLine("2. Reserve Movies");
                Console.WriteLine("3. Reserve Music");
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
                        ReserveBook();
                        break;
                    case 2:
                        ReserveMovie();
                        break;
                    case 3:
                        ReserveMusic();
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
        * @brief Handles the reservation process for books.
        * 
        * The function prompts the user to enter the name of the book they want to reserve. 
        * It then checks the availability of the book and reserves it if available. 
        * The user is notified of the reservation status.
        * 
        * @return True if the book is successfully reserved, otherwise false.
*/
        public bool ReserveBook()
        {
            ClearScreen();
            Console.WriteLine("Please write book name you want to reserve, please pay attention to upper and lower case letters.");
            Console.WriteLine("(A correct example: Crime and Punishment):");

            string bookQuery = Console.ReadLine();

            for (int i = 0; i < books.Length; i++)
            {
                if (books[i].Equals(bookQuery))
                {
                    reservedItems[reservedItemCount++] = $"{books[i]} is reserved by {active_user}";
                    Console.WriteLine($"The book {books[i]} is available.");
                    Console.WriteLine($"{books[i]} is reserved by {active_user}.");
                    books[i] = "";
                    take_enter_input();
                    return true;
                }
            }

            Console.WriteLine("Sorry, the book is not available.");
            take_enter_input();
            return false;
        }
        /**
        * @brief Handles the reservation process for movies.
        * 
        * The function prompts the user to enter the name of the movie they want to reserve. 
        * It then checks the availability of the movie and reserves it if available. 
        * The user is notified of the reservation status.
        * 
        * @return True if the movie is successfully reserved, otherwise false.
*/
        public bool ReserveMovie()
        {
            ClearScreen();
            Console.WriteLine("Please write movie name you want to reserve, please pay attention to upper and lower case letters.");
            Console.WriteLine("(A correct example: Into the Wild):");

            string movieQuery = Console.ReadLine();

            for (int i = 0; i < movies.Length; i++)
            {
                if (movies[i].Equals(movieQuery))
                {
                    reservedItems[reservedItemCount++] = $"{movies[i]} is reserved by {active_user}";
                    Console.WriteLine($"The movie {movies[i]} is available.");
                    Console.WriteLine($"{movies[i]} is reserved by {active_user}.");
                    movies[i] = "";
                    take_enter_input();
                    return true;
                }
            }

            Console.WriteLine("Sorry, the movie is not available.");
            take_enter_input();
            return false;
        }
        /**
        * @brief Handles the reservation process for music.
        * 
        * The function prompts the user to enter the name of the music they want to reserve. 
        * It then checks the availability of the music and reserves it if available. 
        * The user is notified of the reservation status.
        * 
        * @return True if the music is successfully reserved, otherwise false.
*/
        public bool ReserveMusic()
        {
            ClearScreen();
            Console.WriteLine("Please write music name you want to reserve, please pay attention to upper and lower case letters.");
            Console.WriteLine("(A correct example: Castle of Glass):");

            string musicQuery = Console.ReadLine();

            for (int i = 0; i < musics.Length; i++)
            {
                if (musics[i].Equals(musicQuery))
                {
                    reservedItems[reservedItemCount++] = $"{musics[i]} is reserved by {active_user}";
                    Console.WriteLine($"The music {musics[i]} is available.");
                    Console.WriteLine($"{musics[i]} is reserved by {active_user}.");
                    musics[i] = "";
                    take_enter_input();
                    return true;
                }
            }

            Console.WriteLine("Sorry, the music is not available.");
            take_enter_input();
            return false;
        }
        /**
        * @brief Restores reserved items by deleting all reservations.
        * 
        * The function displays the user's reservations and prompts them to confirm the deletion of all reservations. 
        * If confirmed, it deletes all reservations and restores the availability of the reserved items.
        * 
        * @return True if the reservations are successfully restored, otherwise false.
        */
        public bool RestoreItems()
        {
            if (!ViewReservation())
            {
                return false;
            }
            else
            {
                Console.WriteLine("If you want to delete your all reservations, write 'Delete'. If you didn't, enter wrong input.");
                string deleteReservations = Console.ReadLine();
                if (deleteReservations.Equals("Delete"))
                {
                    for (int i = 0; i < reservedItems.Length; i++)
                    {
                        reservedItems[i] = null;
                    }
                    reservedItemCount = 0;

                    for (int j = 0; j < 5; j++)
                    {
                        books[j] = originalBooks[j];
                        movies[j] = originalMovies[j];
                        musics[j] = originalMusics[j];
                    }
                    Console.WriteLine("Your reservations have been cleaned.");
                    take_enter_input();
                    return true;
                }
                else
                {
                    Console.WriteLine("You entered wrong input!");
                    take_enter_input();
                    return false;
                }
            }
        }
        /**
        * @brief Displays the user's reservations.
        * 
        * The function checks and displays the items reserved by the active user.
        * If the user has no reservations, it notifies them that they have no borrowed material.
        * 
        * @return True if the user has reservations, otherwise false.
        */
        public bool ViewReservation()
        {
            bool findReservation = false;
            ClearScreen();

            for (int i = 0; i < reservedItems.Length; i++)
            {
                if (reservedItems[i] != null && reservedItems[i].Contains(active_user))
                {
                    Console.WriteLine($"The item {reservedItems[i]}.");
                    findReservation = true;
                    take_enter_input();
                }
            }

            if (!findReservation)
            {
                Console.WriteLine("You have no borrowed material.");
                take_enter_input();
            }
            return findReservation;
        }
        /**
        * @brief Handles the event and workshop schedule menu.
        * 
        * The function displays options to view events, register for events, or exit.
        * It takes user input and performs corresponding actions based on the choice.
        * 
        * @return True if the menu operates successfully, otherwise false.
        */
        public bool EventAndWorkshopSchedule()
        {
            bool isRunning = true;
            while (isRunning)
            {
                ClearScreen();
                Console.WriteLine("1. View Events");
                Console.WriteLine("2. Register for Events");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice (1-3):");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid choice. Please enter a number.");
                    take_enter_input();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        ViewEvents();
                        break;
                    case 2:
                        if (RegisterForEvents()) break;
                        else continue;
                    case 3:
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
        * @brief Displays the available events.
        * 
        * The function shows the current list of events.
        */
        public void ViewEvents()
        {
            ClearScreen();
            Console.WriteLine(events);
            take_enter_input();
        }
        /**
        * @brief Handles the event registration process.
        * 
        * The function displays the available events, prompts the user to enter their name, and select an event to register.
        * It performs checks on user input and completes the registration process.
        * 
        * @return True if the user successfully registers for an event, otherwise false.
        */
        public bool RegisterForEvents()
        {
            ClearScreen();
            Console.WriteLine(events);
            Console.WriteLine("Please enter your name:");

            userName = Console.ReadLine();

            if (!EventUserCheck(userName))
            {
                Console.WriteLine("You entered an invalid username. Username must consist of letters.");
                take_enter_input();
                return false;
            }

            Console.WriteLine("Please select the event you want to register:");
            eventNo = Console.ReadLine();
            if (!EventNoCheck(eventNo))
            {
                Console.WriteLine("You entered wrong option number. Please try again...");
                take_enter_input();
                return false;
            }

            Console.WriteLine($"A reservation has been made for {userName} for the event {eventNo}. Simply stating your name at the entrance will be sufficient.");
            take_enter_input();
            return true;
        }
        /**
        * @brief Checks if the event number is valid.
        * 
        * The function validates whether the entered event number corresponds to a valid option.
        * 
        * @param eventNo The event number entered by the user.
        * @return True if the event number is valid, otherwise false.
        */
        public bool EventNoCheck(string eventNo)
        {
            return eventNo == "1" || eventNo == "2";
        }
        /**
        * @brief Checks if the username is valid.
        * 
        * The function validates whether the entered username consists of letters.
        * 
        * @param userName The username entered by the user.
        * @return True if the username is valid, otherwise false.
        */
        public bool EventUserCheck(string userName)
        {
            return Regex.IsMatch(userName, "^[A-Za-z ]+$");
        }
        /**
        * @brief Displays library information.
        * 
        * The function shows information about the library.
        */
        public void LibraryInformations()
        {
            ClearScreen();
            Console.WriteLine(lib_infos);
            take_enter_input();
        }
        /**
        * @brief Writes data to a binary file.
        * 
        * The function uses BinaryWriter to write various data (e.g., reserved items, user information, events) to a binary file.
        * 
        * @param filename The name of the binary file to write the data to.
        */
        public void WriteBinary(string filename)
        {
            using (BinaryWriter binarywriter = new BinaryWriter(File.Open(filename, FileMode.Create)))
            {
                foreach (var element in reservedItems)
                {
                    binarywriter.Write(element ?? "");
                }

                binarywriter.Write(reservedItemCount);

                foreach (var element in books)
                {
                    binarywriter.Write(element);
                }
                foreach (var element in movies)
                {
                    binarywriter.Write(element);
                }
                foreach (var element in musics)
                {
                    binarywriter.Write(element);
                }
                foreach (var element in registered_user_name)
                {
                    binarywriter.Write(element);
                }

                binarywriter.Write(active_user);

                binarywriter.Write(events);

                binarywriter.Write(userName ?? "");

                binarywriter.Write(eventNo ?? "");

                binarywriter.Write(lib_infos);
            }
        }
    }
}