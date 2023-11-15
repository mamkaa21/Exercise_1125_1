class CommandGetStudentByGroup : UserCommand
{
    private StudentGroupDB studentGroupDB;

    public CommandGetStudentByGroup(StudentGroupDB studentGroupDB)
    {
        this.studentGroupDB = studentGroupDB;
    }

    public override void Execute()
    {
        Console.WriteLine("Введите uid группы для поиска студента...");
        List<Student> students = studentGroupDB.GetStudentByGroup(Console.ReadLine());
        for (int i = 0; i < students.Count; i++)
            Console.WriteLine($"{i + 1}). {students[i].LastName} {students[i].FirstName} {students[i].UID}");
    }
}
