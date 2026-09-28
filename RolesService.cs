using _12prak.Data;
using _12prak.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12prak
{
    public class RolesService
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;
        public ObservableCollection<Role> Roles { get; set; } = new ObservableCollection<Role>(); 

        public void GetAll()
        {
            var roles = _db.Roles.ToList();
            Roles.Clear();
            foreach (var role in roles)
                Roles.Add(role);
        }

        public RolesService()
        {
            GetAll();
        }
    }
}