using CleanTeeth.Domain.Entities;

namespace SOLIDPrinciples.Application.Interfaces;

public interface IAppointmentRepository
{
    public void Save(Appointment appointment);    
}
