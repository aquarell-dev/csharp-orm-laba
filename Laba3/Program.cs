using Microsoft.EntityFrameworkCore;
using System;

namespace Laba3
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (ClubContext context = new ClubContext())
            {
                Utils utils = new Utils();
                Menu menu = new Menu(context, utils);
                menu.start();
            }
        }
    }
}