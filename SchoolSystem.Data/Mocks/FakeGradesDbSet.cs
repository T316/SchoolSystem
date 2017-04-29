namespace SchoolSystem.Data.Mocks
{
    using SchoolSystem.Models.EntityModels;
    using System.Linq;

    public class FakeGradesDbSet : FakeDbSet<Grade>
    {
        public override Grade Find(params object[] keyValues)
        {
            int wantedId = (int)keyValues[0];
            return this.Set.FirstOrDefault(grade => grade.Id == wantedId);
        }
    }
}