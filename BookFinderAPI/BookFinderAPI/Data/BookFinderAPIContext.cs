using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookFinderAPI.Models;

namespace BookFinderAPI.Data
{
    public class BookFinderAPIContext : DbContext
    {
        public BookFinderAPIContext (DbContextOptions<BookFinderAPIContext> options)
            : base(options)
        {
        }

        public DbSet<BookFinderAPI.Models.BookFinderModel> BookFinderModel { get; set; }
    }
}
