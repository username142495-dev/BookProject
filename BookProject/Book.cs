
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BookProject
{
    enum Genre
    {
        Comedy,
        Horror,
        Adventure,
        Fantasy
    }

    /// <summary>
    /// Book Class
    /// </summary>
    internal class Book
    {
        private DateTime _Releasedate;
        private int _bookid;
        
        public string BookName { get; set; } = string.Empty;
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate
        {
            get => _releasedate;
            set
            {
                if(value >= DateTime.Now)
                {
                    throw new ArgumentException("Wrong datetime input");
                }

            }
        }
            

        public int BookId {
            get => _bookid;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Id cant be less then 0");
                }

            }
        }
        public Genre Genre { get; set; }
        public Book() { }
        public Book(string author, string title, string description, DateTime releasedate, Genre genre, int bookid, string bookname) 
        {
            this.BookName = bookname;
            this.Author = author;
            this.Title = title;
            this.Description = description;
            this.ReleaseDate = releasedate;
            this.BookId = bookid;
            this.Genre = genre; 
        }

        
        public override string ToString()
        {
            return $"ID: {BookId}, " +
                $"Name: {BookName}, " +
                $"Author: {Author}, " +
                $"Title: {Title}, " +
                $"Genre: {Genre}, " +
                $"Release Date: {ReleaseDate.ToShortDateString()}";
        }

    }

}
