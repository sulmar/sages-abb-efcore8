using Microsoft.EntityFrameworkCore;
using SakilaConsole.Infrastructure;
using SakilaConsole.Infrastructure.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sages.ABB.Test;

partial class SakilaContext
{
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Customer>()
        //    .Navigation(p => p.Address)
        //    .AutoInclude();

        //modelBuilder.Entity<Address>()
        //   .Navigation(p => p.City)
        //   .AutoInclude();

        //modelBuilder
        //        .ApplyConfiguration(new CustomerConfiguration())
        //        .ApplyConfiguration(new AddressConfiguration());


     //   modelBuilder.ApplyConfigurationsFromAssembly(typeof(SakilaContext).Assembly);

    }
}
