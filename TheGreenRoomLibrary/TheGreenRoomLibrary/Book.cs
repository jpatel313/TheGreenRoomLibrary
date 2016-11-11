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
        private DateTime dueDate;
        

        public Book(string author, string title, bool status, DateTime dueDate)
        {
            Author = author;
            Title = title;
            Status = status;
            DueDate = dueDate;
        }
        public Book(string author, string title, bool status)
        {
            Author = author;
            Title = title;
            Status = status;
        }

        public Book()
        {
            this.Author = author;
            this.Title = title;
            this.Status = status;
            this.DueDate = dueDate;
        }

        #region Get/Set
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

        public DateTime DueDate
        {
            get
            {
                return dueDate;
            }

            set
            {
                dueDate = value;
            }
            #endregion

        }


    }
}
