using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGreenRoomLibrary
{
    public class Checkout
    {
        public static void CheckInMethod(ref Book books)
        {
            if (books.Status == true)
            {
                Console.WriteLine("Do you want to check this book in? (y/n): ");
                string yes = (Console.ReadLine().ToLower());

                if (yes == "y" && yes != null)
                {
                    books.Status = false;
                    Console.WriteLine("Thank you for returning this book!");
                }

                else
                    Console.WriteLine("ERROR: Contact Library immediately!");
            }
        }

        public static string CheckoutMethod(ref Book books)
        {

            if (books.Status == false)
            {
                books.Status = true;

                DateTime dueDate = DateTime.Now.AddDays(14);

                return ($"You have successfuly checked this book out. Due date: {dueDate}");
            }

            else
            {
                return ("That book is not available.  Please choose another book.");
            }
        }
    }
}
