using CARTE.backend.Core.Domain.Interfaces;
using CARTE.backend.Core.Domain.Models;
using CARTE.backend.Core.Infrastructure.CustomExceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CARTE.backend.Core.Infrastructure.Card.Commands.UpdateCard
{
    public class UpdateCardCommandHandler : IRequestHandler<UpdateCardCommand>
    {
        private readonly IBusinessCardContext _context;

        public UpdateCardCommandHandler(IBusinessCardContext context) =>
            _context = context;

        public async Task Handle(UpdateCardCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Cards
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(BusinessCard), request.Id);
            }

            entity.Description = request.Description;
            entity.ImageUrls = request.ImageUrls;
            entity.Urls = request.Urls;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
