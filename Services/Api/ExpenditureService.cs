using ExpensesManager.Models;

namespace ExpensesManager.Services.Api
{
    internal class ExpenditureService : CommonService<ExpenditureDto, short>
    {
        public ExpenditureService(string nameController)
        {
            _nameController = nameController;
        }
    }
}
