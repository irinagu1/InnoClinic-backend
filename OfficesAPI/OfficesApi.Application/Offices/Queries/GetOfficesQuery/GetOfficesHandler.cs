using System.Runtime.CompilerServices;
using MediatR;
using OfficesApi.Domain.Entities;

namespace OfficesApi.Application.Queries.GetOfficesQuery;

public class GetOfficesHandler : IRequestHandler<GetOfficesQuery, IEnumerable<Office>>
{
    public GetOfficesHandler()
    {
        
    }

    public async Task<IEnumerable<Office>> Handle
        (GetOfficesQuery request, CancellationToken cancellationToken)
    {
        var list = new List<Office>
        {
            new Office(){Id=1, Name="Office1"},
            new Office(){Id=2, Name="Office2"},
        };
        await Task.Delay(100);

        return list;
    }
}