using ExpensesManager.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesManager.Services.Api
{
    public class CommonService<T,Id>:ICommonService<T,Id>
    {
        public readonly HttpConnector _httpConnector = new HttpConnector();

        public string _nameController;

        public CommonService()
        {
        }

        public CommonService(string nameController) 
        {
            _nameController = nameController;
        }

        public async Task<BaseResult<T>> CreateAsync(T modelDto)
        {
            BaseResult<T>? result;

            string response = await _httpConnector.DoActionWithDataByUrl(_nameController, JsonConvert.SerializeObject(modelDto), HttpMethod.Post);

            if (response != null)
                return JsonConvert.DeserializeObject<BaseResult<T>>(response);

            var emptyResult = new BaseResult<T>();

            emptyResult.ErrorMessage = "null";

            return emptyResult;
        }

        public Task<BaseResult<T>> CreateMultiple(List<T> listModelDto)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResult<T>> DeleteAsync(Id id)
        {
            BaseResult<T>? result;

            string response = await _httpConnector.DoActionWithDataByUrl(_nameController, JsonConvert.SerializeObject(id), HttpMethod.Delete);

            if (response != null)
                return JsonConvert.DeserializeObject<BaseResult<T>>(response);

            var emptyResult = new BaseResult<T>();

            emptyResult.ErrorMessage = "null";

            return emptyResult;
        }

        public async Task<List<T>> GetAllAsync()
        {
            CollectionResult<T>? result;

            string response = await _httpConnector.GetDataByUrl(_nameController);

            if (response != null)
            {
                result = JsonConvert.DeserializeObject<CollectionResult<T>>(response);
            }
            else
            {
                return new List<T>();
            }

             

            return (List<T>)result.Data;
        }

        public Task<BaseResult<T>> GetByIdAsync(Id id)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResult<T>> UpdateAsync(T modelDto)
        {
            BaseResult<T>? result;

            string response = await _httpConnector.DoActionWithDataByUrl(_nameController, JsonConvert.SerializeObject(modelDto), HttpMethod.Patch);

            if (response != null)
                return JsonConvert.DeserializeObject<BaseResult<T>>(response);

            var emptyResult = new BaseResult<T>();

            emptyResult.ErrorMessage = "null";

            return emptyResult;
        }
    }
}
