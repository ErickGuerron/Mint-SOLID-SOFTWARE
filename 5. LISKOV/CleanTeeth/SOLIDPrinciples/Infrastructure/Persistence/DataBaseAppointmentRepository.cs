using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.ValueObjects;
using SOLIDPrinciples.Application.Interfaces;

namespace SOLIDPrinciples.Infrastructure.Persistence;

public class DataBaseAppointmentRepository : IAppointmentRepository
{
    public void Save(Appointment appointment)
    {
        // Logica de guardado...
        Console.WriteLine($"Cita con código: {appointment.Id} guardada en la base de datos");
    }
}
