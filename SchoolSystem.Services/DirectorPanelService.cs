using SchoolSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Models.ViewModels.DirectorPanel;
using SchoolSystem.Models.EntityModels;
using AutoMapper;

namespace SchoolSystem.Services
{
    public class DirectorPanelService : Service, IDirectorPanelService
    {
        public IEnumerable<AllTeachersVm> getAllTeachers()
        {
            IEnumerable<Teacher> teachers = this.Context.Teacheres;
            IEnumerable<AllTeachersVm> vms = Mapper.Instance.Map<IEnumerable<Teacher>, IEnumerable<AllTeachersVm>>(teachers);

            return vms;
        }
    }
}
