using Ardalis.GuardClauses;
using ResidentalComplexManagment.Core.Entities.Users;
using ResidentalComplexManagment.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Core.Entities.ComplexInfrastructure;

public class Appartment :BaseEntity, IAggregateRoot
{
    
    public string Name => $"Mənzil N: {DoorNumber} Kvm: {Area}";
    public int DoorNumber { get;private set; }
    public decimal Area { get; private set; }
    public string BuildingId { get; private set; }
    public Building Building { get; private set; }

    private readonly List<Resident> _residents = new();
    public IReadOnlyCollection<Resident> Residents => _residents.AsReadOnly();


    public Appartment() { }

    public Appartment(int doorNumber, decimal area, string buildingId)
    {
        Guard.Against.NegativeOrZero(doorNumber, nameof(doorNumber));
        Guard.Against.NegativeOrZero(area, nameof(area));
        Guard.Against.NullOrEmpty(buildingId, nameof(buildingId));

        DoorNumber = doorNumber;
        Area = area;
        BuildingId = buildingId;
    }

    public void UpdateDetails(int doorNumber, decimal area)
    {
        Guard.Against.NegativeOrZero(doorNumber, nameof(doorNumber));
        Guard.Against.NegativeOrZero(area, nameof(area));
        DoorNumber = doorNumber;
        Area = area;
    }

    public void AddNewResident(Resident resident)
    {
        Guard.Against.Null(resident, nameof(resident));
        var currentResident = _residents.FirstOrDefault(r => r.IsCurrentResident);
        currentResident?.ChangeRessidentStatus();
        _residents.Add(resident);
    }
}
