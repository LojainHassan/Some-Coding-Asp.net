using AutoMapper;
using WebApplication3.Model;
using WebApplication3.Models;

namespace WebApplication3.Dto
{
    public class profile:Profile
    {
        public profile()
        {
            CreateMap<Employee, EmployeeDto>().ForMember(des => des.employeeId, opt => opt.MapFrom(src => src.employeeId))
            
                 .ForMember(des => des.employeeId, opt => opt.MapFrom(src => src.employeeId))
                 .ForMember(des => des.hireDate, opt => opt.MapFrom(src => src.hireDate))
                 .ForMember(des => des.dateOfBirth, opt => opt.MapFrom(src => src.dateOfBirth))
                 .ForMember(des => des.position, opt => opt.MapFrom(src => src.position))
                 .ForMember(des => des.salary, opt => opt.MapFrom(src => src.salary))
                ;

            CreateMap<Emails, EmailDto>();
            CreateMap<CompanyEmployee, EmployeeDto>()
                .ForMember(des => des.employeeId, opt => opt.MapFrom(src => src.employeeId))
                 .ForMember(des => des.firstName, opt => opt.MapFrom(src => src.FirstName))
                 .ForMember(des => des.lastName, opt => opt.MapFrom(src => src.LastName))
   .ForMember(des => des.hireDate, opt => opt.MapFrom(src => src.HireDate))
      .ForMember(des => des.position, opt => opt.MapFrom(src => src.Position))
   .ForMember(des => des.dateOfBirth, opt => opt.MapFrom(src => src.DateOfbirth))
    .ForMember(des => des.hireDate, opt => opt.MapFrom(src => src.HireDate))
 .ForMember(des => des.salary, opt => opt.MapFrom(src => src.Salary));

        }
    }
}
