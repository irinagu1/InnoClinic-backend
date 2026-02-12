using MediatR;

namespace OfficesApi.Application.Offices.Delete;

public sealed record class DeleteOfficeByIdCommand(string id)
    : IRequest;
