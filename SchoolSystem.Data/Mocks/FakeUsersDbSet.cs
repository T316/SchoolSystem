using System.Data.Entity;
using SchoolSystem.Models.EntityModels;
using System.Linq;

namespace SchoolSystem.Data.Mocks
{
    public class FakeUsersDbSet : FakeDbSet<User>
    {
        public override User Find(params object[] keyValues)
        {
            string wantedId = (string)keyValues[0];
            return this.Set.FirstOrDefault(user => user.Id == wantedId);
        }
    }
}