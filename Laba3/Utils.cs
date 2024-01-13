using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Laba3
{
    // todo: replace console.writelines with raising custom errors
    public class Utils : Createable, Updatable, Deleteable, Listable
    {
        public bool create<T>(DbContext context) where T : class, new()
        {
            T entity = new T();

            PropertyInfo[] props = typeof(T).GetProperties();

            foreach (var prop in props)
            {
                if (prop.GetCustomAttributes(typeof(NotMappedAttribute), true).Any())
                {
                    continue;
                }

                Console.WriteLine($"Enter {prop.Name}");
                string? input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input))
                {
                    object value = Convert.ChangeType(input, prop.PropertyType);
                    prop.SetValue(entity, value);
                }
            }
            
            try
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
            } catch (Exception ex) {
                Console.WriteLine($"Couldn't be saved due to {ex.Message}");
                return false;
            }
            
            return true;
        }

        public bool? update<T>(string caption, DbContext context) where T : class
        {
            Console.WriteLine(caption);

            int.TryParse(Console.ReadLine(), out int entityId);

            T? entity = context.Set<T>().Find(entityId);

            if (entity == null) return null;

            PropertyInfo[] props = typeof(T).GetProperties();

            foreach (var prop in props)
            {
                if (context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties.Any(p => p.Name == prop.Name)) continue;
                if (context.Model.FindEntityType(typeof(T)).GetForeignKeys().Any(fk => fk.Properties.Any(p => p.Name == prop.Name))) continue;
                if (prop.GetCustomAttributes(typeof(NotMappedAttribute), true).Any()) continue;

                Console.WriteLine($"Enter {prop.Name}: ");
                string? value = Console.ReadLine();

                if (value is null)
                {
                    Console.WriteLine("Property cannot be null");
                    return false;
                }

                prop.SetValue(entity, value);
            }

            try
            {
                context.SaveChanges();
            } catch (Exception e)
            {
                Console.WriteLine($"Couldn't update due to {e.Message}");
                return false;
            }
            
            return true;
        }

        public List<string?> list<T>(string caption, DbContext context) where T : class
        {
            Console.WriteLine(caption);

            List<T> records = context.Set<T>().ToList();

            var formattedRecords = records.Select(record => record.ToString()).ToList();

            formattedRecords.ForEach(record => Console.WriteLine(record));

            return formattedRecords;
        }

        public bool delete<T>(DbContext context) where T : class
        {
            var entity = context.Model.FindEntityType(typeof(T));

            if (entity == null)
            {
                Console.WriteLine("Couldnt find this entity");
                return false;
            }

            var keyProperties = entity?.FindPrimaryKey()?.Properties;

            if (keyProperties == null)
            {
                Console.WriteLine("Couldn't find entity pks");
                return false;
            }

            object[] pks = new object[keyProperties.Count];

            Console.WriteLine("Enter pk values");

            for (int i = 0; i < keyProperties.Count; i++)
            {
                Console.WriteLine($"{keyProperties[i].Name} value: ");
                bool isValid = int.TryParse(Console.ReadLine(), out int pk);

                if (!isValid) {
                    Console.WriteLine("Not valid pk");
                    return false;
                }

                pks[i] = pk;
            }

            var entityToDelete = context.Set<T>().Find(pks.ToArray());

            if (entityToDelete == null)
            {
                Console.WriteLine("Couldn't find entity by these pks");
                return false;
            }

            try
            {
                context.Remove(entityToDelete);
                context.SaveChanges();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            
            return true;
        }
    }
}
