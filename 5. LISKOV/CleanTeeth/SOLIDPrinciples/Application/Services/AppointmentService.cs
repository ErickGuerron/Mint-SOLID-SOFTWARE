using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.ValueObjects;
using SOLIDPrinciples.Application.Interfaces;
using SOLIDPrinciples.Infrastructure.Notifications;
using SOLIDPrinciples.Infrastructure.Notifications.Emails;
using SOLIDPrinciples.Infrastructure.Notifications.Messaging;
using SOLIDPrinciples.Infrastructure.Notifications.Sms;
using SOLIDPrinciples.Infrastructure.Persistence;
using System.Net.NetworkInformation;

namespace SOLIDPrinciples.Application.Services;

public class AppointmentService
{
    private List<Appointment> _appointments = new List<Appointment>();

    //private readonly AppointmentRepository _repository; //MODIFACADO   
    private readonly IAppointmentRepository _repository; //NUEVO   
    //private readonly IEmailService _emailService;
    //private readonly ISmsService _msService;  
    //private readonly IMessagingService _messagingService;
    private readonly IEnumerable<INotifactionService> _notifications;

    //MODIFICADO
    // public AppointmentService(
    //    AppointmentRepository repository,
    //    IEmailService emailService, ISmsService msService
    //)
    // {
    //     _repository = repository;
    //     _emailService = emailService;
    //     _msService = msService;
    // }

    //   public AppointmentService(
    //    IAppointmentRepository repository,
    //    IEmailService emailService, ISmsService msService, IMessagingService messagingService
    //)
    //   {
    //       _repository = repository;
    //       _emailService = emailService;
    //       _msService = msService;
    //       _messagingService = messagingService;
    //   }

    public AppointmentService(IAppointmentRepository repository, IEnumerable<INotifactionService> notifactions)
    {
        _repository = repository;
        _notifications = notifactions;
    }
    //public void Schedule(Appointment appointment, Email patientEmail, Patient patient)
    //{
    //    Console.WriteLine("Programar cita...");

    //    // VALIDACIÓN REGLA DE NEGOCIO: Verificar que el dentista no tenga otra cita en el mismo horario
    //    if (
    //        _appointments.Any(a =>
    //            a.DentistId == appointment.DentistId
    //            && a.TimeInterval.Start == appointment.TimeInterval.Start
    //        )
    //    )
    //    {
    //        Console.WriteLine("El dentista está ocupadO en ese momento.");
    //        return;
    //    }

    //    // AGREGAR LA CITA AL LISTADO DE CITAS
    //    _appointments.Add(appointment);

    //    // GUARDAR EN ARCHIVO
    //    _repository.Save(appointment);

    //    // ENVIAR CORREO ELECTRÓNICO AL PACIENTE        
    //    _emailService.Send(patientEmail);
    //    _msService.Send(patient);

    //    //ENVIAR EL MENSAJE POR WHATSAPP
    //    _messagingService.Send(patient);

    //    // VISUALIZAR MENSAJE DE CONFIRMACIÓN
    //    Console.WriteLine("Cita programada con éxito.");
    //}

    public void Schedule<TId>(Appointment appointment, Person<TId> person) where TId : notnull
    {
        Console.WriteLine("Programar cita...");

        // VALIDACIÓN REGLA DE NEGOCIO: Verificar que el dentista no tenga otra cita en el mismo horario
        if (
            _appointments.Any(a =>
                a.DentistId == appointment.DentistId
                && a.TimeInterval.Start == appointment.TimeInterval.Start
            )
        )
        {
            Console.WriteLine("El dentista está ocupadO en ese momento.");
            return;
        }

        // AGREGAR LA CITA AL LISTADO DE CITAS
        _appointments.Add(appointment);

        // GUARDAR EN ARCHIVO
        _repository.Save(appointment);

        //Enviar LA/LAS Notificaciones 
        foreach (var notification in _notifications)
        {
            notification.Send(person, "Cita programada");
        }

        // VISUALIZAR MENSAJE DE CONFIRMACIÓN
        Console.WriteLine("Cita programada con éxito.");
    }
}
