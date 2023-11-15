using System.Xml.Linq;

class Program
{
    public static void Main()
    { 
        CommandManager commandManager = new CommandManager();
        StudentDB studentDB = new StudentDB();
        GroupDB groupDB = new GroupDB();
        StudentGroupDB studentgroupDB = new StudentGroupDB(studentDB, groupDB);
        commandManager.RegisterCommand("Create", new CommandCreateStudent(studentDB));
        commandManager.RegisterCommand("Search", new CommandSearchStudent(studentDB));
        commandManager.RegisterCommand("Delete", new CommandDeleteStudent(studentDB));
        commandManager.RegisterCommand("Edit", new CommandEditStudent(studentDB));
        commandManager.RegisterCommand("CreateG", new CommandCreateGroup(groupDB));
        commandManager.RegisterCommand("SearchG", new CommandSearchGroup(groupDB));
        commandManager.RegisterCommand("AddS", new CommandCreateStAndGr(studentgroupDB));
        commandManager.RegisterCommand("GetGroup", new CommandGetGroupByStudent(studentgroupDB));
        commandManager.RegisterCommand("GetStudent", new CommandGetStudentByGroup(studentgroupDB));

        // добавить команды:
        // Search - поиск студентов по имени/фамилии, должен выводиться UID
        // Delete - удаление выбранного студента (по UID или порядковому номеру в выведенном списке)
        // Edit - редактирование выбранного студента
        commandManager.Start();
    }

}
