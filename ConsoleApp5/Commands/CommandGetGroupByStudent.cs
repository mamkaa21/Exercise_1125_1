using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CommandGetGroupByStudent : UserCommand
{
    private StudentGroupDB studentGroupDB;

    public CommandGetGroupByStudent(StudentGroupDB studentGroupDB)
    {
        this.studentGroupDB = studentGroupDB;
    }

    public override void Execute()
    {
        Console.WriteLine("Ввведите uid студента для поиска группы...");
        Group groups = studentGroupDB.GetGroupByStudent(Console.ReadLine());
            Console.WriteLine($"{groups.Nomer} {groups.UID}");
    }
}