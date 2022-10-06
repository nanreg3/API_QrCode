using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API_QrCode.models;

namespace API_QrCode.Data
{
    public class API_QrCodeContext : DbContext
    {
        public API_QrCodeContext (DbContextOptions<API_QrCodeContext> options)
            : base(options)
        {
        }

        public DbSet<API_QrCode.models.Identificador> Identificadores { get; set; }

        public DbSet<API_QrCode.models.Pessoa> Pessoas { get; set; }

        public DbSet<API_QrCode.models.LogAcesso> LogAcesso { get; set; }
    }
}
