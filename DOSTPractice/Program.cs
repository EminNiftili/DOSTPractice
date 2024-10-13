using DOSTPractice.Managers;
using DOSTPractice.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace KutubxanaSimulyasiya
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Maksimum tələbə sayını daxil edin:");
            int maxStudents = int.Parse(Console.ReadLine());

            Console.WriteLine("Minimum tələbə sayını daxil edin:");
            int minStudents = int.Parse(Console.ReadLine());

            Console.WriteLine("Ümumi tələbə sayını daxil edin:");
            int totalStudents = int.Parse(Console.ReadLine());

            if (minStudents > maxStudents)
            {
                Console.WriteLine("Minimum tələbə sayı maksimumdan çox ola bilməz!");
                return;
            }

            var library = new Library(maxStudents, minStudents);
            var manager = new LibraryManager(library);

            manager.StartLibrarySimulation(totalStudents);
        }
    }
}
