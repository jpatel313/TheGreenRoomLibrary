using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGreenRoomLibrary
{
    class BookListClass
    {
        private static List<Book> readFile()
        {
            List<Book> BookArray = new List<Book>();

            string filelocation = "../../DataFile.txt";

            StreamReader reader = new StreamReader(filelocation);

            string Data = reader.ReadToEnd().Trim();

            string[] Records = Data.Split('\n');
            bool check = true;
            foreach (string record in Records)
            {
                string[] rc = record.Split(',');
                if (rc[2] == "true")
                {
                    check = true;
                }
                else if (rc[2] == "false")
                {
                    check = false;
                }
                if (check == true)
                {
                    BookArray.Add(new Book(rc[0], rc[1], check, DateTime.Parse(rc[3])));
                }
                else if (check == false)
                {
                    BookArray.Add(new Book(rc[0], rc[1], check));
                }
                }
            reader.Close();
            return BookArray;
        }
    } 
}
