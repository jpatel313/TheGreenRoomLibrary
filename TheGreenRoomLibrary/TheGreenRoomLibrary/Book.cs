using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGreenRoomLibrary
{
    public class Book
    {
        private string author;
        private string title;
        private bool status;
        private bool dueDate;
        

        public Book(string author, string title, bool status, bool dueDate)
        {
            Author = author;
            Title = title;
            Status = status;
            DueDate = dueDate;
        }
        public Book()
        {
            this.Author = author;
            this.Title = title;
            this.Status = status;
            this.DueDate = dueDate;
        }
        public string Author
        {
            get
            {
                return author;
            }

            set
            {
                author = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public bool Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public bool DueDate
        {
            get
            {
                return dueDate;
            }

            set
            {
                dueDate = value;
            }
        }

        
    }
}
