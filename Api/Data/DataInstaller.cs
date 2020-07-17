using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public static class DataInstaller
    {
        public static DbContext Install(bool isDev, ICollection<IDataInserter<MyContext>> inserters)
        {
            if (isDev)
            {
                var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
                optionsBuilder.UseInMemoryDatabase(typeof(MyContext).Name);
                var context = new MyContext(optionsBuilder.Options);
                foreach (var inserter in inserters)
                {
                    inserter.Insert(context);
                }
                
                return context;
            }
             
            throw new Exception("No production ready data source implemented");
        }
    }
}
