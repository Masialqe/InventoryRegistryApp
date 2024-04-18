using Microsoft.EntityFrameworkCore;

namespace IR.Infrastructure.Context.Write
{
    public class WriteContext : DbContext
    {
        public WriteContext(DbContextOptions<WriteContext> options) : base(options) { }
    }
}
