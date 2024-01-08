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