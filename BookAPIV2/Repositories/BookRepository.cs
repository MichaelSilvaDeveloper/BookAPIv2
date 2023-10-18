using BookAPIV2.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookAPIV2.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _bookContext;

        public BookRepository(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _bookContext.Books.ToListAsync();
        }

        public async Task<Book> GetBookById(int id)
        {
            return await _bookContext.Books.FindAsync(id);      
        }

        public async Task<Book> Create(Book book)
        {
            _bookContext.Books.Add(book);
            await _bookContext.SaveChangesAsync();
            return book;
        }

        public async Task Update(Book book)
        {
            _bookContext.Entry(book).State = EntityState.Modified;
            await _bookContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var bookToDelete = await _bookContext.Books.FindAsync(id);
            _bookContext.Books.Remove(bookToDelete);
            await _bookContext.SaveChangesAsync();
        }
    }
}