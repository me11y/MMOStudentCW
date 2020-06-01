using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Kolodec : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public GameObject gameObject;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void OnPointerDown(PointerEventData eventData){
    }
    public void OnPointerUp(PointerEventData eventData){
        if(!gameObject.active){
            gameObject.SetActive(true);
            StartCoroutine(Reload());
        }
    }
    IEnumerator Reload(){
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }


}
