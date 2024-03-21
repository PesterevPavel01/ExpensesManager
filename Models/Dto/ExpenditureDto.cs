namespace ExpensesManager.Models
{
    public class ExpenditureDto : ICommonItem<short>
    {
        public ExpenditureDto(){}
        public ExpenditureDto(short? id, string name)
        {
            Id = id;
            Name = name;
        }

        public short? Id { get; set ; }
        public string Name { get ; set ; }
    }
}
