using System.Data.Entity;
using SchoolSystem.Models.EntityModels;
using System.Linq;

namespace SchoolSystem.Data.Mocks
{
    public class FakeMarksDbSet : FakeDbSet<Mark>
    {
        public override Mark Find(params object[] keyValues)
        {
            int wantedId = (int)keyValues[0];
            return this.Set.FirstOrDefault(mark => mark.Id == wantedId);
        }
    }
}