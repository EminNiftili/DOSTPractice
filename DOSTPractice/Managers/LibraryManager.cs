using DOSTPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOSTPractice.Managers
{
    public class LibraryManager
    {
        private readonly Library _library;
        private readonly List<Thread> _studentThreads;

        public LibraryManager(Library library)
        {
            _library = library;
            _studentThreads = new List<Thread>();
        }

        public void StartLibrarySimulation(int totalStudents)
        {
            for (int i = 1; i <= totalStudents; i++)
            {
                int studentId = i;
                var student = new Student(studentId);

                Thread studentThread = new Thread(() => _library.EnterLibrary(student));
                _studentThreads.Add(studentThread);
                studentThread.Start();

                // Girişlər arasında fasilə
                Thread.Sleep(500);
            }

            // Bütün tələbələrin bitməsini gözləyir
            foreach (var thread in _studentThreads)
            {
                thread.Join();
            }

            Console.WriteLine("Bütün tələbələr kitabxanadan çıxıblar.");
        }
    }
}
