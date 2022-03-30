using Ardalis.GuardClauses;
using ResidentalComplexManagment.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Core.Entities.ComplexInfrastructure
{
    public class Building : BaseEntity, IAggregateRoot
    {
        public int Number { get;private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string MKTId { get; private set; }
        public MKT MKT { get; private set; }
        public readonly List<Appartment> _appartments = new();
        public IReadOnlyCollection<Appartment> Appartments => _appartments.AsReadOnly();

        public Building() { }
        

        public Building(int number, string name,string address,string mKTId)
        {
            Guard.Against.NegativeOrZero(number, nameof(number));
            Guard.Against.NullOrEmpty(name, nameof(name));
            Guard.Against.NullOrEmpty(mKTId, nameof(mKTId));

            Number = number;
            Name = name;
            Address = address;
            MKTId = mKTId;
        }

        public void UpdateDetails(int number, string name, string address)
        {
            Guard.Against.NegativeOrZero(number, nameof(number));
            Guard.Against.NullOrEmpty(name, nameof(name));

            Number = number;
            Name = name;
            Address = address;
        }

        public void AddAppartment(Appartment appartment)
        {
            Guard.Against.Null(appartment, nameof(appartment));
            _appartments.Add(appartment);
        }

    }
}
