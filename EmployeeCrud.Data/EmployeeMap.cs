using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeCrud.Data
{
    public class EmployeeMap
    {
        public EmployeeMap(EntityTypeBuilder<Employee> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.PersonalNumber).IsRequired().HasMaxLength(20);
            entityBuilder.Property(t => t.FirstName).IsRequired();
            entityBuilder.Property(t => t.LastName).IsRequired();
            entityBuilder.Property(t => t.Address);
            entityBuilder.Property(t => t.Birthday);
            entityBuilder.Property(t => t.IsActive).IsRequired();
        }
    }
}