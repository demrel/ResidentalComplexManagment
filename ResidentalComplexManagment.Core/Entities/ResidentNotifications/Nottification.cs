using Ardalis.GuardClauses;
using ResidentalComplexManagment.Core.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Core.Entities.ResidentNotifications
{
    public class Nottification : BaseEntity
    {
        public string Name { get;private set; }
        public string Text { get; private set; }
        public string Sender { get; private set; }

        private readonly List<Resident> _recipients = new();
        public IReadOnlyCollection<Resident> Recipients => _recipients.AsReadOnly();

        public bool IsAutomatic { get; private set; }
        public DateTime? AutomaticSendingPeriod { get; private set; }

        public Nottification(string name, string text, string sender)
        {
            Guard.Against.NullOrEmpty(name, nameof(name));
            Guard.Against.NullOrEmpty(text, nameof(text));
            Guard.Against.NullOrEmpty(sender, nameof(sender));

            Name = name;
            Text = text;
            Sender = sender;
            IsAutomatic = false;
        }

        public void MakeAutomatic(DateTime time)
        {
            Guard.Against.OutOfSQLDateRange(time, nameof(time));
         
            IsAutomatic = true;
            AutomaticSendingPeriod = time;
        }

        public void AddRecipient(Resident recipient)
        {
            Guard.Against.Null(recipient, nameof(recipient));
            _recipients.Add(recipient);
        }
    }
}
