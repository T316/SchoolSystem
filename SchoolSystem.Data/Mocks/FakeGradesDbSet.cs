using System.Data.Entity;
using SchoolSystem.Models.EntityModels;
using System.Linq;

namespace SchoolSystem.Data.Mocks
{
    public class FakeGradesDbSet : FakeDbSet<Grade>
    {
        public override Grade Find(params object[] keyValues)
        {
            int wantedId = (int)keyValues[0];
            return this.Set.FirstOrDefault(grade => grade.Id == wantedId);
        }
    }
}