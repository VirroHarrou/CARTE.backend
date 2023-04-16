using CARTE.backend.Core.Domain.Interfaces;
using CARTE.backend.Core.Domain.Models;
using CARTE.backend.Core.Infrastructure.CustomExceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CARTE.backend.Core.Infrastructure.Card.Commands.CreateCard
{
    public class CreateCardCommandHandler : IRequestHandler<CreateCardCommand, Guid>
    {
        private readonly IBusinessCardContext _context;
        private readonly IUserContext _userContext;

        public CreateCardCommandHandler(IBusinessCardContext context, IUserContext userContext)
        {
            _context = context;
            _userContext = userContext;
        }

        public async Task<Guid> Handle(CreateCardCommand request, CancellationToken cancellationToken)
        {
            var userEntity = await _userContext.Users
                .Where(x => x.Id == request.UserId)
                .FirstOrDefaultAsync(cancellationToken);

            if (userEntity == null)
                throw new NotFoundException(nameof(User), request.UserId);

            var card = new BusinessCard
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                Description = request.Description,
                ImageUrls = request.ImageUrls,
                Urls = request.Urls,
                Name = userEntity.Name,
                Surname = userEntity.Surname,
                Patronymic = request.Patronymic
            };

            await _context.Cards.AddAsync(card, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return card.Id;
        }
    }
}
