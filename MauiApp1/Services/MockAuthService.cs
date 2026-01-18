using MauiApp1.Models;

namespace MauiApp1.Services
{
    public class MockAuthService : IAuthService
    {
        private Student _currentStudent;

        public Student Login(string studentNumber)
        {
            _currentStudent = new Student
            {
                Id = Guid.NewGuid(),
                FullName = "Demo Student",
                StudentNumber = studentNumber,
                Faculty = "Faculty of Engineering"
            };
            return _currentStudent;
        }

        public void Logout()
        {
            _currentStudent = null;
        }

        public Student GetCurrentStudent()
        {
            return _currentStudent;
        }
    }
}
