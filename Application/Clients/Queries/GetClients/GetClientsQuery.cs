using Domain;
using Domain.Entities;
using MediatR;

namespace Application.Clients.Queries.GetClients;

public class GetClientsQuery : IRequest<IEnumerable<ClientModel>>
{
    
}

public class GetClientsQueryHandler(IGenericRepository<Client> clientRepository)
    : IRequestHandler<GetClientsQuery, IEnumerable<ClientModel>>
{
    private readonly IGenericRepository<Client> _clientRepository = clientRepository;

    public  async Task<IEnumerable<ClientModel>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
    {
        var clients= await _clientRepository.GetAllAsync(null, null, cancellationToken);

        return clients.Select(x => new ClientModel
        {
            IdentificationNumber = x.IdentificationNumber,
            FirstName = x.FirstName,
            LastName = x.LastName,
            Email = x.Email
        });
    }
}