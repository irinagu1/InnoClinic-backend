using MediatR;
using OfficesApi.Application.Offices.GetAll;

namespace OfficesApi.Application.Offices.GetById;

public record GetOfficeByIdQuery(string id) : IRequest<OfficeResponse>;