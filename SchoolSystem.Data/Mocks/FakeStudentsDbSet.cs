namespace SchoolSystem.Data.Mocks
{
    using SchoolSystem.Models.EntityModels;
    using System.Linq;

    public class FakeStudentsDbSet : FakeDbSet<Student>
    {
        public override Student Find(params object[] keyValues)
        {
            int wantedId = (int)keyValues[0];
            return this.Set.FirstOrDefault(student => student.Id == wantedId);
        }
    }
}