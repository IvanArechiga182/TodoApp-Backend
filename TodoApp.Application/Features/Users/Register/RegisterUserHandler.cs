using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoApp.Application.Security;
using TodoApp.Data;
using TodoApp.Domain;
using TodoApp.Utils;

namespace TodoApp.Application.Features.Users.Register
{
    internal class RegisterUserHandler : IRequestHandler<RegisterUserRequest, AuthUserResponse>
    {
        private readonly AppDbContext _dbContext;
        private readonly JwtProvider _jwtProvider;
        public RegisterUserHandler(AppDbContext dbContext,
            Hashing hashingService, JwtProvider jwtProvider)
        {
            _dbContext = dbContext;
            _jwtProvider = jwtProvider;
        }
        public async Task<AuthUserResponse> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var existsUser = await _dbContext.users.AnyAsync(
                    u => u.Username == request.UserName || u.Email == request.Email, cancellationToken);

                if(existsUser)
                {
                    return new AuthUserResponse
                    {
                        Status = 409,
                        Message = StatusMessages.User.UserExists,
                        TrackId = Guid.NewGuid(),
                    };
                }

                var hashedPassword = Hashing.HashPassword(request.Password);
                var userEntity = new UserEntity
                {
                    Username = request.UserName,
                    Email = request.Email,
                    Password = hashedPassword,
                    CreatedAt = DateTime.UtcNow,
                    IsActiveUser = true,
                };

                var token = _jwtProvider.GenerateToken(userEntity.Id.ToString(), userEntity.Username);

                await _dbContext.users.AddAsync(userEntity, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return new AuthUserResponse 
                {
                    Status = 201,
                    Message = StatusMessages.User.SuccessfullyRegistered,
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
