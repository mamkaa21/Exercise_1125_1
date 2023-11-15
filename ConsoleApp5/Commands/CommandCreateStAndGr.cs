class CommandCreateStAndGr : UserCommand

{
    private StudentGroupDB studentGroupDB;

    public CommandCreateStAndGr(StudentGroupDB studentGroupDB)
    {
        this.studentGroupDB = studentGroupDB;
    }

    public override void Execute()
    {
        Console.WriteLine("Введите uid студента..");
        string uidSt = Console.ReadLine();
        Console.WriteLine("Введите uid группу..");
        string uidGr = Console.ReadLine();
        if (studentGroupDB.AddS(uidSt, uidGr))
        Console.WriteLine("Студент добавлен в группу!");
    }
}