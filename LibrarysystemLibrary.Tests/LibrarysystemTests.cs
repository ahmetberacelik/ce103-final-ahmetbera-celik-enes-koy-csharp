using System;
using System.IO;
using Xunit;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LibrarysystemLibrary.Tests
{

    public class LibrarysystemTests
    {
        [Fact]
        public void MainMenuInvalidTest()
        {
            var input = new StringReader("abc\n\n48\n\n5\n");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            var librarysystem = new Librarysystem
            {
                IsTestMode = true
            };
            bool result = librarysystem.MainMenu();

            string expectedOutput = "1. Catalog Search\r\n" +
                "2. Reservation And Renewal\r\n" +
                "3. Event And Workshop Schedule\r\n" +
                "4. Library Information\r\n" +
                "5. Exit\r\n" +
                "Enter your choice (1-5):" +
                "Invalid choice. Please enter a number.\r\n" +
                "1. Catalog Search\r\n" +
                "2. Reservation And Renewal\r\n" +
                "3. Event And Workshop Schedule\r\n" +
                "4. Library Information\r\n" +
                "5. Exit\r\n" +
                "Enter your choice (1-5):" +
                "Invalid choice. Please try again.\r\n" +
                "1. Catalog Search\r\n" +
                "2. Reservation And Renewal\r\n" +
                "3. Event And Workshop Schedule\r\n" +
                "4. Library Information\r\n" +
                "5. Exit\r\n" +
                "Enter your choice (1-5):";

            Assert.True(result);
            Assert.Equal(expectedOutput, output.ToString());

            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        }

        [Fact]
        public void MainMenuValidTest()
        {
            var input = new StringReader("1\n4\n2\nEnes Koy\n\n4\n3\n3\n4\n\n5\n");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            var librarysystem = new Librarysystem
            {
                IsTestMode = true
            };
            bool result = librarysystem.MainMenu();

            string expectedOutput = "1. Catalog Search\r\n" +
                "2. Reservation And Renewal\r\n" +
                "3. Event And Workshop Schedule\r\n" +
                "4. Library Information\r\n" +
                "5. Exit\r\n" +
                "Enter your choice (1-5):" +
                "1. Search Books\r\n" +
                "2. Search Movies\r\n" +
                "3. Search Music\r\n" +
                "4. Exit\r\n" +
                "Enter your choice (1-4):" +
                "1. Catalog Search\r\n" +
                "2. Reservation And Renewal\r\n" +
                "3. Event And Workshop Schedule\r\n" +
                "4. Library Information\r\n" +
                "5. Exit\r\n" +
                "Enter your choice (1-5):" +
                "Please register with your user name.\r\n" +
                "Write your user name:\r\n" +
                "Welcome Enes Koy\r\n" +
                "1. Reserve Items\r\n" +
                "2. Restore Items\r\n" +
                "3. View Reservation\r\n" +
                "4. Exit\r\n" +
                "Enter your choice (1-4):" +
                "1. Catalog Search\r\n" +
                "2. Reservation And Renewal\r\n" +
                "3. Event And Workshop Schedule\r\n" +
                "4. Library Information\r\n" +
                "5. Exit\r\n" +
                "Enter your choice (1-5):" +
                "1. View Events\r\n" +
                "2. Register for Events\r\n" +
                "3. Exit\r\n" +
                "Enter your choice (1-3):" +
                "1. Catalog Search\r\n" +
                "2. Reservation And Renewal\r\n" +
                "3. Event And Workshop Schedule\r\n" +
                "4. Library Information\r\n" +
                "5. Exit\r\n" +
                "Enter your choice (1-5):" +
                "Library Location and Hours Informations\n" +
                "Public Library (In city center) --> Available for Monday to Saturday. Weekdays --> 8.00 to 22.00\n" +
                "Private Library (Next to the public cultural center )--> Avaliable for 7/24 hours\n" +
                "Public Library (Inside main campus) --> Available for Monday to Saturday. Weekdays --> 8.00 to 22.00\n\r\n" +
                "1. Catalog Search\r\n" +
                "2. Reservation And Renewal\r\n" +
                "3. Event And Workshop Schedule\r\n" +
                "4. Library Information\r\n" +
                "5. Exit\r\n" +
                "Enter your choice (1-5):";

            Assert.True(result);
            Assert.Equal(expectedOutput, output.ToString());

            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        }

        [Fact]
        public void CatalogSearchMenuInvalidTest()
        {
            var input = new StringReader("abc\n\n48\n\n4\n");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            var librarysystem = new Librarysystem
            {
                IsTestMode = true
            };
            bool result = librarysystem.catalog_search_menu();

            string expectedOutput = "1. Search Books\r\n" +
                "2. Search Movies\r\n" +
                "3. Search Music\r\n" +
                "4. Exit\r\n" +
                "Enter your choice (1-4):" +
                "Invalid choice. Please enter a number.\r\n" +
                "1. Search Books\r\n" +
                "2. Search Movies\r\n" +
                "3. Search Music\r\n" +
                "4. Exit\r\n" +
                "Enter your choice (1-4):" +
                "Invalid choice. Please try again.\r\n" +
                "1. Search Books\r\n" +
                "2. Search Movies\r\n" +
                "3. Search Music\r\n" +
                "4. Exit\r\n" +
                "Enter your choice (1-4):";

            Assert.True(result);
            Assert.Equal(expectedOutput, output.ToString());

            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        }

        [Fact]
        public void CatalogSearchMenuValidTest()
        {
            var input = new StringReader("1\ninvalidinput\n\n2\ninvalidinput\n\n3\ninvalidinput\n\n4\n");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            var librarysystem = new Librarysystem
            {
                IsTestMode = true
            };
            bool result = librarysystem.catalog_search_menu();

            string expectedOutput = "1. Search Books\r\n" +
                "2. Search Movies\r\n" +
                "3. Search Music\r\n" +
                "4. Exit\r\n" +
                "Enter your choice (1-4):" +
                "Please write book name you want to search, please pay attention to upper and lower case letters.\r\n" +
                "(A correct example: Crime and Punishment):\r\n" +
                "Sorry... The book you are looking for is not available.\r\n" +
                "1. Search Books\r\n" +
                "2. Search Movies\r\n" +
                "3. Search Music\r\n" +
                "4. Exit\r\n" +
                "Enter your choice (1-4):" +
                "Please write movie name you want to search, please pay attention to upper and lower case letters.\r\n" +
                "(A correct example: Into the Wild):\r\n" +
                "Sorry... The movie you are looking for is not available.\r\n" +
                "1. Search Books\r\n" +
                "2. Search Movies\r\n" +
                "3. Search Music\r\n" +
                "4. Exit\r\n" +
                "Enter your choice (1-4):" +
                "Please write music name you want to search, please pay attention to upper and lower case letters.\r\n" +
                "(A correct example: Castle of Glass):\r\n" +
                "Sorry... The music you are looking for is not available.\r\n" +
                "1. Search Books\r\n" +
                "2. Search Movies\r\n" +
                "3. Search Music\r\n" +
                "4. Exit\r\n" +
                "Enter your choice (1-4):";

            Assert.True(result);
            Assert.Equal(expectedOutput, output.ToString());

            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        }

        [Fact]
        public void SearchBooksValid()
        {
            var input = new StringReader("Uncle Vanya");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            var librarysystem = new Librarysystem
            {
                IsTestMode = true
            };
            bool result = librarysystem.SearchBooks();

            string expectedOutput = "Please write book name you want to search, please pay attention to upper and lower case letters.\r\n" +
                                    "(A correct example: Crime and Punishment):\r\n" +
                                    "The book Uncle Vanya is available.\r\n";

            Assert.True(result);
            Assert.Equal(expectedOutput, output.ToString());

            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        }

        [Fact]
        public void SearchMoviesValid()
        {
            var input = new StringReader("The Prestige");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            var librarysystem = new Librarysystem
            {
                IsTestMode = true
            };
            bool result = librarysystem.SearchMovies();

            string expectedOutput = "Please write movie name you want to search, please pay attention to upper and lower case letters.\r\n" +
                "(A correct example: Into the Wild):\r\n" +
                "The movie The Prestige is available.\r\n";

            Assert.True(result);
            Assert.Equal(expectedOutput, output.ToString());

            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        }

        [Fact]
        public void SearchMusicValid()
        {
            var input = new StringReader("Ohne Dich");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            var librarysystem = new Librarysystem
            {
                IsTestMode = true
            };
            bool result = librarysystem.SearchMusic();

            string expectedOutput = "Please write music name you want to search, please pay attention to upper and lower case letters.\r\n" +
                "(A correct example: Castle of Glass):\r\n" +
                "The music Ohne Dich is available.\r\n";

            Assert.True(result);
            Assert.Equal(expectedOutput, output.ToString());

            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        }
        [Fact]
        public void ReservationAndRenewalInvalidTest()
        {
            var input = new StringReader("abc\n\n48\n\n4\n");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            var librarysystem = new Librarysystem
            {
                IsTestMode = true
            };
            bool result = librarysystem.ReservationAndRenewal();

            string expectedOutput = "1. Reserve Items\r\n" +
                "2. Restore Items\r\n" +
                "3. View Reservation\r\n" +
                "4. Exit\r\n" +
                "Enter your choice (1-4):" +
                "Invalid choice. Please enter a number.\r\n" +
                "1. Reserve Items\r\n" +
                "2. Restore Items\r\n" +
                "3. View Reservation\r\n" +
                "4. Exit\r\n" +
                "Enter your choice (1-4):" +
                "Invalid choice. Please try again.\r\n" +
                "1. Reserve Items\r\n" +
                "2. Restore Items\r\n" +
                "3. View Reservation\r\n" +
                "4. Exit\r\n" +
                "Enter your choice (1-4):";

            Assert.True(result);
            Assert.Equal(expectedOutput, output.ToString());

            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        }

        [Fact]
        public void ReservationAndRenewalValidTest()
        {
            var input = new StringReader("1\n4\n2\n\n3\n\n4\n");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            var librarysystem = new Librarysystem
            {
                IsTestMode = true
            };
            bool result = librarysystem.ReservationAndRenewal();

            string expectedOutput = "1. Reserve Items\r\n" +
                "2. Restore Items\r\n" +
                "3. View Reservation\r\n" +
                "4. Exit\r\n" +
                "Enter your choice (1-4):" +
                "1. Reserve Books\r\n" +
                "2. Reserve Movies\r\n" +
                "3. Reserve Music\r\n" +
                "4. Exit\r\n" +
                "Enter your choice (1-4):" +
                "1. Reserve Items\r\n" +
                "2. Restore Items\r\n" +
                "3. View Reservation\r\n" +
                "4. Exit\r\n" +
                "Enter your choice (1-4):" +
                "You have no borrowed material.\r\n" +
                "1. Reserve Items\r\n" +
                "2. Restore Items\r\n" +
                "3. View Reservation\r\n" +
                "4. Exit\r\n" +
                "Enter your choice (1-4):" +
                "You have no borrowed material.\r\n" +
                "1. Reserve Items\r\n" +
                "2. Restore Items\r\n" +
                "3. View Reservation\r\n" +
                "4. Exit\r\n" +
                "Enter your choice (1-4):";

            Assert.True(result);
            Assert.Equal(expectedOutput, output.ToString());

            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        }

        [Fact]
        public void ReservationScreenLoginInvalid()
        {
            var input = new StringReader("Invalid User\n\n");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            var librarysystem = new Librarysystem
            {
                IsTestMode = true
            };
            bool result = librarysystem.ReservationScreenLogin();

            string expectedOutput = "Please register with your user name.\r\n" +
                "Write your user name:\r\n" +
                "The username you entered is not registered. Please check your entry.\r\n";

            Assert.False(result);
            Assert.Equal(expectedOutput, output.ToString());

            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        }

        [Fact]
        public void ReserveItemsTest()
        {
            var input = new StringReader("1\n\n\n2\n\n\n3\n\n\n4\n");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            var librarysystem = new Librarysystem
            {
                IsTestMode = true
            };
            bool result = librarysystem.ReserveItems();

            string expectedOutput = "1. Reserve Books\r\n" +
                "2. Reserve Movies\r\n" +
                "3. Reserve Music\r\n" +
                "4. Exit\r\n" +
                "Enter your choice (1-4):" +
                "Please write book name you want to reserve, please pay attention to upper and lower case letters.\r\n" +
                "(A correct example: Crime and Punishment):\r\n" +
                "Sorry, the book is not available.\r\n" +
                "1. Reserve Books\r\n" +
                "2. Reserve Movies\r\n" +
                "3. Reserve Music\r\n" +
                "4. Exit\r\n" +
                "Enter your choice (1-4):" +
                "Please write movie name you want to reserve, please pay attention to upper and lower case letters.\r\n" +
                "(A correct example: Into the Wild):\r\n" +
                "Sorry, the movie is not available.\r\n" +
                "1. Reserve Books\r\n" +
                "2. Reserve Movies\r\n" +
                "3. Reserve Music\r\n" +
                "4. Exit\r\n" +
                "Enter your choice (1-4):" +
                "Please write music name you want to reserve, please pay attention to upper and lower case letters.\r\n" +
                "(A correct example: Castle of Glass):\r\n" +
                "Sorry, the music is not available.\r\n" +
                "1. Reserve Books\r\n" +
                "2. Reserve Movies\r\n" +
                "3. Reserve Music\r\n" +
                "4. Exit\r\n" +
                "Enter your choice (1-4):";

            Assert.True(result);
            Assert.Equal(expectedOutput, output.ToString());

            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        }

        [Fact]
        public void ReserveItemsInvalidTest()
        {
            var input = new StringReader("abc\n\n48\n\n4\n");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            var librarysystem = new Librarysystem
            {
                IsTestMode = true
            };
            bool result = librarysystem.ReserveItems();

            string expectedOutput = "1. Reserve Books\r\n" +
                "2. Reserve Movies\r\n" +
                "3. Reserve Music\r\n" +
                "4. Exit\r\n" +
                "Enter your choice (1-4):" +
                "Invalid choice. Please enter a number.\r\n" +
                "1. Reserve Books\r\n" +
                "2. Reserve Movies\r\n" +
                "3. Reserve Music\r\n" +
                "4. Exit\r\n" +
                "Enter your choice (1-4):" +
                "Invalid choice. Please try again.\r\n" +
                "1. Reserve Books\r\n" +
                "2. Reserve Movies\r\n" +
                "3. Reserve Music\r\n" +
                "4. Exit\r\n" +
                "Enter your choice (1-4):";

            Assert.True(result);
            Assert.Equal(expectedOutput, output.ToString());

            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        }

        [Fact]
        public void ReserveBooksValid()
        {
            var input = new StringReader("Uncle Vanya");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            var librarysystem = new Librarysystem
            {
                IsTestMode = true
            };
            bool result = librarysystem.ReserveBook();

            string expectedOutput = "Please write book name you want to reserve, please pay attention to upper and lower case letters.\r\n" +
                "(A correct example: Crime and Punishment):\r\n" +
                "The book Uncle Vanya is available.\r\n" +
                "Uncle Vanya is reserved by Example User.\r\n";

            Assert.True(result);
            Assert.Equal(expectedOutput, output.ToString());

            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        }

        [Fact]
        public void ReserveMovieValid()
        {
            var input = new StringReader("Into the Wild");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            var librarysystem = new Librarysystem
            {
                IsTestMode = true
            };
            bool result = librarysystem.ReserveMovie();

            string expectedOutput = "Please write movie name you want to reserve, please pay attention to upper and lower case letters.\r\n" +
                "(A correct example: Into the Wild):\r\n" +
                "The movie Into the Wild is available.\r\n" +
                "Into the Wild is reserved by Example User.\r\n";

            Assert.True(result);
            Assert.Equal(expectedOutput, output.ToString());

            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        }

        [Fact]
        public void ReserveMusicValid()
        {
            var input = new StringReader("Mockingbird");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            var librarysystem = new Librarysystem
            {
                IsTestMode = true
            };
            bool result = librarysystem.ReserveMusic();

            string expectedOutput = "Please write music name you want to reserve, please pay attention to upper and lower case letters.\r\n" +
                "(A correct example: Castle of Glass):\r\n" +
                "The music Mockingbird is available.\r\n" +
                "Mockingbird is reserved by Example User.\r\n";

            Assert.True(result);
            Assert.Equal(expectedOutput, output.ToString());

            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        }

        [Fact]
        public void RestoreItemsValid()
        {
            var input = new StringReader("Uncle Vanya\n\n\nDelete\n");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            var librarysystem = new Librarysystem
            {
                IsTestMode = true
            };
            bool result = librarysystem.ReserveBook();
            bool result2 = librarysystem.RestoreItems();

            string expectedOutput = "Please write book name you want to reserve, please pay attention to upper and lower case letters.\r\n" +
                "(A correct example: Crime and Punishment):\r\n" +
                "The book Uncle Vanya is available.\r\n" +
                "Uncle Vanya is reserved by Example User.\r\n" +
                "The item Uncle Vanya is reserved by Example User.\r\n" +
                "If you want to delete your all reservations, write 'Delete'. If you didn't, enter wrong input.\r\n" +
                "Your reservations have been cleaned.\r\n";
            Assert.True(result);
            Assert.True(result2);
            Assert.Equal(expectedOutput, output.ToString());

            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        }

        [Fact]
        public void RestoreItemsInvalid()
        {
            var input = new StringReader("Uncle Vanya\n\n\nInvalid Input\n");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            var librarysystem = new Librarysystem
            {
                IsTestMode = true
            };
            bool result = librarysystem.ReserveBook();
            bool result2 = librarysystem.RestoreItems();

            string expectedOutput = "Please write book name you want to reserve, please pay attention to upper and lower case letters.\r\n" +
                "(A correct example: Crime and Punishment):\r\n" +
                "The book Uncle Vanya is available.\r\n" +
                "Uncle Vanya is reserved by Example User.\r\n" +
                "The item Uncle Vanya is reserved by Example User.\r\n" +
                "If you want to delete your all reservations, write 'Delete'. If you didn't, enter wrong input.\r\n" +
                "You entered wrong input!\r\n";
            Assert.True(result);
            Assert.False(result2);
            Assert.Equal(expectedOutput, output.ToString());

            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        }
        [Fact]
        public void EventMenuInvalid()
        {
            var input = new StringReader("abc\n\n48\n\n3\n");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            var librarysystem = new Librarysystem
            {
                IsTestMode = true
            };
            bool result = librarysystem.EventAndWorkshopSchedule();

            string expectedOutput = "1. View Events\r\n" +
                "2. Register for Events\r\n" +
                "3. Exit\r\n" +
                "Enter your choice (1-3):" +
                "Invalid choice. Please enter a number.\r\n" +
                "1. View Events\r\n" +
                "2. Register for Events\r\n" +
                "3. Exit\r\n" +
                "Enter your choice (1-3):" +
                "Invalid choice. Please try again.\r\n" +
                "1. View Events\r\n" +
                "2. Register for Events\r\n" +
                "3. Exit\r\n" +
                "Enter your choice (1-3):";

            Assert.True(result);
            Assert.Equal(expectedOutput, output.ToString());

            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        }

        [Fact]
        public void EventMenuValid()
        {
            var input = new StringReader("1\n\n2\n123\n\n3\n");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            var librarysystem = new Librarysystem
            {
                IsTestMode = true
            };
            bool result = librarysystem.EventAndWorkshopSchedule();

            string expectedOutput = "1. View Events\r\n" +
                "2. Register for Events\r\n" +
                "3. Exit\r\n" +
                "Enter your choice (1-3):" +
                "Upcoming Library Events\n" +
                "1 - Reading incentive program for children (Two days later, 5 p.m)\n" +
                "2 - Book chat with the author (Five days later, 10 a.m)\n\r\n" +
                "1. View Events\r\n" +
                "2. Register for Events\r\n" +
                "3. Exit\r\n" +
                "Enter your choice (1-3):" +
                "Upcoming Library Events\n" +
                "1 - Reading incentive program for children (Two days later, 5 p.m)\n" +
                "2 - Book chat with the author (Five days later, 10 a.m)\n\r\n" +
                "Please enter your name:\r\n" +
                "You entered an invalid username. Username must consist of letters.\r\n" +
                "1. View Events\r\n" +
                "2. Register for Events\r\n" +
                "3. Exit\r\n" +
                "Enter your choice (1-3):";

            Assert.True(result);
            Assert.Equal(expectedOutput, output.ToString());

            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        }

        [Fact]
        public void RegisterForEventsValid()
        {
            var input = new StringReader("Example User\n1\n\n");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            var librarysystem = new Librarysystem
            {
                IsTestMode = true
            };
            bool result = librarysystem.RegisterForEvents();

            string expectedOutput = "Upcoming Library Events\n" +
                "1 - Reading incentive program for children (Two days later, 5 p.m)\n" +
                "2 - Book chat with the author (Five days later, 10 a.m)\n\r\n" +
                "Please enter your name:\r\n" +
                "Please select the event you want to register:\r\n" +
                "A reservation has been made for Example User for the event 1. " +
                "Simply stating your name at the entrance will be sufficient.\r\n";

            Assert.True(result);
            Assert.Equal(expectedOutput, output.ToString());

            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        }

        [Fact]
        public void RegisterForEventsInvalid()
        {
            var input = new StringReader("Example User\nletter\n\n");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            var librarysystem = new Librarysystem
            {
                IsTestMode = true
            };
            bool result = librarysystem.RegisterForEvents();

            string expectedOutput = "Upcoming Library Events\n" +
                "1 - Reading incentive program for children (Two days later, 5 p.m)\n" +
                "2 - Book chat with the author (Five days later, 10 a.m)\n\r\n" +
                "Please enter your name:\r\n" +
                "Please select the event you want to register:\r\n" +
                "You entered wrong option number. Please try again...\r\n";

            Assert.False(result);
            Assert.Equal(expectedOutput, output.ToString());

            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        }

        [Fact]
        public void EventNoCheckValid()
        {
            var librarysystem = new Librarysystem
            {
                IsTestMode = true
            };
            bool result = librarysystem.EventNoCheck("1");
            Assert.True(result);
            bool result2 = librarysystem.EventNoCheck("2");
            Assert.True(result2);
        }

        [Fact]
        public void EventNoCheckInvalid()
        {
            var librarysystem = new Librarysystem
            {
                IsTestMode = true
            };
            bool result = librarysystem.EventNoCheck("9");
            Assert.False(result);
            bool result2 = librarysystem.EventNoCheck("-5");
            Assert.False(result2);
        }

        [Fact]
        public void WriteBinaryTestt()
        {
            var librarysystem = new Librarysystem();
            string TestFileName = "testLibraryData.bin";

            librarysystem.WriteBinary(TestFileName);

            Assert.True(File.Exists(TestFileName));

            var filelenght = new FileInfo(TestFileName);
            Assert.True(filelenght.Length > 0);

            File.Delete(TestFileName);
        }
    }
}