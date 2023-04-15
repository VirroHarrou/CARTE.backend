using Domain.Interfaces;
using Domain.Models;
using Infrastructure.CustomExceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Card.Commands.UpdateCard
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

            if(entity == null || entity.UserId != request.UserId)
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
