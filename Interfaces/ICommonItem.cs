namespace ExpensesManager
{
    public interface ICommonItem<T> where T : struct
    {
        public T? Id { get; set; }
        public string Name { get; set; }
    }
}
