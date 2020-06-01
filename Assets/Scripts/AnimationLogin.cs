using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationLogin : MonoBehaviour
{
    public Animator animator1;
    public Animator animator2;
    public Animator animator3;
    public GameObject canvas;
    public GameObject canvas2;
    public GameObject cameraAnimated;
    public GameObject cameraMain;
    public GameObject[] texts; 
    // Start is called before the first frame update
    void Start()
    {
        for(int i =0;i < texts.Length;i++){
            texts[i].SetActive(false);
        }
        canvas2.SetActive(true);
        StartCoroutine(StartAnimation());
    }
    IEnumerator StartAnimation(){
        animator3.SetTrigger("1");
        yield return new WaitForSeconds(1);
        animator1.SetTrigger("1");
        yield return new WaitForSeconds(20.45f);
        animator2.SetTrigger("1");
        yield return new WaitForSeconds(1.5f);
        canvas.SetActive(true);
        StopCoroutine(StartAnimation());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeCamera(){
        StartCoroutine(ChCamera());
    }
    IEnumerator ChCamera(){
        animator3.SetTrigger("2");
        yield return new WaitForSeconds(1);
        yield return new WaitForSeconds(1);
        canvas2.GetComponent<Canvas>().worldCamera = cameraMain.GetComponent<UnityEngine.Camera>();
        for(int i =0;i < texts.Length;i++){
            texts[i].SetActive(true);
        }
        canvas.SetActive(false);
        cameraAnimated.SetActive(false);
        cameraMain.SetActive(true);
        animator3.SetTrigger("1");
        yield return new WaitForSeconds(1.5f);
        canvas2.SetActive(false);
    }
    public bool IsAnimationPlaying1 (string animationName) {        
        // берем информацию о состоянии
        var animatorStateInfo = animator1.GetCurrentAnimatorStateInfo(0);
        // смотрим, есть ли в нем имя какой-то анимации, то возвращаем true
        if (animatorStateInfo.IsName(animationName))             
           return true;

        return false;
    }
    public bool IsAnimationPlaying2 (string animationName) {        
        // берем информацию о состоянии
        var animatorStateInfo = animator2.GetCurrentAnimatorStateInfo(0);
        // смотрим, есть ли в нем имя какой-то анимации, то возвращаем true
        if (animatorStateInfo.IsName(animationName))             
           return true;

        return false;
    }
}
