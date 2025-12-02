using BookProject.Interfaces;



namespace BookProject
{
    internal class BookManager : IReadable, ICreatable<Book>, IUpdatable, IDeletable
    {
        private List<Book> _books = new List<Book>();

        public void Add(Book item)
        {
            _books.Add(item);
        }

        public bool DeleteById(int id)
        {
            var book = _books.FirstOrDefault(b => b.BookId == id);
            if (book == null) return false;

            _books.Remove(book);
            return true; ;
        }

        public void ShowAll()
        {
           foreach (var book in _books)
            {
                Console.WriteLine(book);
            }
        }

        public bool Update(int id, string Updated)
        {
            Book? result = _books.FirstOrDefault(x => x.BookId == id);
            if(result != null)
            {
                result.BookName = Updated;
                return true;
            }
            return false;
        }

        public BookManager()
        {
            Data();
        } 
        /// <summary>
        /// Function for Users
        /// </summary>
        /// 
        public bool BookFunction()
        {
            Console.WriteLine("\nChoose an action:");
            Console.WriteLine("1. Add a book");
            Console.WriteLine("2. Delete a book");
            Console.WriteLine("3. Update a book");
            Console.WriteLine("4. Show all books");
            Console.Write("Enter choice (1-4): ");

            string choice = Console.ReadLine()??string.Empty;

            switch (choice)
            {
                case "1":
                    Console.Write("Enter Book ID: ");
                    int id = int.Parse(Console.ReadLine() ?? string.Empty);

                    Console.Write("Enter Book Name: ");
                    string name = Console.ReadLine() ?? string.Empty;

                    Console.Write("Enter Author: ");
                    string author = Console.ReadLine() ?? string.Empty;

                    Console.Write("Enter Title: ");
                    string title = Console.ReadLine() ?? string.Empty;

                    Console.Write("Enter Description: ");
                    string description = Console.ReadLine() ?? string.Empty;

                    Console.Write("Enter Release Date (yyyy-mm-dd): ");
                    DateTime releaseDate = DateTime.Parse(Console.ReadLine() ?? string.Empty);

                    Console.Write("Enter Genre (Comedy, Horror, Adventure, Fantasy): ");
                    Genre genre = (Genre)Enum.Parse(typeof(Genre), Console.ReadLine() ?? string.Empty, true);

                    Book newBook = new Book(author, title, description, releaseDate, genre, id, name);
                    Add(newBook);

                    Console.WriteLine("Book added successfully!");
                    break;

                case "2":
                    Console.Write("Enter Book ID to delete: ");
                    int deleteId = int.Parse(Console.ReadLine() ?? string.Empty);

                    bool deleted = DeleteById(deleteId);
                    Console.WriteLine(deleted ? "Book deleted successfully!" : "Book not found.");
                    break;

                case "3":
                    Console.Write("Enter Book ID to update: ");
                    int updateId = int.Parse(Console.ReadLine() ?? string.Empty);

                    Console.Write("Enter new Book Name: ");
                    string newName = Console.ReadLine() ?? string.Empty;

                    bool updated = Update(updateId, newName);
                    Console.WriteLine(updated ? "Book updated." : "Book not found.");
                    break;

                case "4":
                    ShowAll();
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            Console.WriteLine("\nCurrent books:");
            ShowAll();
            return true;
        }

        private void Data()
        {
            string projectdir = Directory.GetParent(Environment.CurrentDirectory)?.Parent.Parent?.FullName ?? string.Empty;
            string fileDir = Path.Combine(projectdir, "Book Data");
            string filePath = Path.Combine(fileDir, "Books.xml");

            if(File.Exists(filePath))
            {
                Console.WriteLine("File cant be found");
            }
            _books.Clear();
        }
    }
}
