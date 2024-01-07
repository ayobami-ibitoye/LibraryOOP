using LibraryOOP.Library;

class Program
{
    static void Main(string[] args)
    {
         var library = new Library();
         LibraryFlow(library);
        
    }

    static void LibraryFlow(Library library) 
    {
        
        while(true)
        {
            InitialDisplay();

            var optionStringSelected = Console.ReadLine();
            var canParseOption = Int32.TryParse(optionStringSelected, out var optionSelected);

            if(!canParseOption) 
            {
                InitialDisplay("You have selected an Invalid option. Please try again. \n");
            }
            else
            {
                if(optionSelected == 1)
                {
                    // Borrow book
                    Console.WriteLine("Enter the title of the book you would like to borrow.");
                    var title = Console.ReadLine();

                    var bookAvailable = library.CheckIfBookIsAvailable(title);
                    if(!bookAvailable)
                    {
                        DisplayError("Sorry, the book you're requesting is not available");
                        LibraryFlow(library);
                    }

                    var bookBorrowed = library.BorrowBook(title);

                    if(bookBorrowed)
                    {
                        DisplaySuccess("The book is now being issued to you.");
                    }
                    else
                    {
                        DisplayError("System error");
                    }
                }
                else if(optionSelected == 2)
                {
                    // Return book
                    Console.WriteLine("Enter the unique id of the book being returned.");
                    var uniqueID = Console.ReadLine();

                    var bookAvailable = library.CheckIfUniqueIdIsAvailable(uniqueID);
                    if(bookAvailable)
                    {
                        DisplayError("Please enter the correct id. ");
                        LibraryFlow(library);
                    }

                    var bookReturned = library.ReturnBook(uniqueID);

                    if(bookReturned) 
                    {
                        DisplaySuccess("The book has been successfully returned to shelf");
                    }
                    else
                    {
                        DisplayError("System error");
                    }
                }
            }
        }
    }
    static void InitialDisplay(string message = "")
    {
        if(!String.IsNullOrEmpty(message))
        {
            Console.Clear();
            Console.WriteLine(message);
        }
            Console.WriteLine("Welcome to Advanced App Dev Library.\n");
            Console.WriteLine("Please select an option from the following.\n");
            Console.WriteLine("1. Borrow a book.\n");
            Console.WriteLine("2. Return a book.\n");
    }


    static void DisplaySuccess(string message)
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    static void DisplayError(string message)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(message);
        Console.ResetColor();
    }
    // static void Main(string[] args)
    // {
    //     var library = new Library();
    //     library.AddBook(new Book(new Author("Author 11", "10/11/1990"), "Title 11", "Cat 11"));

    //     var bookTitle = "title 7";
    //     var bookAvailable = library.CheckIfBookIsAvailable(bookTitle);

    //     Console.WriteLine($"Book with title {bookTitle}'s availability is: {bookAvailable}");

    //     var bookBorrowed = library.BorrowBook(bookTitle);

    //     Console.WriteLine($"Borrowing of book resulted in: {bookBorrowed}");

    //     library.BorrowBook(bookTitle);
    // }
}