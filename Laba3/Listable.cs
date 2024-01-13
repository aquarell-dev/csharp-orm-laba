using Microsoft.EntityFrameworkCore;

namespace Laba3
{
    public interface Listable
    {
        public List<string?> list<T>(string caption, DbContext context) where T : class;
    }
}
