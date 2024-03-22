using ExpensesManager;
using ExpensesManager.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExpensesManager.Services.Api
{
    public class OrganizationService : CommonService<OrganizationDto, short>
    {

        public OrganizationService(string nameController)
        {
            _nameController = nameController;
        }
    }
}
