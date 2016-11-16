using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGreenRoomLibrary
{
    public class Checkout
    {
        //Ref parameter to pass changes to Book List. Leaves text file unchanged.
        public static void CheckInMethod(ref Book books)
        {
            if (books.Status == true)
            {
                Console.WriteLine("Do you want to check this book in? (y/n): ");
                string yes = (Console.ReadLine().ToLower());

                if (yes == "y" && yes != null)
                {
                    //DateTime used to calculate due date.
                    DateTime time = DateTime.Now;

                    if (books.DueDate.CompareTo(time) > 0)

                    {
                        TimeSpan diff = books.DueDate.Subtract(time);
                        int daysOver = diff.Days;
                        double lateFee = daysOver * 0.1;

                        Console.WriteLine("This book is " + daysOver + " days overdue. You owe $" + lateFee + ".");
                    }

                    books.Status = false;

                    Console.WriteLine("Thank you for returning this book!");
                }

                else
                    Console.WriteLine("ERROR: Contact Library immediately!");
            }
        }

        //Changes bool in Book List to reflect checkout. False = not checked out.
        public static void CheckoutMethod(ref Book books)
        {
           
            if (books.Status == false)
            {
                books.Status = true;

                books.DueDate = DateTime.Now.AddDays(14);

                Console.WriteLine($"You have successfuly checked this book out. Due date: {books.DueDate} ");
            }

            else
            {
                Console.WriteLine("That book is not available.  Please choose another book...");
            }
        }

        public static Book Donate()
        {

            Console.WriteLine("What is the name of the book you would like to add? ");
            string title = Console.ReadLine();

            Console.WriteLine("Who wrote this book? ");
            string author = Console.ReadLine();

            Book B = new Book(title, " " + author, false);

            return B;
        }
    }
}
