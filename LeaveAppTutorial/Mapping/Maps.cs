using AutoMapper;
using LeaveAppTutorial.Data;
using LeaveAppTutorial.Models;

namespace LeaveAppTutorial.Mapping
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<LeaveType, LeaveTypeVM>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestVM>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationVM>().ReverseMap();

        }
    }
}
