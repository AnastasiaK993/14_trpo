using _12prak.Data;
using _12prak.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12prak
{
    public class GroupsService
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;
        public static ObservableCollection<Group> Groups { get; set; } = new ObservableCollection<Group>(); 

        public void GetAll()
        {
            var groups = _db.Group.ToList(); 
            Groups.Clear();
            foreach (var group in groups)
                Groups.Add(group);
        }

        public int Commit() => _db.SaveChanges();

        public GroupsService()
        {
            GetAll();
        }

        public void Add(Group group)
        {
            var _group = new Group
            {
                Title = group.Title,
            };
            _db.Add<Group>(_group);
            Commit();
            Groups.Add(_group); 
        }

        public void Remove(Group group)
        {
            _db.Remove<Group>(group);
            if (Commit() > 0)
                if (Groups.Contains(group)) 
                    Groups.Remove(group);
        }

        public void LoadRelation(Group group, string relation)
        {
            var entry = _db.Entry(group);
            var navigation = entry.Metadata.FindNavigation(relation)
                ?? throw new InvalidOperationException($"Navigation '{relation}' not found");
            if (navigation.IsCollection())
            {
                entry.Collection(relation).Load();
            }
            else
            {
                entry.Reference(relation).Load();
            }
        }
    }
}