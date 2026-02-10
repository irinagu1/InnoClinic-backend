using MediatR;
using OfficesApi.Domain.Entities;

namespace OfficesApi.Application.Queries.GetOfficesQuery;

public record GetOfficesQuery() : IRequest<IEnumerable<Office>>;