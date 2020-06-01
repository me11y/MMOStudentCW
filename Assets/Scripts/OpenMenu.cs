using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenMenu : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject[] gos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerDown(PointerEventData eventData){
    }
    public void OnPointerUp(PointerEventData eventData){
        gos[0].SetActive(true);
        gos[1].SetActive(true);
        gos[2].SetActive(false);
    }
}
