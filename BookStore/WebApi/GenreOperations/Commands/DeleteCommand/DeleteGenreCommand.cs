using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.GenreOperations.Commands.DeleteCommand
{
    public class DeleteGenreCommand
    {
         public int GenreId { get; set; }
        private readonly IBookStoreDbContext _dbContext;

        public DeleteGenreCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x=>x.Id == GenreId);
            if(genre is null) throw new InvalidOperationException("Sistemde Aranılan Tür Adı Bulunamadı");
            _dbContext.Genres.Remove(genre);
            _dbContext.SaveChanges();
        }
    }
}    
