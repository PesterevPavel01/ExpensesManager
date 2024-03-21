namespace ExpensesManager.Models
{
    public class DepartmentDto: ICommonItem<short>
    {
        public DepartmentDto()
        {
        }
        public DepartmentDto(short? id,string name) 
        {
            Id = id;
            Name = name;
        }

        public short? Id { get ; set ; }
        public string Name { get; set; }
    }
}
