using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData
{
    public string login;
    public string fullname;
    public string title;
    public string group;
    public int avatarID;

    public UserData(string login, string fullname, string title, string group, int avatarID)
    {
        this.login = login;
        this.fullname = fullname;
        this.title = title;
        this.group = group;
        this.avatarID = avatarID;
    }
}
