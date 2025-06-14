using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USON.Domain.Entities
{
    public class User:IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mobile {  get; set; }
        public string UniversityName { get; set; }
        public string? Sessition { get; set; }
        public string ? DepartmentName { get; set; }
        public string? UnionName { get; set; }
        public int? WordNo { get; set; }
        public string? VillageName { get; set; }
        public string? SchoolName { get; set; }
        public string ?SSCPassingYear { get; set; }
        public string ?CollegelName { get; set; }
        public string ?HSCPassingYear { get; set; }



        public string Occupation {  get; set; }
        public string CurrentLocation { get; set; }

    }
}
