using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CommandEditStudent : UserCommand
{
    private StudentDB studentDB;

    public CommandEditStudent(StudentDB studentDB)
    {
        this.studentDB = studentDB;
    }

    public override void Execute()
    {
        Console.WriteLine("Поиск студента...");
        List<Student> students = studentDB.Search("");
        for (int i = 0; i < students.Count; i++)
        { Console.WriteLine($"{i + 1}). {students[i].LastName} {students[i].FirstName} {students[i].UID}");

            Console.WriteLine("Укажите порядковый номер...");
            int.TryParse(Console.ReadLine(), out int e);
            if (students.Count > e - 1)
            {
                Console.WriteLine("Измените имя...");
                students[i].FirstName = Console.ReadLine();
                Console.WriteLine("Измените фамилию...");
                students[i].LastName = Console.ReadLine();
               if  (studentDB.Update(students[i]))
                    Console.WriteLine("Отредактивано");
                else
                    Console.WriteLine("Возникли необъяснимые ошибки! Информация потеряна.");
            }
        }
      

    }
}
