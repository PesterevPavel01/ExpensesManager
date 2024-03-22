using ExpensesManager.Models;

namespace ExpensesManager.Services.Api
{
    internal class DepartnentService : CommonService<DepartmentDto,short>
    {
        public DepartnentService(string nameController)
        {
            _nameController = nameController;
        }
    }
}
