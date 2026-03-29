using CleanTeeth.Domain.Enums;
using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Domain.Entities;

public class Appointment : Entity<AppointmentId>
{
    public PatientId PatientId { get; private set; }
    public DentistId DentistId { get; private set; }
    public DentalOfficeId DentalOfficeId { get; private set; }
    public AppointmentStatus Status { get; private set; }
    public TimeInterval TimeInterval { get; private set; }
    public Patient? Patient { get; private set; }
    public Dentist? Dentist { get; private set; }
    public DentalOffice? DentalOffice { get; private set; }

    private Appointment() { } // Para ORMs

    public Appointment(
        AppointmentId id,
        PatientId patientId,
        DentistId dentistId,
        DentalOfficeId dentalOfficeId,
        TimeInterval timeInterval,
        DateTime currentDate
    )
    {
        if (id is null) throw new BusinessRuleException("El ID es requerido");
        if (patientId is null) throw new BusinessRuleException("El paciente es requerido");
        if (dentistId is null) throw new BusinessRuleException("El dentista es requerido");
        if (dentalOfficeId is null) throw new BusinessRuleException("El consultorio es requerido");

        if (timeInterval.Start < currentDate)
        {
            throw new BusinessRuleException(
                "La fecha de inicio no puede ser anterior a la fecha actual"
            );
        }

        Id = id;
        PatientId = patientId;
        DentistId = dentistId;
        DentalOfficeId = dentalOfficeId;
        TimeInterval = timeInterval;
        Status = AppointmentStatus.Scheduled;
    }

    public void Cancel()
    {
        if (Status != AppointmentStatus.Scheduled)
        {
            throw new BusinessRuleException($"Solo se puede cancelar una cita programada");
        }

        Status = AppointmentStatus.Cancelled;
    }

    public void Complete()
    {
        if (Status != AppointmentStatus.Scheduled)
        {
            throw new BusinessRuleException($"Solo puede ser completada una cita programada ");
        }

        Status = AppointmentStatus.Completed;
    }
}
