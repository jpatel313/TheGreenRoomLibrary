using System;
using System.Collections.Generic;
using System.IO;
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
                        Console.WriteLine("What would you like to do:\n1 - Display all books\n2 - Search by author\n3 - Search by title keyword\n4 - Donate a book");


                        String input = Console.ReadLine();

                        if (input != "1" && input != "2" && input != "3" && input != "4" && input != "8")
                        {
                            Console.WriteLine("Please enter 1, 2, 3, or 4");
                            state = 6;

                        }
                        else
                        {
                            state = int.Parse(input);
                            if (input == "4")
                            {
                                state = 7;
                            }
                            
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
                                if (B.Title.ToLower() == inpt.ToLower())
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
                        Checkout.CheckoutMethod(ref checkout);

                        state = 5;
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
                                SaveChanges(Books);
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

                    case 7:
                        Book Bo = new Book();
                        Bo = Checkout.Donate();
                        Books.Add(Bo);
                        state = 5;
                        break;
                    case 8:
                        Console.WriteLine("You must be an admin to check a book in, what is your password: ");
                        String i = Console.ReadLine();
                        if (i.ToLower() == "googleit")
                        {
                            Console.WriteLine("Welcome admin, would you like to check in a book?");
                            while (true)
                            {
                                i = Console.ReadLine();
                                if (i == "y")
                                {
                                    Book checkin = new Book();
                                    Boolean c = true;
                                    SearchedBooks = ReturnList.SearchCheckedOut(Books);
                                    PrintList(SearchedBooks);
                                    while (c == true)
                                    {
                                        Console.WriteLine("Which book would you like to check in?");
                                        i = Console.ReadLine();

                                        foreach (Book B in Books)
                                        {
                                            if (B.Title.ToLower() == i.ToLower())
                                            {
                                                checkin = B;
                                                c = false;
                                            }
                                        }
                                        if (c == true)
                                        {
                                            Console.WriteLine("Please enter a book from the list");
                                        }
                                       
                                    }
                                    Checkout.CheckInMethod(ref checkin);
                                    state = 5;
                                    break;
                                }
                                else if (i == "n")
                                {
                                    state = 5;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Please enter y or n");
                                }
                                
                            }
                        }
                        else
                        {
                            Console.WriteLine("Incorrect password");
                            state = 6;
                            break;
                        }
                        break;
                }
            }
        }
        
        public static void SaveChanges(List<Book> Books)
        {
            string filelocation = "../../BookList.txt";
            StreamWriter writer = new StreamWriter(filelocation);
            List<String> LS = new List<string>();
            foreach (Book B in Books)
            {
                LS.Add(B.Title + ",");
                LS.Add(B.Author + ", ");
                
                if (B.Status == true)
                {
                    LS.Add(Convert.ToString(B.Status) + ", ");
                    LS.Add(Convert.ToString(B.DueDate + "\n"));
                }
                else
                {
                    LS.Add(Convert.ToString(B.Status)+"\n");
                }
                
            }
            foreach (String s in LS)
            {
                writer.Write(s);
            }
            writer.Close();
        }


        public static int PrintList(List<Book> Books)
        {
            int state;
            foreach (Book B in Books)
            {
                Console.Write(B.Title + ", " + B.Author + ", ");
                if (B.Status == true)
                {
                    Console.WriteLine("Checked out, due back: " + B.DueDate);
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
