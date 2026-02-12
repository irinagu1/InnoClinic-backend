using MediatR;

namespace OfficesApi.Application.Offices.PartiallyUpdate;

public sealed record class PartiallyUpdateOfficeCommand
    (string id, Dictionary<string,object> updates) : IRequest;
