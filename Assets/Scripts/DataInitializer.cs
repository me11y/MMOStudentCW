using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataInitializer : MonoBehaviour
{

    public GameObject studentPrefab;
    public GameObject groupList;
    public GameObject playerCanvas;
    public GameObject journalList;
    public GameObject marksPrefab;
    public GameObject subjPrefab;
    public GameObject subjList;
   
    private void Awake()
    {
        ElGetter.Init(this);
    }

    public IEnumerator InitData()
    {
        yield return StartCoroutine(ElGetter.dBScript.GetGroupList());
        yield return StartCoroutine(ElGetter.dBScript.GetSchedule());
        yield return new WaitForSeconds(0.5f);
        GenerateStudents();
        GenerateSubjects();
    }

    public void GenerateStudents()
    {
        foreach(UserData user in UserGroup.list)
        {
            GameObject go = GameObject.Instantiate(studentPrefab, groupList.transform);
            go.transform.GetChild(0).GetComponent<Text>().text = (UserGroup.list.IndexOf(user) + 1) + "";
            go.transform.GetChild(1).GetComponent<Text>().text = user.fullname;
            GameObject go2 = GameObject.Instantiate(marksPrefab, journalList.transform.GetChild(0).GetChild(0));
            go2.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text = user.fullname;
            Button btn = go.transform.GetChild(2).GetComponent<Button>();
            btn.onClick.AddListener(()=> {
                playerCanvas.SetActive(true);
                playerCanvas.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(1).GetComponent<Image>().sprite = ElGetter.avatars[user.avatarID];
                playerCanvas.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetComponent<Text>().text = "Name: " + user.fullname;
                playerCanvas.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(1).GetComponent<Text>().text = "Title: " + user.title;
                playerCanvas.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(2).GetComponent<Text>().text = "Guild: " + user.group;
            });
        }
    }

    public void GenerateSubjects()
    {
        foreach (string s in Schedule.monday)
        {
            GameObject go = GameObject.Instantiate(subjPrefab, subjList.transform.GetChild(0).GetChild(1).GetChild(0));
            go.transform.GetChild(0).GetComponent<Text>().text = s;
            go.transform.GetChild(1).GetComponent<Text>().text = Schedule.monday.IndexOf(s) + "";
        }
        foreach (string s in Schedule.tuesday)
        {
            GameObject go = GameObject.Instantiate(subjPrefab, subjList.transform.GetChild(1).GetChild(1).GetChild(0));
            go.transform.GetChild(0).GetComponent<Text>().text = s;
            go.transform.GetChild(1).GetComponent<Text>().text = Schedule.tuesday.IndexOf(s) + "";
        }
        foreach (string s in Schedule.wednesday)
        {
            GameObject go = GameObject.Instantiate(subjPrefab, subjList.transform.GetChild(2).GetChild(1).GetChild(0));
            go.transform.GetChild(0).GetComponent<Text>().text = s;
            go.transform.GetChild(1).GetComponent<Text>().text = Schedule.wednesday.IndexOf(s) + "";
        }
        foreach (string s in Schedule.thursday)
        {
            GameObject go = GameObject.Instantiate(subjPrefab, subjList.transform.GetChild(3).GetChild(1).GetChild(0));
            go.transform.GetChild(0).GetComponent<Text>().text = s;
            go.transform.GetChild(1).GetComponent<Text>().text = Schedule.thursday.IndexOf(s) + "";
        }
        foreach (string s in Schedule.friday)
        {
            GameObject go = GameObject.Instantiate(subjPrefab, subjList.transform.GetChild(4).GetChild(1).GetChild(0));
            go.transform.GetChild(0).GetComponent<Text>().text = s;
            go.transform.GetChild(1).GetComponent<Text>().text = Schedule.friday.IndexOf(s) + "";
        }
    }

    }
