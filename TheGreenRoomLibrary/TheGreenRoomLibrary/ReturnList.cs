using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGreenRoomLibrary
{
    public class ReturnList
    {
        
        public static List<Book> SearchAuthor(List<Book> BookList, String author)
        {
            List<Book> BookArray = new List<Book>();

            foreach (Book B in BookList)
            {
                String a = B.Author;
                if (author == a)
                {
                    BookArray.Add(B);
                }
            }
            return BookArray;
        }



    }
}
