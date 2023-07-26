using Quiz.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Quiz.Context
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            base.Seed(context);

            ToDo item = new ToDo
            {
                Name = "ToDoItem",
            };

            context.ToDos.Add(item);
            context.SaveChanges();
        }
    }
}