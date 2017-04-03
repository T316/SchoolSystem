using SchoolSystem.Data;

namespace SchoolSystem.Services
{
    public class Service
    {
        private SchoolSystemContext context;

        protected Service()
        {
            this.context = new SchoolSystemContext();
        }

        protected SchoolSystemContext Context => this.context;
    }
}