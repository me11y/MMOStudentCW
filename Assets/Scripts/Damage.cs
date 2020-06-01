using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{
    private int damage;
    private void Start() {
        damage = GameObject.FindGameObjectWithTag("Enemy").GetComponent<TapTap>().damage;
        GetComponent<Text>().text = "-"+damage.ToString();
        GameObject.FindGameObjectWithTag("Enemy").GetComponent<TapTap>().TakeDamage(damage);
        StartCoroutine(Destroy());
    }
    private void Update() {
        this.transform.position = new Vector2(transform.position.x,transform.position.y+3);
    }
    IEnumerator Destroy(){
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
