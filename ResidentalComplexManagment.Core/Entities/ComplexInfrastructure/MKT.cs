using Ardalis.GuardClauses;
using ResidentalComplexManagment.Core.Interface;

namespace ResidentalComplexManagment.Core.Entities.ComplexInfrastructure
{
    public class MKT : BaseEntity, IAggregateRoot
    {
        public string Name { get;private  set; }    
        public string IBAN { get; private set; }
        public string Address { get; private set; }
        public string PhoneNumber { get; private set; }
        private readonly List<Building> _buildings = new();
        public IReadOnlyCollection<Building> Buildings => _buildings.AsReadOnly();

        public MKT() {}

        public MKT(string name, string iBAN, string address, string phoneNumber)
        {
            Guard.Against.NullOrEmpty(name, nameof(name));
            Guard.Against.NullOrEmpty(iBAN, nameof(iBAN));
            Guard.Against.NullOrEmpty(address, nameof(address));
            Guard.Against.NullOrEmpty(phoneNumber, nameof(phoneNumber));


            Name = name;
            IBAN = iBAN;
            Address = address;
            PhoneNumber = phoneNumber;
        }

        public void UpdateDetails(string name, string iBAN, string address, string phoneNumber)
        {
            Guard.Against.NullOrEmpty(name, nameof(name));
            Guard.Against.NullOrEmpty(iBAN, nameof(iBAN));
            Guard.Against.NullOrEmpty(address, nameof(address));
            Guard.Against.NullOrEmpty(phoneNumber, nameof(phoneNumber));

            Name = name;
            IBAN = iBAN;
            Address = address;
            PhoneNumber = phoneNumber;
        }

     

        public void AddBuilding(Building building )
        {
            Guard.Against.Null(building, nameof(building));
            _buildings.Add(building);
        }
    }
}
