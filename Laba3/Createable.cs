using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Laba3
{
    public interface Createable
    {
        public bool create<T>(DbContext context) where T : class, new();
    }
}
