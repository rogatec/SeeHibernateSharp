using System;

namespace Hibernate.Domain
{
    public class Employee
    {
        public virtual int EmployeeKey { get; set; }
        public virtual string EmployeeName { get; set; }
        public virtual string PreferredName { get; set; }
        public virtual Boolean IsSalesperson { get; set; }
    }
}
