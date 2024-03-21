using ExpensesManager;
using ExpensesManager.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExpensesManager
{
    internal class OrganizationService : ICommonService<OrganizationDto, short>
    {
        private readonly HttpConnector _httpConnector = new HttpConnector();
        public async Task<BaseResult<OrganizationDto>> CreateAsync(OrganizationDto model)
        {
            CollectionResult<OrganizationDto>? result;

            string response = await _httpConnector.DoActionWithDataByUrl("Organization", JsonConvert.SerializeObject(model), HttpMethod.Post);

            if (response != null)
                return JsonConvert.DeserializeObject<BaseResult<OrganizationDto>>(response);

            var emptyResult = new BaseResult<OrganizationDto>();

            emptyResult.ErrorMessage = "null";
            
            return emptyResult; ;
        }

        public Task<BaseResult<OrganizationDto>> CreateMultiple(List<OrganizationDto> listModel)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResult<OrganizationDto>> DeleteAsync(short id)
        {
            BaseResult<DocumentDto>? result;

            string response = await _httpConnector.DoActionWithDataByUrl("Organization",  JsonConvert.SerializeObject(id), HttpMethod.Delete);

            if (response != null)
                return JsonConvert.DeserializeObject<BaseResult<OrganizationDto>>(response);

            var emptyResult = new BaseResult<OrganizationDto>();

            emptyResult.ErrorMessage = "null";

            return emptyResult;
        }

        public async Task<List<OrganizationDto>> GetAllAsync()
        {
            CollectionResult<OrganizationDto>? result;

            string response =await _httpConnector.GetDataByUrl("Organization");

            if (response != null)
            {
                result= JsonConvert.DeserializeObject<CollectionResult<OrganizationDto>>(response);
            }
            else
            {
                return null;
            }

            List<OrganizationDto> departments = (List<OrganizationDto>)result.Data;

            return departments;
        }

        public Task<BaseResult<OrganizationDto>> GetByIdAsync(short id)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResult<OrganizationDto>> UpdateAsync(OrganizationDto model)
        {
            BaseResult<OrganizationDto>? result;

            string response = await _httpConnector.DoActionWithDataByUrl("Organization", JsonConvert.SerializeObject(model), HttpMethod.Patch);

            if (response != null)
                return JsonConvert.DeserializeObject<BaseResult<OrganizationDto>>(response);

            var emptyResult = new BaseResult<OrganizationDto>();

            emptyResult.ErrorMessage = "null";

            return emptyResult; ;
        }
    }
}
