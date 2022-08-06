using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB.Infrastructure.Data
{
    public class GNBContext: DbContext
    {
        public GNBContext(DbContextOptions<GNBContext> options) : base(options) {}


    }
}
