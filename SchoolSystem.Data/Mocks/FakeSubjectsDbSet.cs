using System.Data.Entity;
using SchoolSystem.Models.EntityModels;
using System.Linq;

namespace SchoolSystem.Data.Mocks
{
    public class FakeSubjectsDbSet : FakeDbSet<Subject>
    {
        public override Subject Find(params object[] keyValues)
        {
            int wantedId = (int)keyValues[0];
            return this.Set.FirstOrDefault(subject => subject.Id == wantedId);
        }
    }
}