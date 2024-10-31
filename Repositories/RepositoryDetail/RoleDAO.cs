using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using VieWingsAPI.Model;
using VieWingsAPI.Repositories;

namespace VieWingsAPI.Repository.RepositoryDetail
{
    public class RoleDAO : IRoleDAO
    {
        private readonly DataContext context; 
        public RoleDAO(DataContext _context)
        {
            this.context = _context;
        }

        // Method to retrieve all Roles
        public List<Role> GetRoles()
        {
            return  context.Role.ToList();
           
        }

    }
}
