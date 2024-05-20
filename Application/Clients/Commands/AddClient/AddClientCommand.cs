using Domain;
using Domain.Entities;
using MediatR;

namespace Application.Clients.Commands.AddClient;

public class AddClientCommand : IRequest
{
    public string IdentificationNumber { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Email { get; set; }
}

public class AddClientCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddClientCommand>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Handle(AddClientCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.Repository<Client>().AddAsync(new Client
        {
            IdentificationNumber = request.IdentificationNumber,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email
        }, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}