using System;

namespace ExpensesManager.Models
{
    public record CreateDocumentDto(double Value, DateTime Date,string Comment,string Expenditure,string Organization, string Department );

}
