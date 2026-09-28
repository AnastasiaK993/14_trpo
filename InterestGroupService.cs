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
    public class InterestGroupService
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;
        public ObservableCollection<InterestGroup> InterestGroups { get; set; } = new ObservableCollection<InterestGroup>();

        public InterestGroupService()
        {
            GetAll();
        }

        public void GetAll()
        {
            var groups = _db.InterestGroups.ToList();
            InterestGroups.Clear();
            foreach (var group in groups)
                InterestGroups.Add(group);
        }

        public int Commit() => _db.SaveChanges();

        public void Add(InterestGroup group)
        {
            var _group = new InterestGroup
            {
                Title = group.Title,
                Description = group.Description,
            };
            _db.Add<InterestGroup>(_group);
            Commit();
            InterestGroups.Add(_group);
        }

        public void Remove(InterestGroup group)
        {
            _db.Remove<InterestGroup>(group);
            if (Commit() > 0)
                if (InterestGroups.Contains(group))
                    InterestGroups.Remove(group);
        }
    }
}