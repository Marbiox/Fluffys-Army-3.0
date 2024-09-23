using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    void Start() {
        GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(transform.eulerAngles.z * Mathf.Deg2Rad),
        Mathf.Sin(transform.eulerAngles.z * Mathf.Deg2Rad)).normalized * bulletSpeed;
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Saw" || collision.gameObject.tag == "Enemy") {
            Destroy(gameObject);
        }
    }
}
