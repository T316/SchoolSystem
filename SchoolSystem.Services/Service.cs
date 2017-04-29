namespace SchoolSystem.Services
{
    using SchoolSystem.Data.Interfaces;

    public class Service
    {
        private ISchoolSystemContext context;

        protected Service(ISchoolSystemContext context)
        {
            this.context = context;
        }

        protected ISchoolSystemContext Context => this.context;
    }
}