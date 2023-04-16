using CARTE.backend.Core.Domain.Interfaces;
using CARTE.backend.Core.Domain.Models;
using CARTE.backend.Core.Infrastructure.CustomExceptions;
using MediatR;

namespace CARTE.backend.Core.Infrastructure.Card.Commands.DeleteCard
{
    public class DeleteCardCommandHandler : IRequestHandler<DeleteCardCommand>
    {
        private readonly IBusinessCardContext _context;

        public DeleteCardCommandHandler(IBusinessCardContext context) =>
            _context = context;

        public async Task Handle(DeleteCardCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Cards
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
                throw new NotFoundException(nameof(BusinessCard), request.Id);

            _context.Cards.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
