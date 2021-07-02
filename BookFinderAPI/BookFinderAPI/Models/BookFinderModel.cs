using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookFinderAPI.Models
{
    public class BookFinderModel
    {
        public int Id { get; set; }
        public string bookTitle { get; set; }
        public string author { get; set; }
    }
}
