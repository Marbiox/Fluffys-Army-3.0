using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    void Update() {
        transform.Translate(0, -ConfigurationUtils.SawSpeed * Time.deltaTime,0);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Ground") {
            Destroy(gameObject);
        }
    }
}
