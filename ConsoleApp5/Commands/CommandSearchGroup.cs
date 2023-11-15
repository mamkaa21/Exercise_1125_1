using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CommandSearchGroup : UserCommand
{
    private GroupDB groupDB;

    public CommandSearchGroup(GroupDB groupDB)
    {
        this.groupDB = groupDB;
    }

    public override void Execute()
    {
        Console.WriteLine("Поиск группы...");
        List<Group> groups = groupDB.Search(Console.ReadLine());
        for (int i = 0; i < groups.Count; i++)
            Console.WriteLine($"{i + 1}).{groups[i].Nomer} {groups[i].UID}");
    }
}
