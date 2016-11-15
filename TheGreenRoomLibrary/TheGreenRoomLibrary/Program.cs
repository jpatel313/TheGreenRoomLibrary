using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGreenRoomLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Book> Books = new List<Book>();
            Books = BookListClass.readFile();
            List<Book> SearchedBooks = new List<Book>();
            int state = 6;
            while (state != 0)
            {
                switch (state)
                {
                    case 6:
                        Console.WriteLine("What would you like to do:\n1 - Display all books\n2 - Search by author\n3 - Search by title keyword");


                        String input = Console.ReadLine();

                        if (input != "1" && input != "2" && input != "3")
                        {
                            Console.WriteLine("Please enter 1, 2, or 3");
                            state = 1;

                        }
                        else
                        {
                            state = int.Parse(input);

                        }
                        break;

                    case 1:
                        SearchedBooks = Books;
                        state = PrintList(SearchedBooks);
                        break;


                    case 2:

                        Console.Write("What author would you like to search for: ");
                        String inpt = Console.ReadLine();
                        SearchedBooks = ReturnList.SearchAuthor(Books, inpt);
                        state = PrintList(SearchedBooks);
                        break;

                    case 3:
                        Console.Write("What keyword would you like to search for: ");
                        inpt = Console.ReadLine();
                        SearchedBooks = ReturnList.SearchTitleKeyword(Books, inpt);
                        state = PrintList(SearchedBooks);
                        break;

                    case 4:
                        Book checkout = new Book();
                        Boolean check = true;
                        while (check == true)
                        {
                            Console.WriteLine("Which book would you like to checkout?");
                            inpt = Console.ReadLine();
                            foreach (Book B in SearchedBooks)
                            {
                                if (B.Title == inpt)
                                {
                                    checkout = B;
                                    check = false;
                                }
                            }
                            if (check == true)
                            {
                                Console.WriteLine("Please enter a book from the list");
                            }
                        }
                        Checkout.CheckoutMethod(checkout);
                        
                        Console.WriteLine("Would you like to leave? (y/n)");
                        while (true)
                        {
                            inpt = Console.ReadLine();
                            if (inpt == "y")
                            {
                                Console.WriteLine("Have a nice day!");
                                state = 0;
                                break;
                            }
                            else if (inpt == "n")
                            {
                                state = 6;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Please enter y or n");
                            }
                        }
                        break;

                    case 5:

                        Console.WriteLine("Would you like to leave? (y/n)");
                        while (true)
                        {
                            inpt = Console.ReadLine();
                            if (inpt == "y")
                            {
                                Console.WriteLine("Have a nice day!");
                                state = 0;
                                break;
                            }
                            else if (inpt == "n")
                            {
                                state = 6;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Please enter y or n");
                            }
                        }
                        break;
                }
            }
        }
        
        public static int PrintList(List<Book> Books)
        {
            int state;
            foreach (Book B in Books)
            {
                Console.Write(B.Title + ", " + B.Author + ", ");
                if (B.Status == true)
                {
                    Console.WriteLine("Checked out" + B.DueDate);
                }
                else if (B.Status == false)
                {
                    Console.WriteLine("Checked in");
                }
            }
            Console.WriteLine("\nWould you like to check out a book? (y/n)");
            while (true)
            {
                String inpt = Console.ReadLine();
                if (inpt == "y")
                {
                    state = 4;
                    return state;
                }
                else if (inpt == "n")
                {
                    state = 5;
                    return state;
                }
                else
                {
                    Console.WriteLine("Please enter y or n");
                }
            }
        }
    }
}
