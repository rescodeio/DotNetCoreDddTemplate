using Microsoft.EntityFrameworkCore;

namespace Data
{
    public interface IDataInserter<in T>
        where T : DbContext
    {
        void Insert(T context);
    }
}