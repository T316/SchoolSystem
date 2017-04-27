using System.Data.Entity;
using SchoolSystem.Models.EntityModels;
using System.Linq;

namespace SchoolSystem.Data.Mocks
{
    public class FakeStudentsDbSet : FakeDbSet<Student>
    {
        public override Student Find(params object[] keyValues)
        {
            int wantedId = (int)keyValues[0];
            return this.Set.FirstOrDefault(student => student.Id == wantedId);
        }
    }
}