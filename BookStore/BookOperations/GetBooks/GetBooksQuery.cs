using BookStore.Common;
using BookStore.DBOperations;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;
        public GetBooksQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<BooksViewModel> Handle()
        {
            var bookList = _dbContext.Books.OrderBy(x => x.Id).ToList();
            List<BooksViewModel> vm = new List<BooksViewModel>();
            foreach (var book in bookList)
            {
                vm.Add(
                    new BooksViewModel
                    {
                        Id = book.Id,
                        Genre = ((GenreEnum)book.GenreId).ToString(),
                        PageCount = book.PageCount,
                        PublishDate = book.PublishDate.Date.ToString(format: "dd/MM/yyyy"),
                        Title = book.Title
                    });
            }
            return vm;
        }

        public class BooksViewModel
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }
            public string Genre { get; set; }
        }
    }
}
