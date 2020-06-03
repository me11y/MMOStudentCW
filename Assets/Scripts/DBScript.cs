using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;

public class DBScript : MonoBehaviour
{
    DatabaseReference reference;
    public bool loggedin;

    private void Awake()
    {
        ElGetter.Init(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://mmostudent-995b2.firebaseio.com/");

        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RegisterUser(string login, string password, string fullname, string title, string group, int avatarId)
    {
        reference.Child("users").Child(login).Child("login").SetValueAsync(login);
        reference.Child("users").Child(login).Child("password").SetValueAsync(password);
        reference.Child("users").Child(login).Child("fullname").SetValueAsync(fullname);
        reference.Child("users").Child(login).Child("title").SetValueAsync(title);
        reference.Child("users").Child(login).Child("group").SetValueAsync(group);
        reference.Child("users").Child(login).Child("avatarID").SetValueAsync(avatarId);
    }

    public IEnumerator TryLogin(string login, string password)
    {
        string dblogin = "";
        string dbpassword = "";
        reference.Child("users").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.Log("error");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                foreach (DataSnapshot user in snapshot.Children)
                {
                    IDictionary dictUser = (IDictionary)user.Value;
                    dblogin = dictUser["login"] + "";
                    dbpassword = dictUser["password"] + "";

                    if (login.Equals(dblogin) && password.Equals(dbpassword))
                    {
                        loggedin = true;
                        UserGroup.list.Add(new UserData(dblogin, dictUser["fullname"] + "", dictUser["title"] + "", dictUser["group"] + "", System.Int32.Parse(dictUser["avatarID"] + "")));
                        break;
                    }
                 
                }
            }
        });
        
        yield return true;
    }

    public IEnumerator GetGroupList()
    {
        reference.Child("users").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.Log("error");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                foreach (DataSnapshot user in snapshot.Children)
                {
                    IDictionary dictUser = (IDictionary)user.Value;

                    if ((dictUser["group"] + "").Equals(UserGroup.list[0].group))
                    {
                        if (UserGroup.list[0].login != dictUser["login"] + "")
                        {
                            UserGroup.list.Add(new UserData(dictUser["login"] + "", dictUser["fullname"] + "", dictUser["title"] + "", dictUser["group"] + "", System.Int32.Parse(dictUser["avatarID"] + "")));
                        }
                    }

                }
            }
        });
        yield return null;
    }

    public IEnumerator GetSchedule()
    {
        reference.Child("schedule").Child("groups").Child(UserGroup.list[0].group).GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.Log("error");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                foreach (DataSnapshot day in snapshot.Children)
                {
                    IDictionary dictDay = (IDictionary)day.Value;
                    if(day.Key == "Monday")
                    {
                        for (int i = 1; i <= dictDay.Count; i++)
                        {
                            Schedule.monday.Add(dictDay["subj" + i] + "");
                        }
                    }else if (day.Key == "Tuesday")
                    {
                        for (int i = 1; i <= dictDay.Count; i++)
                        {
                            Schedule.tuesday.Add(dictDay["subj" + i] + "");
                        }
                    }
                    else if (day.Key == "Wednesday")
                    {
                        for (int i = 1; i <= dictDay.Count; i++)
                        {
                            Schedule.wednesday.Add(dictDay["subj" + i] + "");
                        }
                    }
                    else if (day.Key == "Thursday")
                    {
                        for (int i = 1; i <= dictDay.Count; i++)
                        {
                            Schedule.thursday.Add(dictDay["subj" + i] + "");
                        }
                    }
                    else if (day.Key == "Friday")
                    {
                        for (int i = 1; i <= dictDay.Count; i++)
                        {
                            Schedule.friday.Add(dictDay["subj" + i] + "");
                        }
                    }


                }
            }
        });
        yield return null;
    }


}
