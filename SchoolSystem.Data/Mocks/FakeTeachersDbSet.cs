using System.Data.Entity;
using SchoolSystem.Models.EntityModels;
using System.Linq;

namespace SchoolSystem.Data.Mocks
{
    public class FakeTeachersDbSet : FakeDbSet<Teacher>
    {
        public override Teacher Find(params object[] keyValues)
        {
            int wantedId = (int)keyValues[0];
            return this.Set.FirstOrDefault(teacher => teacher.Id == wantedId);
        }
    }
}