namespace Data
{
    public class EmptyInserter : IDataInserter<MyContext>
    {
        public void Insert(MyContext context)
        {
            // We insert nothing at all
        }
    }
}