using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.BookOperations.Queries
{
    public class GetBookDetailQuery
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int BookId { get; set; }

        public GetBookDetailQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public BookDetailViewModel Handle()
        {
            var  book = _dbContext.Books.Include(x=>x.Author).Include(x=>x.Genre).Where(x=>x.Id == BookId).SingleOrDefault();
            if (book is null) throw new InvalidOperationException("Kitap kaydı bulunamadı");

            BookDetailViewModel viewModel = _mapper.Map<BookDetailViewModel>(book);
            

            return viewModel;
        }
    }

    public class BookDetailViewModel
    {
        public string  Title { get; set; } 
        public int PageCount { get; set; }
        public string  PublishDate { get; set; }
        public string Genre { get; set; }
        public string FullName { get; set; }
    }
}