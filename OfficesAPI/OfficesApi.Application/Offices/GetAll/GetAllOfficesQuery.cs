using MediatR;

namespace OfficesApi.Application.Offices.GetAll;

public record GetAllOfficesQuery() : IRequest<IEnumerable<OfficeResponse>>;