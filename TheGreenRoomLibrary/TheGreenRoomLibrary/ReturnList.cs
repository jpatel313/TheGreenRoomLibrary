using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGreenRoomLibrary
{
    public class ReturnList
    {

        public static List<Book> SearchAuthor(List<Book> BookList, string author)
        {
            List<Book> BookArray = new List<Book>();

            foreach (Book B in BookList)
            {
                string a = B.Author;
                string[] auth = a.Split(' ');

                foreach (string word in auth)
                {
                    if (author.ToLower() == word.ToLower())
                    {
                        BookArray.Add(B);
                    }
                }
            }
            return BookArray;
        }

        public static List<Book> SearchTitleKeyword(List<Book> BookList, string titleKeyword)
        {
            List<Book> BookArray = new List<Book>();

            foreach (Book B in BookList)
            {
                string t = B.Title;
                string[] title = t.Split(' ');

                foreach (string word in title)
                {
                    if (word.ToLower() == titleKeyword.ToLower())
                    {
                        BookArray.Add(B);
                    }
                }
            }

            return BookArray;
        }

        public static List<Book> SearchCheckedOut(List<Book> BookList)
        {
            List<Book> BookArray = new List<Book>();

            foreach (Book B in BookList)
            {
                if (B.Status == true)
                {
                    BookArray.Add(B);
                }
            }

            return BookArray;
        }

    }
}
