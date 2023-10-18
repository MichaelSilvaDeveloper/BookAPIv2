using BookAPIV2.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookAPIV2.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooks();

        Task<Book> GetBookById(int id);

        Task<Book> Create(Book book);

        Task Update(Book book);

        Task Delete(int id);
    }
}