using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12prak
{
    public class Student : ObservableObject
    {
        private Passport _passport;
        public Passport Passport
        {
            get => _passport;
            set => SetProperty(ref _passport, value);
        }

        private int _groupId;
        public int GroupId
        {
            get => _groupId;
            set => SetProperty(ref _groupId, value);
        }

        private Group _group;
        public Group Group
        {
            get => _group;
            set => SetProperty(ref _group, value);
        }

        private int _id;
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private string _Login;
        public string Login
        {
            get => _Login;
            set => SetProperty(ref _Login, value);
        }

        private string _Name;
        public string Name
        {
            get => _Name;
            set => SetProperty(ref _Name, value);
        }

        private string _Email;
        public string Email
        {
            get => _Email;
            set => SetProperty(ref _Email, value);
        }
        private string _Password;
        public string Password
        {
            get => _Password;
            set => SetProperty(ref _Password, value);
        }

        private DateTime _CreatedAt;
        public DateTime CreatedAt
        {
            get => _CreatedAt;
            set => SetProperty(ref _CreatedAt, value);
        }

        private int _roleId;
        public int RoleId
        {
            get => _roleId;
            set => SetProperty(ref _roleId, value);
        }

        private Role _role;
        public Role Role
        {
            get => _role;
            set => SetProperty(ref _role, value);
        }

        private UserProfile _userProfile;
        public UserProfile UserProfile
        {
            get => _userProfile;
            set => SetProperty(ref _userProfile, value);
        }
        private ObservableCollection<UserInterestGroup> _userInterestGroups;
        public ObservableCollection<UserInterestGroup> UserInterestGroups
        {
            get => _userInterestGroups;
            set => SetProperty(ref _userInterestGroups, value);
        }
    }

}