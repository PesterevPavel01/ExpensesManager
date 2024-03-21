using System;

namespace ExpensesManager.Models
{
    public class DocumentDto
    {
        public long? Id { get; set; }
        public double Value { get; set; }
        public string Comment { get; set; }
        public string? Expenditure { get; set; }
        public string? Organization { get; set; }
        public string? Department { get; set; }
        public DateTime Date { get; set; }

        public DocumentDto(long? id, double value,DateTime date, string comment, string expenditure, string organization, string department) 
        {
            Id = id;
            Value = value;
            Date = date;
            Comment = comment;
            Expenditure = expenditure;
            Organization = organization;
            Department = department;
        }

        public DocumentDto( double value, DateTime date, string comment, string expenditure, string organization, string department)
        {
            Value = value;
            Date = date;
            Comment = comment;
            Expenditure = expenditure;
            Organization = organization;
            Department = department;
        }

        public DocumentDto(long? id, double value, DateTime date, string comment)
        {
            Id = id;
            Value = value;
            Date = date;
            Comment = comment;
        }

        public DocumentDto() { }

    }
}
