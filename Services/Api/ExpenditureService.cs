using ExpensesManager;
using ExpensesManager.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExpensesManager
{
    internal class ExpenditureService : ICommonService<ExpenditureDto, short>
    {
        private readonly HttpConnector _httpConnector = new HttpConnector();
        public async Task<BaseResult<ExpenditureDto>> CreateAsync(ExpenditureDto model)
        {
            BaseResult<ExpenditureDto>? result;

            string response = await _httpConnector.DoActionWithDataByUrl("Expenditure", JsonConvert.SerializeObject(model), HttpMethod.Post);

            if (response != null)
                return JsonConvert.DeserializeObject<BaseResult<ExpenditureDto>>(response);
            
            var emptyResult = new BaseResult<ExpenditureDto>();
            
            emptyResult.ErrorMessage = "null";
            
            return emptyResult;
        }

        public Task<BaseResult<ExpenditureDto>> CreateMultiple(List<ExpenditureDto> listModel)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResult<ExpenditureDto>> DeleteAsync(short id)
        {
            BaseResult<DocumentDto>? result;
            
            string response = await _httpConnector.DoActionWithDataByUrl("Expenditure", JsonConvert.SerializeObject(id), HttpMethod.Delete);

            if (response != null)
                return JsonConvert.DeserializeObject<BaseResult<ExpenditureDto>>(response);

            var emptyResult = new BaseResult<ExpenditureDto>();

            emptyResult.ErrorMessage = "null";

            return emptyResult;
        }

        public async Task<List<ExpenditureDto>> GetAllAsync()
        {
            CollectionResult<ExpenditureDto>? result;

            string response =await _httpConnector.GetDataByUrl("Expenditure");

            if (response != null)
            {
                result= JsonConvert.DeserializeObject<CollectionResult<ExpenditureDto>>(response);
            }
            else
            {
                return null;
            }


            if (result.IsSuccess)return (List<ExpenditureDto>)result.Data;

            return new List<ExpenditureDto>();
        }

        public Task<BaseResult<ExpenditureDto>> GetByIdAsync(short id)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResult<ExpenditureDto>> UpdateAsync(ExpenditureDto model)
        {
            BaseResult<DocumentDto>? result;

            string response = await _httpConnector.DoActionWithDataByUrl("Expenditure", JsonConvert.SerializeObject(model), HttpMethod.Patch);

            if (response != null)
                return JsonConvert.DeserializeObject<BaseResult<ExpenditureDto>>(response);

            var emptyResult = new BaseResult<ExpenditureDto>();

            emptyResult.ErrorMessage = "null";

            return emptyResult;
        }
    }
}
