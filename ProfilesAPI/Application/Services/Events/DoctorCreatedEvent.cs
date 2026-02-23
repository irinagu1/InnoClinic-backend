using Shared.Messaging;

namespace Application.Events;

public record DoctorCreatedEvent(string doctorId, string email) : IntegrationEvent;
