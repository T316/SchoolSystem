namespace SchoolSystem.Data.Mocks
{
    using SchoolSystem.Models.EntityModels;
    using System.Linq;

    public class FakeSubjectsDbSet : FakeDbSet<Subject>
    {
        public override Subject Find(params object[] keyValues)
        {
            int wantedId = (int)keyValues[0];
            return this.Set.FirstOrDefault(subject => subject.Id == wantedId);
        }
    }
}