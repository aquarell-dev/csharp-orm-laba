using Microsoft.EntityFrameworkCore;

namespace Laba3
{ 
    // todo: generic menu
    public class Menu
    {
        private Utils utils;
        private DbContext context;

        public Menu(DbContext context, Utils utils)
        {
            this.utils = utils;
            this.context = context;
        }

        public void start()
        {
            while (true)
            {
                printStartMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        create();
                        break;
                    case "2":
                        list();
                        break;
                    case "3":
                        update();
                        break;
                    case "4":
                        delete();
                        break;
                    default: break;
                }
            }
        }

        void create()
        {
            while (true)
            {
                printModelsMenu();
                string choice = Console.ReadLine();

                Console.Clear();

                switch (choice)
                {
                    case "1":
                        utils.create<Club>(context);
                        break;
                    case "2":
                        utils.create<Team>(context);
                        break;
                    case "3":
                        utils.create<Owner>(context);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Input is not valid.");
                        break;
                }
            }
        }

        void update()
        {

            printModelsMenu();
            string choice = Console.ReadLine();

            Console.Clear();

            switch (choice)
            {
                case "1":
                    utils.update<Club>("Select entity id to update", context);
                    break;
                case "2":
                    utils.update<Team>("Select entity id to update", context);
                    break;
                case "3":
                    utils.update<Owner>("Select entity id to update", context);
                    break;
                case "0":
                    return; // Возврат в предыдущее меню
                default:
                    Console.WriteLine("Некорректный выбор. Пожалуйста, выберите одну из доступных опций.");
                    break;
            }

        }

        void list()
        {
            printModelsMenu();
            string choice = Console.ReadLine();

            Console.Clear();

            switch (choice)
            {
                case "1":
                    utils.list<Club>("Displaying: ", context);
                    break;
                case "2":
                    utils.list<Team>("Displaying: ", context);
                    break;
                case "3":
                    utils.list<Owner>("Displaying: ", context);
                    break;
                case "0":
                    return; // Возврат в предыдущее меню
                default:
                    Console.WriteLine("Некорректный выбор. Пожалуйста, выберите одну из доступных опций.");
                    break;
            }

        }

        void delete()
        {
            printModelsMenu();
            string choice = Console.ReadLine();

            Console.Clear();

            switch (choice)
            {
                case "1":
                    utils.delete<Club>(context);
                    break;
                case "2":
                    utils.delete<Team>(context);
                    break;
                case "3":
                    utils.delete<Owner>(context);
                    break;
                case "0":
                    return; // Возврат в предыдущее меню
                default:
                    Console.WriteLine("Некорректный выбор. Пожалуйста, выберите одну из доступных опций.");
                    break;
            }


        }

        private void printStartMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Select action:");
            Console.WriteLine("1. Create");
            Console.WriteLine("2. List");
            Console.WriteLine("3. Update");
            Console.WriteLine("4. Delete");
            Console.WriteLine("0. Exit");

            Console.Write("Your choice: ");
        }

        private void printModelsMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Select table:");
            Console.WriteLine("1. Clubs");
            Console.WriteLine("2. Teams");
            Console.WriteLine("3. Owners");
            Console.WriteLine("0. Go back");

            Console.Write("Your choice: ");
        }
    }
}
