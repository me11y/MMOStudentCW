using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TapTap : MonoBehaviour, IPointerDownHandler
{
    public Text damageText;
    public GameObject kekText;
    public GameObject parent;
    public float HP;
    public float currentHP;
    public Image hpImage;
    public int damage;
    int counter = 0;
    private void Start() {
        currentHP = HP;
    }
    private void Update() {
        if(currentHP==0){
            currentHP = HP;
            float scaler = (currentHP/HP);
            hpImage.transform.localScale = new Vector2((1*scaler),hpImage.transform.localScale.y);
            if(counter==0){
                kekText.SetActive(true);
            }else{
                kekText.GetComponent<Text>().text = "OK.. YOU TRIED.. BUT IN VANE...";
            }
            counter++;
        }
     }
    public void OnPointerDown(PointerEventData eventData)
    {
        Text text = Instantiate(damageText);
        text.transform.SetParent(parent.transform);
        text.transform.position = new Vector2(eventData.position.x+Random.Range(-50f,50f),eventData.position.y+Random.Range(-1,50f));
    }
    public void TakeDamage(int damage){
        if(currentHP!=0){
            currentHP -= damage;  
            float scaler = (currentHP/HP);
            hpImage.transform.localScale = new Vector2((1*scaler),hpImage.transform.localScale.y);
        }
    }
}
