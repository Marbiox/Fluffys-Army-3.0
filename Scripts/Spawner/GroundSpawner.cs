using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject ground;
    void Awake()
    {
        Instantiate(ground, GroundPosition(), Quaternion.identity);
    }

    public Vector2 GroundPosition()
    {
        return new Vector2(0, ScreenUtils.ScreenBottom + HalfGroundCollider());
    }
    public float HalfGroundCollider()
    {
        return ground.GetComponent<BoxCollider2D>().size.y * ground.transform.localScale.y / 2;
    }
}
