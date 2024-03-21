using ExpensesManager.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExpensesManager
{
    internal class DepartnentService : ICommonService<DepartmentDto, short>
    {
        private readonly HttpConnector _httpConnector = new HttpConnector();
        public async Task<BaseResult<DepartmentDto>> CreateAsync(DepartmentDto model)
        {
            BaseResult<DepartmentDto>? result;

            string response = await _httpConnector.DoActionWithDataByUrl("Department", JsonConvert.SerializeObject(model), HttpMethod.Post);

            if (response != null)
                return JsonConvert.DeserializeObject<BaseResult<DepartmentDto>>(response);

            var emptyResult = new BaseResult<DepartmentDto>();
            
            emptyResult.ErrorMessage = "null";
            
            return emptyResult;
        }

        public Task<BaseResult<DepartmentDto>> CreateMultiple(List<DepartmentDto> listModel)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResult<DepartmentDto>> DeleteAsync(short id)
        {
            BaseResult<DocumentDto>? result;
            
            string response = await _httpConnector.DoActionWithDataByUrl("Department", JsonConvert.SerializeObject(id), HttpMethod.Delete);

            if (response != null)
                return JsonConvert.DeserializeObject<BaseResult<DepartmentDto>>(response);

            var emptyResult = new BaseResult<DepartmentDto>();

            emptyResult.ErrorMessage = "null";

            return emptyResult;
        }

        public async Task<List<DepartmentDto>> GetAllAsync()
        {
            CollectionResult<DepartmentDto>? result;

            string response =await _httpConnector.GetDataByUrl("Department");

            if (response != null)
            {
                result= JsonConvert.DeserializeObject<CollectionResult<DepartmentDto>>(response);
            }
            else
            {
                return null;
            }

            List<DepartmentDto> departments = (List<DepartmentDto>)result.Data;

            return departments;
        }

        public Task<BaseResult<DepartmentDto>> GetByIdAsync(short id)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResult<DepartmentDto>> UpdateAsync(DepartmentDto model)
        {
            BaseResult<DepartmentDto>? result;

            string response = await _httpConnector.DoActionWithDataByUrl("Department", JsonConvert.SerializeObject(model), HttpMethod.Patch);

            if (response != null)
                return JsonConvert.DeserializeObject<BaseResult<DepartmentDto>>(response);

            var emptyResult = new BaseResult<DepartmentDto>();

            emptyResult.ErrorMessage = "null";

            return emptyResult;
        }
    }
}
