using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] GameObject player;
    void Start()
    {
        float halfColliderHeight = player.GetComponent<SpriteRenderer>().size.y / 2;
        Vector2 position = new Vector2(0, ConfigurationUtils.GroundPosition.y + ConfigurationUtils.HalfGroundColliderHeight + halfColliderHeight);
        Instantiate(player,position,Quaternion.identity);
    }
}
