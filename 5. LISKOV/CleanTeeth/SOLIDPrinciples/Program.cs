using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.ValueObjects;
using SOLIDPrinciples.Application.Interfaces;
using SOLIDPrinciples.Application.Services;
using SOLIDPrinciples.Infrastructure.Notifications.Adapters;
using SOLIDPrinciples.Infrastructure.Notifications.Emails;
using SOLIDPrinciples.Infrastructure.Persistence;

namespace SOLIDPrinciples;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("╔═════════════════════════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║  PRINCIPIOS SOLID                                                                       ║");
        Console.WriteLine("║  PASO 5: LISKOV SUBSTITUTION PRINCIPLE (LSP) - PRINCIPIO DE SUSTITUCION DE LISKVOV      ║");
        Console.WriteLine("║  Sistema CleanTeeth - REFACTORIZADO                                                     ║");
        Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════════════════════╝\n");

        // Crear paciente
        Name patientName = new Name("John Doe");
        Email patientEmail = new Email("johndoe@email.com");
        PhoneNumber patientPhone = new PhoneNumber("+123456789");
        Address patientAddress = new Address("Av. Siempre Viva 742", "Springfield", "State", "12345");
        Patient patient = new Patient(PatientId.New(), patientName, patientEmail, patientPhone, patientAddress);

        // Crear dentista
        Name dentistName = new Name("Dr. Smith");
        Email dentistEmail = new Email("dentist@gmail.com");
        PhoneNumber dentistPhone = new PhoneNumber("0987654321");
        Dentist dentist = new Dentist(DentistId.New(), dentistName, dentistEmail, dentistPhone);

        // Crear consultorio
        Name officeName = new Name("Consultorio de limpieza dental");
        Address officeAddress = new Address("123 Dental St.", "Metropolis", "NY", "10001");
        PhoneNumber officePhone = new PhoneNumber("5551234567");
        DentalOffice dentalOffice = new DentalOffice(DentalOfficeId.New(), officeName, officeAddress, officePhone);

        // Crear intervalo de tiempo
        DateTime now = DateTime.UtcNow;
        TimeInterval timeInterval = new TimeInterval(
            now.AddHours(1),
            now.AddHours(2)
        );

        // Crear cita (Appointment)
        Appointment appointment = new Appointment(
            AppointmentId.New(),
            patient.Id,
            dentist.Id,
            dentalOffice.Id,
            timeInterval,
            now
        );

        // Crear el repositorio de citas y el servicio de notificaciones
        IAppointmentRepository repository = new DataBaseAppointmentRepository();

        //Nuevo
        List<INotifactionService> notifactions = new List<INotifactionService>();
        notifactions.Add(new EmailINotificationService(new SmptpEmailService()));
        notifactions.Add(new EmailINotificationService(new SendGridEmailNotificationService()));
        //notifactions.Add(new MessagingNotificationService(new WhatsAppMessagingService()));

        // Crear el servicio de citas  y realizar la/las notificaciones        
        AppointmentService appointmentService = new AppointmentService(repository, notifactions);

        // Agendar la cita y notificar al PACIENTE
        appointmentService.Schedule(appointment, patient);

        // EXTRA LSP: También podemos notificar al DENTISTA de la misma manera
        appointmentService.Schedule(appointment, dentist);

        Console.ReadLine();
    }
}