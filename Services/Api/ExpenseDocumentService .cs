using ExpensesManager.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ExpensesManager
{
    internal class ExpenseDocumentService : IDocumentService
    {
        private readonly HttpConnector _httpConnector = new HttpConnector();

        public async Task<BaseResult<DocumentDto>> CreateDocumentAsync(DocumentDto dto)
        {
            var response = await _httpConnector.GetDataByUrlAsync("ExpenseDocument", JsonConvert.SerializeObject(dto),HttpMethod.Post);
            
            if (response != null)
                return JsonConvert.DeserializeObject<BaseResult<DocumentDto>>(response);

                return null;
        }

        public Task<BaseResult<DocumentDto>> CreateDocumentsMultipleAsync(List<DocumentDto> listModels)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResult<DocumentDto>> DeleteDocumentAsync(long id)
        {
            BaseResult<DocumentDto>? result;
            //var response = await _httpConnector.GetDataByUrlAsync("ExpenseDocument", JsonConvert.SerializeObject(dto),HttpMethod.Patch);
            string response = await _httpConnector.DoActionWithDataByUrl("ExpenseDocument", JsonConvert.SerializeObject(id), HttpMethod.Delete);

            if (response != null)
                return JsonConvert.DeserializeObject<BaseResult<DocumentDto>>(response);

            var emptyResult = new BaseResult<DocumentDto>();

            emptyResult.ErrorMessage = "null";

            return emptyResult;
        }

        public Task<BaseResult<DocumentDto>> GetDocumentByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<CollectionResult<DocumentDto>> GetDocumentsAsync(DateTime dateStart, DateTime dateEnd, BitmapImage defaultIcon)
        {
            CollectionResult<DocumentDto>? result;

            List<Document> documentList = new();

            List<String> dates=new List<String> { dateStart.ToString("yyyy-MM-dd"), dateEnd.ToString("yyyy-MM-dd") };

            var response = await _httpConnector.GetDataByUrlAsync("ExpenseDocument/get", JsonConvert.SerializeObject(dates),HttpMethod.Post);

            if (response != null)
            {
               return JsonConvert.DeserializeObject<CollectionResult<DocumentDto>>(response);
            }
            else
            {
                var emptyResult = new CollectionResult<DocumentDto>();

                emptyResult.ErrorMessage = "null";

                return emptyResult;
            }

            //List<DocumentDto> documents = (List<DocumentDto>)result.Data;

            //if (result.Count > 0) 
            //{
            //    foreach (DocumentDto document in documents)
            //    {
            //        double number = double.TryParse(Convert.ToString(document.Value), out _) ? Convert.ToDouble(document.Value) : 0;                  
                    

            //        documentList.Add(new Document
            //        {
            //            Id = Convert.ToString(document.Id),
            //            Organization = document.Organization,
            //            Date = document.Date.ToString("dd.MM.yyyy"),
            //            Value = number.ToString(),
            //            Item = document.Expenditure,
            //            Department = document.Department,
            //            Comment = document.Comment,
            //            StatusIcon = defaultIcon
            //        });
            //    }
            //}
            //return documentList;
        }

        public Task<CollectionResult<DocumentDto>> GetDocumentsByExpenditureAsync(DateTime dateStart, DateTime dateEnd, string expenditureName)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResult<DocumentDto>> UpdateDocumentAsync(DocumentDto dto)
        {
            BaseResult<DocumentDto>? result;
            //var response = await _httpConnector.GetDataByUrlAsync("ExpenseDocument", JsonConvert.SerializeObject(dto),HttpMethod.Patch);
            string response = await _httpConnector.DoActionWithDataByUrl("ExpenseDocument", JsonConvert.SerializeObject(dto), HttpMethod.Patch);
            
            if (response != null)
                return JsonConvert.DeserializeObject<BaseResult<DocumentDto>>(response);
            return null;
        }

        List<DocumentDto> IDocumentService.GetDocumentsAsync(DateTime dateStart, DateTime dateEnd)
        {
            throw new NotImplementedException();
        }
    }
}
