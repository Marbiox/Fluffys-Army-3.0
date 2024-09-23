using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gem : MonoBehaviour
{

    const int pointValue = 20;

    void Update() {
        transform.Translate(0, -ConfigurationUtils.SawSpeed * Time.deltaTime,0);
    }

    /*void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("Collision: " + collision.gameObject);
        if (collision.gameObject.tag == "Player") {
            EventInvokerUtils.Invoke(EventName.addScore, pointValue);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Ground") {
            Destroy(gameObject);
        }
    }*/
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            EventInvokerUtils.Invoke(EventName.addScore, pointValue);
            EventInvokerUtils.Invoke(EventName.gemCollected);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Ground") {
            EventInvokerUtils.Invoke(EventName.gemComboEnded);
            Destroy(gameObject);
        }
    }
}
