namespace ExpensesManager.Models
{
    public class OrganizationDto : ICommonItem<short>
    {
        public OrganizationDto() { }
        public OrganizationDto(short? id, string name)
        {
            Id = id;
            Name = name;
        }

        public short? Id { get; set; }
        public string Name { get ; set ; }
    }

}
