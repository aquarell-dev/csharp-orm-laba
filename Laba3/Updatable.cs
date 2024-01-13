using Microsoft.EntityFrameworkCore;

namespace Laba3
{
    public interface Updatable
    {
        public bool? update<T>(string caption, DbContext context) where T : class;
    }
}
