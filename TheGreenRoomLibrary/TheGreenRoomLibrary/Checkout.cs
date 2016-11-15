using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGreenRoomLibrary
{
    public class Checkout : BookListClass
    {
        bool agree = true;

        public static void CheckInMethod(Book books)
        {
            if (books.Status == true)
            {
                books.Status = false;
                Console.WriteLine("Thank you for returning this book!");
            }
            else
            {
                Console.WriteLine("ERROR: Contact Library immediately!");
            }
        }

        public static void CheckoutMethod(Book books)
        {

            if (books.Status == false)
            {
                books.Status = true;

                DateTime dueDate = DateTime.Now.AddDays(14);
                Console.WriteLine($"This book is due on: {dueDate}");
            }
            else
            {
                Console.WriteLine("That book is not available.  Please choose another book.");
            }
        }
    }
}
