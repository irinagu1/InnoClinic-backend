using MediatR;
using OfficesApi.Application.Offices.GetAll;

namespace OfficesApi.Application.Offices.Create;

public sealed record class CreateOfficeCommand(OfficeCreate OfficeCreateDto) : IRequest<OfficeResponse>;
