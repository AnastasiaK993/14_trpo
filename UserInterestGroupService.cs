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
    public class UserInterestGroupService
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;

        public void Add(UserInterestGroup userInterestGroup)
        {
            var _uig = new UserInterestGroup
            {
                UserId = userInterestGroup.UserId,
                User = userInterestGroup.User,
                InterestGroupId = userInterestGroup.InterestGroupId,
                InterestGroup = userInterestGroup.InterestGroup,
                JoinedAt = userInterestGroup.JoinedAt,
                IsModerator = userInterestGroup.IsModerator,
            };
            _db.Add<UserInterestGroup>(_uig);
            _db.SaveChanges();
        }

        public List<UserInterestGroup> GetGroupMembers(int interestGroupId)
        {
            return _db.UserInterestGroups
                .Include(uig => uig.User)
                .ThenInclude(s => s.UserProfile)
                .Where(uig => uig.InterestGroupId == interestGroupId)
                .ToList();
        }

        public List<UserInterestGroup> GetUserGroups(int userId)
        {
            return _db.UserInterestGroups
                .Include(uig => uig.InterestGroup)
                .Where(uig => uig.UserId == userId)
                .ToList();
        }

        public void Remove(UserInterestGroup uig)
        {
            _db.Remove<UserInterestGroup>(uig);
            _db.SaveChanges();
        }

        public int Commit() => _db.SaveChanges();
    }
}