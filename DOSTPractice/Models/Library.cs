using DOSTPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOSTPractice.Models
{
    public class Library
    {
        private readonly SemaphoreSlim _librarySemaphore;
        private readonly Random _random;
        public int MaxStudents { get; }
        public int MinStudents { get; }

        public Library(int maxStudents, int minStudents)
        {
            MaxStudents = maxStudents;
            MinStudents = minStudents;
            _librarySemaphore = new SemaphoreSlim(MaxStudents, MaxStudents);
            _random = new Random();
        }

        public void EnterLibrary(Student student)
        {
            Console.WriteLine($"Tələbə {student.Id} kitabxanaya daxil olur.");
            _librarySemaphore.Wait();
            ReadBook(student);
        }

        public void LeaveLibrary(Student student)
        {
            Console.WriteLine($"Tələbə {student.Id} kitabxanadan çıxdı.");
            _librarySemaphore.Release();
        }

        private void ReadBook(Student student)
        {
            int readingTime = _random.Next(5, 61);
            Console.WriteLine($"Tələbə {student.Id} kitab oxuyur. Müddət: {readingTime} saniyə");
            Thread.Sleep(readingTime * 1000); 
            LeaveLibrary(student);
        }
    }
}


