namespace SchoolSystem.Data.Mocks
{
    using SchoolSystem.Models.EntityModels;
    using System.Linq;

    public class FakeNotesDbSet : FakeDbSet<Note>
    {
        public override Note Find(params object[] keyValues)
        {
            int wantedId = (int)keyValues[0];
            return this.Set.FirstOrDefault(note => note.Id == wantedId);
        }
    }
}