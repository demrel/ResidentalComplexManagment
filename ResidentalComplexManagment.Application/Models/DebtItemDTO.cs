using ResidentalComplexManagment.Domain.Enums;

namespace ResidentalComplexManagment.Application.Models
{
    public class DebtItemDTO
    {
        public string Id { get;  set; }
        public string Name { get;  set; }
        public DateOnly? From { get;  set; }
        public DateOnly? To { get;  set; }
        public bool IsComplusory { get;  set; }
        public string  Type { get;  set; }
        public List<CalculationValueDTO> CalculationValueDTO { get; set; }
        public DebtItemDTO()
        {
            CalculationValueDTO = new();
        }
    }

    public class CalculationValueDTO
    {
        public int Id { get; set; }
        public decimal From { get;  set; }
        public decimal To { get;  set; }
        public decimal Value { get;  set; }
        public CalculationMethod Method { get; set; }
    }
}
