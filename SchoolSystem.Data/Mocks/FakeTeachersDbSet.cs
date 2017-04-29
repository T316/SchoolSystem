namespace SchoolSystem.Data.Mocks
{
    using SchoolSystem.Models.EntityModels;
    using System.Linq;

    public class FakeTeachersDbSet : FakeDbSet<Teacher>
    {
        public override Teacher Find(params object[] keyValues)
        {
            int wantedId = (int)keyValues[0];
            return this.Set.FirstOrDefault(teacher => teacher.Id == wantedId);
        }
    }
}