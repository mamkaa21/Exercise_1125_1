using System.Collections.Generic;
using System.Text.Json;

class StudentGroupDB
{
    Dictionary<string, string> studentGroup;
    Dictionary<string, List<string>> groupStudent;

    public StudentGroupDB(StudentDB studentDB, GroupDB groupDB)
    {
        this.studentDB = studentDB;
        this.groupDB = groupDB;
        //load file (json)
        if (!File.Exists("studentGroup.json"))
            studentGroup = new Dictionary<string, string>();
        else
            using (FileStream fs = new FileStream("studentGroup.json", FileMode.OpenOrCreate))
            {
                studentGroup = JsonSerializer.Deserialize<Dictionary<string, string>>(fs);

            }

        if (!File.Exists("GroupStudent.json"))
            groupStudent = new Dictionary<string, List<string>>();
        else
            using (FileStream fs = new FileStream("GroupStudent.json", FileMode.OpenOrCreate))
            {
                groupStudent = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(fs);

            }
    }
    private StudentDB studentDB;
    private readonly GroupDB groupDB;


    public bool AddS(string studentUID, string groupUID)
    {
        if (studentDB.GetStudentByUID(studentUID) == null)
        {
            Console.WriteLine("Такого студента нет");
            return false;
        }
        if (groupDB.GetGroupByUID(groupUID) == null)
        {
            Console.WriteLine("Такой группы нет");
            return false;
        }
        studentGroup.Add(studentUID, groupUID);
        if (groupStudent.ContainsKey(groupUID))
            groupStudent[groupUID].Add(studentUID);
        else
            groupStudent.Add(groupUID, new List<string>(new string[] { studentUID }));
        return true;
    }

    public Group GetGroupByStudent(string studentUID)
    {
        string uidGr = studentGroup[studentUID];
        return groupDB.GetGroupByUID(uidGr);
    }

    public List<Student> GetStudentByGroup(string groupUID)
    {
        List<Student> result = new List<Student>();
        List <string> uidSt = groupStudent[groupUID];
        for (int i = 0; i < uidSt.Count; i++)
        {
            string uid = uidSt[i];
            result.Add(studentDB.GetStudentByUID(uid));
        }
        return result;
    }




}





