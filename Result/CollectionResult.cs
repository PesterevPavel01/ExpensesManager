using System.Collections.Generic;

namespace ExpensesManager
{
    public class CollectionResult<T>:BaseResult<IEnumerable<T>>
    {
        public int Count { get; set; }
    }
}
