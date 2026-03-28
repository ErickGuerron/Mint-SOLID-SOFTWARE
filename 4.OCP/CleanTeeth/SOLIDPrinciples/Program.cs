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
        Console.WriteLine("║  PASO 4: OPEN/CLOSED PRINCIPLE (OCP) - PRINCIPIO ABIERTO/CERRADO                        ║");
        Console.WriteLine("║  Sistema CleanTeeth - REFACTORIZADO                                                     ║");
        Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════════════════════╝\n");

        // Crear Email del paciente
        Email patientEmail = new Email("johndoe@email.com");

        // Crear paciente
        Patient patient = new Patient("John Doe", patientEmail);

        // Crear Email del dentista
        Email dentistEmail = new Email("dentist@gmail.com");

        // Crear dentista
        Dentist dentist = new Dentist("Dr. Smith", dentistEmail);

        // Crear consultorio
        DentalOffice dentalOffice = new DentalOffice("Consultorio de limpieza dental");

        // Crear intervalo de tiempo
        TimeInterval timeInterval = new TimeInterval(
            DateTime.UtcNow.AddHours(1),
            DateTime.UtcNow.AddHours(2)
        );

        // Crear cita (Appointment)
        Appointment appointment = new Appointment(
            patient.Id,
            dentist.Id,
            dentalOffice.Id,
            timeInterval
        );

        // Crear el repositorio de citas y el servicio de notificaciones
        //var repository = new AppointmentRepository();
        //IAppointmentRepository repository = new FileAppointmentRepository();
        IAppointmentRepository repository = new DataBaseAppointmentRepository();

        //SendGridEmailNotificationService emailService =
        //    new SendGridEmailNotificationService();

        //TwilioSmsService smsService = new TwilioSmsService();

        //WhatsAppMessagingService messagingService = new WhatsAppMessagingService();

        //Nuevo
        List<INotifactionService> notifactions = new List<INotifactionService>();
        notifactions.Add(new EmailINotificationService(new SmptpEmailService()));
        notifactions.Add(new EmailINotificationService(new SendGridEmailNotificationService()));

        // Crear el servicio de citas  y realizar la/las notificaciones        
        AppointmentService appointmentService = new AppointmentService(repository,
           notifactions);

        // Agendar la cita        
        //appointmentService.Schedule(appointment, patientEmail, patient);
        appointmentService.Schedule(appointment, patient);

        Console.ReadLine();
    }
}