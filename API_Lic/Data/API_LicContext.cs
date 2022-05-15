using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APILicenta.Models;
using API_Lic.Models;

namespace API_Lic.Data
{
    public class API_LicContext : DbContext
    {
        public API_LicContext (DbContextOptions<API_LicContext> options)
            : base(options)
        {
        }

        public DbSet<APILicenta.Models.Client> Client { get; set; }

        public DbSet<APILicenta.Models.User> User { get; set; }

        public DbSet<API_Lic.Models.Produs> Produs { get; set; }

        public DbSet<API_Lic.Models.Fel> Fel { get; set; }
    }
}
