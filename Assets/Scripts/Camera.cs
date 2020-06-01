using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Camera : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private Vector3 curPos;
    public GameObject camera;
    private float a;
    private float x;
    private float vx;
    private float tx=0.05f;
    private float nextY;
    void Start()
    {
        a = camera.transform.localRotation.eulerAngles.y;
    }

    void Update()
    {
        
    }
    public void OnPointerDown(PointerEventData eventData){
        curPos = eventData.position;
    }
    public void OnPointerUp(PointerEventData eventData){
        a=a+(curPos.x-eventData.position.x)/10f;
    }
    public void OnDrag(PointerEventData eventData){
        nextY = a+(curPos.x-eventData.position.x)/10f;
        x = Mathf.SmoothDamp(x,nextY,ref vx,tx);
        camera.transform.localRotation = Quaternion.Euler(camera.transform.localRotation.eulerAngles.x,x,camera.transform.localRotation.eulerAngles.z);
    
    }
}
