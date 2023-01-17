using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Uitleendienst.ObjectClass;

namespace Uitleendienst
{
    public interface IUitleendienstDb : IDisposable
    {
        DbSet<Item> Items { get; set; }
        DbSet<LoanRecord> LoanRecords { get; set; }
        DbSet<Person> Persons { get; set; }
    }
    internal class UitleendienstDb : DbContext
    {
        public virtual DbSet<Item > Items { get; set; } 
        public virtual DbSet<LoanRecord> LoanRecords { get; set; }
        public virtual DbSet<Person> Persons { get; set; }


    
    }
}
