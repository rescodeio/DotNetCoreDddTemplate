using Domain;

namespace Data
{
    public class FakeInserter : IDataInserter<MyContext>
    {
        public void Insert(MyContext context)
        {
            context.Users.Add(new UserEntity("Dire Straits"));
            context.Users.Add(new UserEntity("Santana"));
            context.Users.Add(new UserEntity("AC/DC"));
            context.Users.Add(new UserEntity("Deep Purple"));
            context.Users.Add(new UserEntity("Motley Crue"));
            context.Users.Add(new UserEntity("Supertramp"));
            context.Users.Add(new UserEntity("Police"));

            context.SaveChanges();
        }
    }
}