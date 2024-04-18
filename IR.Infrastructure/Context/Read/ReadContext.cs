using Microsoft.EntityFrameworkCore;

namespace IR.Infrastructure.Context.Read
{
    internal class ReadContext : DbContext
    {
        public ReadContext(DbContextOptions<ReadContext> options): base(options) { }
    }
}
