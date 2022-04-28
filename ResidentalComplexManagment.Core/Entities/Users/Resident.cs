using Ardalis.GuardClauses;
using ResidentalComplexManagment.Core.Entities.Accountment;
using ResidentalComplexManagment.Core.Entities.ComplexInfrastructure;
using ResidentalComplexManagment.Core.Entities.ResidentNotifications;
using ResidentalComplexManagment.Core.Interface;
using ResidentalComplexManagment.Domain.Entities.Accountment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Core.Entities.Users
{
    public class Resident : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string FullName => Name + " " + Surname;
        public string FIN { get; private set; }
        public string PhoneNumber { get; private set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime? Birthday { get; private set; }
        public bool IsCurrentResident { get; private set; }
        public string AppartmentId { get; private set; }
        public Appartment Appartment { get; private set; }
        public virtual List<Nottification> Nottifications { get; private set; }


        private readonly List<ResidentDebtItem> _residentDebtItems = new();
        public IReadOnlyCollection<ResidentDebtItem> ResidentDebtItems => _residentDebtItems.AsReadOnly();

        public Resident() { }


        public Resident(string name, string surname, string fIN, string phoneNumber, DateTime? birthday)
        {
            Guard.Against.NullOrEmpty(name, nameof(name));
            Guard.Against.NullOrEmpty(surname, nameof(surname));
            Guard.Against.NullOrEmpty(fIN, nameof(fIN));
            Guard.Against.NullOrEmpty(phoneNumber, nameof(phoneNumber));


            Name = name;
            Surname = surname;
            FIN = fIN;
            PhoneNumber = phoneNumber;
            Birthday = birthday;
            IsCurrentResident = true;
        }
        public void UpdateDetails(string name, string surname, string fIN, string phoneNumber, DateTime? birthday)
        {
            Guard.Against.NullOrEmpty(name, nameof(name));
            Guard.Against.NullOrEmpty(surname, nameof(surname));
            Guard.Against.NullOrEmpty(fIN, nameof(fIN));
            Guard.Against.NullOrEmpty(phoneNumber, nameof(phoneNumber));

            Name = name;
            Surname = surname;
            FIN = fIN;
            PhoneNumber = phoneNumber;
            Birthday = birthday;
        }

        public void AddDebtItem(string paymentItemId, decimal discountPercent)
        {
            Guard.Against.NullOrEmpty(paymentItemId, nameof(paymentItemId));
            Guard.Against.Negative(discountPercent, nameof(discountPercent));

            _residentDebtItems.Add(new ResidentDebtItem(paymentItemId, discountPercent));
        }

        public void EditDebtItem(decimal discountPercent, int id)
        {
            Guard.Against.NegativeOrZero(id, nameof(id));
            Guard.Against.Negative(discountPercent, nameof(discountPercent));
            var debtitem = ResidentDebtItems.FirstOrDefault(c => c.Id == id);
            if (debtitem == null) return;
            debtitem.Edit(discountPercent);
        }

        public void RemoveDebtItem(int id)
        {
            Guard.Against.NegativeOrZero(id, nameof(id));
           // _residentDebtItems.Remove(_residentDebtItems.FirstOrDefault(c => c.PaymentItemId == paymentItemId));
            var item = _residentDebtItems.FirstOrDefault(c => c.Id == id);
            _residentDebtItems.Remove(item);
        }


        public void ChangeRessidentStatus()
        {
            IsCurrentResident = false;
        }


    }
}
