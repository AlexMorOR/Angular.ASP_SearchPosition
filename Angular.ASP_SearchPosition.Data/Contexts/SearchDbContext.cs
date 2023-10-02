using Angular.ASP_SearchPosition.Data.Entities;
using Angular.ASP_SearchPosition.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angular.ASP_SearchPosition.Data.Contexts
{
    public class SearchDbContext : DbContext
    {
        public SearchDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<SearchResultModel> SearchResults { get; set; }

        public DbSet<RequestModel> Requests { get; set; }
    }
}
