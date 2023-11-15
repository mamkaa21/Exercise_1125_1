using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json;


class GroupDB
{
    Dictionary<string, Group> groups;

    public GroupDB()
    {
        //load file (json)
        if (!File.Exists("groups.json"))
            groups = new Dictionary<string, Group>();
        else
            using (FileStream fs = new FileStream("groups.json", FileMode.OpenOrCreate))
            {
                groups = JsonSerializer.Deserialize<Dictionary<string, Group>>(fs);
            }

    }

    public List<Group> Search(string text)
    {
        List<Group> result = new();
        foreach (var group in groups.Values)
        {
            if (group.Nomer.Contains(text))
                result.Add(group);
        }
        return result;
    }

    public Group Create()
    {
        Group group = new Group { UID = Guid.NewGuid().ToString() };
        groups.Add(group.UID, group);
        return group;
    }

    public bool Update(Group group)
    {
        if (!groups.ContainsKey(group.UID))
            return false;
        groups[group.UID] = group;
        Save();
        return true;
    }

    void Save()
    {
        // save file (json)
        using (FileStream fs = new FileStream("groups.json", FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize(fs, groups);
        }
    }

    public Group GetGroupByUID (string uid)
    {
        if (!groups.ContainsKey(uid))
            return null;
        else 
            return groups[uid];


    }

}


