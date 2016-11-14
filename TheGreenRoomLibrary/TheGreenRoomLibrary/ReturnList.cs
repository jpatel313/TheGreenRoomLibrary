﻿using System;
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
                if (author.ToLower() == a.ToLower())
                {
                    BookArray.Add(B);
                }
            }
            return BookArray;
        }

        public static List<Book> SearchTitleKeyword(List<Book> BookList, String titleKeyword)
        {
            List<Book> BookArray = new List<Book>();

            foreach (Book B in BookList)
            {
                String t = B.Title;
                String[] title = t.Split(' ');
                foreach (String word in title)
                {
                    if (word.ToLower() == titleKeyword.ToLower())
                    {
                        BookArray.Add(B);
                    }
                }
            }

            return BookArray;
        }

    }
}
