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
    public class StudentsService
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;
        public ObservableCollection<Student> Students { get; set; } = new ObservableCollection<Student>();

        public StudentsService()
        {
            GetAll();
        }

        public void Add(Student student)
        {
            var _student = new Student
            {
                Login = student.Login,
                Name = student.Name,
                Email = student.Email,
                Password = student.Password,
                CreatedAt = student.CreatedAt,
                Passport = student.Passport,
                GroupId = student.GroupId,
                Group = student.Group,
                RoleId = student.RoleId,
                Role = student.Role,
                UserProfile = student.UserProfile  
            };
            _db.Add<Student>(_student);
            Commit();
            Students.Add(_student);
        }

        public int Commit() => _db.SaveChanges();

        public void GetAll()
        {
            var students = _db.Students
                .Include(s => s.Passport)
                .Include(s => s.Group)
                .Include(s => s.Role)
                .Include(s => s.UserProfile)  
                .ToList();

            Students.Clear();
            foreach (var student in students)
            {
                Students.Add(student);
            }
        }

        public void Remove(Student student)
        {
            _db.Remove<Student>(student);
            if (Commit() > 0)
            {
                if (Students.Contains(student))
                    Students.Remove(student);
            }
        }
    }
}