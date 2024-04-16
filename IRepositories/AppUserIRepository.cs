using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepositories
{
    public interface AppUserIRepository
    {
        /// <summary>
        /// Create a new AppUser.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task CreateAppuserAsync(AppUser user);


        /// <summary>
        /// Delete an AppUser.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAppuserAsync(Guid id);


        /// <summary>
        /// Update an AppUser.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The AppUser updated.</returns>
        Task<AppUser> UpdateAppuserAsync(Guid id);

    }
}
