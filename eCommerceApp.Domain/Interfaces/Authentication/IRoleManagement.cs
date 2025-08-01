﻿using eCommerceApp.Domain.Entities.Identity;

namespace eCommerceApp.Domain.Interfaces.Authentication
{
    public interface IRoleManagement
    {
        Task<string?> GetUserRole(String userEmail);
        Task<bool> AddUserToRole(AppUser user, string roleName);
    }
}
