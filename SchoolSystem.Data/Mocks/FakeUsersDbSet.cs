namespace SchoolSystem.Data.Mocks
{
    using SchoolSystem.Models.EntityModels;
    using System.Linq;

    public class FakeUsersDbSet : FakeDbSet<User>
    {
        public override User Find(params object[] keyValues)
        {
            string wantedId = (string)keyValues[0];
            return this.Set.FirstOrDefault(user => user.Id == wantedId);
        }
    }
}