using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoApp.Application.Security;
using TodoApp.Data;
using TodoApp.Utils;

namespace TodoApp.Application.Features.Users.Login
{

    internal class LoginUserHandler : IRequestHandler<LoginUserRequest, AuthUserResponse>
    {
        private readonly AppDbContext _dbContext;
        private readonly JwtProvider _jwtProvider;
        public LoginUserHandler(AppDbContext dbContext, Hashing hashingService,
            JwtProvider jwtProvider)
        {
            _dbContext = dbContext;
            _jwtProvider = jwtProvider;
        }
        public async Task<AuthUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _dbContext.users
                .FirstOrDefaultAsync(u => u.Username == request.Username);
                
                if (user == null || !Hashing.VerifyPassword(request.Password, user.Password))
                {
                    return new AuthUserResponse
                    {
                        Status = 401,
                        Message = StatusMessages.User.Unauthorized,
                        TrackId = Guid.NewGuid(),
                    };
                }

                var token = _jwtProvider.GenerateToken(user.Id.ToString(), user.Username);

                return new AuthUserResponse
                {
                    Status = 200,
                    Message = StatusMessages.User.LoggedIn,
                    TrackId = Guid.NewGuid(),
                    Token = token
                };

            }
            catch (Exception ex)
            {
                return new AuthUserResponse
                {
                    Status = 500,
                    Message = $"Internal server error: {ex.Message}",
                    TrackId = Guid.NewGuid()
                };
            }
        }
    }
}
