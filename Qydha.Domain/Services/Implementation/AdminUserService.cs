﻿namespace Qydha.Domain.Services.Implementation;

public class AdminUserService(IAdminUserRepo adminUserRepo, TokenManager tokenManager) : IAdminUserService
{
    private readonly IAdminUserRepo _adminUserRepo = adminUserRepo;
    private readonly TokenManager _tokenManager = tokenManager;

    public async Task<Result<Tuple<AdminUser, string>>> Login(string username, string password)
    {
        return (await _adminUserRepo.CheckUserCredentials(username, password))
        .OnSuccess((adminUser) =>
        {
            var jwtToken = _tokenManager.Generate(adminUser.GetClaims());
            return Result.Ok(new Tuple<AdminUser, string>(adminUser, jwtToken));
        });
    }

    public async Task<Result<AdminUser>> ChangePassword(Guid adminUserId, string oldPassword, string newPassword)
    {
        Result<AdminUser> checkingRes = await _adminUserRepo.CheckUserCredentials(adminUserId, oldPassword);
        return checkingRes
            .OnSuccessAsync<AdminUser>(async (adminUser) =>
                (await _adminUserRepo.UpdateUserPassword(adminUserId, BCrypt.Net.BCrypt.HashPassword(newPassword)))
                .MapTo(adminUser));
    }
}
