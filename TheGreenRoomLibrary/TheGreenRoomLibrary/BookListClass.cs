using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGreenRoomLibrary
{
    public class BookListClass
    {
        public static List<Book> readFile()
        {
            List<Book> BookArray = new List<Book>();

            string filelocation = "../../BookList.txt";

            StreamReader reader = new StreamReader(filelocation);
            
            string Data = reader.ReadToEnd().Trim();
            string[] Records = Data.Split('\n');
            bool check = true;
            
            foreach (string record in Records)
            {
                string[] rc = record.Trim().Split(',');
                if (rc[2].ToLower() == " true")
                {
                    check = true;
                    BookArray.Add(new Book(rc[0], rc[1], check, DateTime.Parse(rc[3])));
                }
                else if (rc[2].ToLower() == " false")
                {
                    check = false;
                    BookArray.Add(new Book(rc[0], rc[1], check));
                }
            }
            reader.Close();
            reader.Dispose();
            return BookArray;
        }
    } 
}
