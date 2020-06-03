using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginRegister : MonoBehaviour
{

    public Sprite[] images;
    public Canvas loginCanvas;
    public Canvas registerCanvas;
    public Image avatar;
    
    public void Start()
    {
        ElGetter.Init(images);
    }

    public void ToLogin()
    {
        loginCanvas.gameObject.SetActive(true);
        registerCanvas.gameObject.SetActive(false);
        this.gameObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x, 1.46f, 2f);
    }

    int currentAvatar;
    public void ToRegister(){
        loginCanvas.gameObject.SetActive(false);
        registerCanvas.gameObject.SetActive(true);
        this.gameObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x, 3f, 2f);
        avatar.GetComponent<Image>().sprite = images[0];
        currentAvatar = 0;
    }

    public void NextAvatar()
    {
        currentAvatar++;
        if (currentAvatar == images.Length) {
            currentAvatar = 0;
        }

        avatar.GetComponent<Image>().sprite = images[currentAvatar];
    }
    public void PrevAvatar()
    {
        currentAvatar--;
        if (currentAvatar < 0)
        {
            currentAvatar = images.Length-1;
        }

        avatar.GetComponent<Image>().sprite = images[currentAvatar];
    }

    public void Register()
    {
        int avatarID = currentAvatar;
        string login = registerCanvas.transform.GetChild(1).GetChild(0).GetComponent<InputField>().text;
        string password = registerCanvas.transform.GetChild(1).GetChild(1).GetComponent<InputField>().text;
        string fullname = registerCanvas.transform.GetChild(1).GetChild(2).GetComponent<InputField>().text;
        string title = registerCanvas.transform.GetChild(1).GetChild(3).GetComponent<InputField>().text;
        string group = registerCanvas.transform.GetChild(1).GetChild(4).GetComponent<InputField>().text;
        if(login == "" || password == "" || fullname == "" || title == "" || group == "")
        {
            return;
        }
        ElGetter.dBScript.RegisterUser(login, password, fullname, title, group, avatarID);
        ToLogin();
    }

    public void Login()
    {
        string login = loginCanvas.transform.GetChild(0).GetComponent<InputField>().text;
        string password = loginCanvas.transform.GetChild(1).GetComponent<InputField>().text;
        StartCoroutine(TryLogin(login, password));
    }

    IEnumerator TryLogin(string login, string password)
    {
        yield return StartCoroutine(ElGetter.dBScript.TryLogin(login, password));
        yield return new WaitForSeconds(0.5f);
        if (ElGetter.dBScript.loggedin)
        {
            ElGetter.login.ChangeCamera();
            StartCoroutine(ElGetter.initializer.InitData());
        }
    }
    
}
