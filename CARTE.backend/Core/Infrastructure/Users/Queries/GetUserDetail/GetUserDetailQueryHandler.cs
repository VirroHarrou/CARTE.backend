using AutoMapper;
using CARTE.backend.Core.Domain.Interfaces;
using CARTE.backend.Core.Domain.Models;
using CARTE.backend.Core.Infrastructure.CustomExceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CARTE.backend.Core.Infrastructure.Users.Queries.GetUserDetail
{
    public class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQuery, UserVm>
    {
        private readonly IUserContext _context;
        private readonly IMapper _mapper;

        public GetUserDetailQueryHandler(IUserContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserVm> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users
                .Where(x => x.Id == request.UserId)
                .FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.UserId);
            }

            return _mapper.Map<UserVm>(entity);
        }
    }
}
