using SchoolSystem.Data;
using SchoolSystem.Data.Interfaces;
using SchoolSystem.Data.Mocks;

namespace SchoolSystem.Services
{
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