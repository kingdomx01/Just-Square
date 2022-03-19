using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    [SerializeField] private Color32 _colorWhenGOCollisionWithLava;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Collision"); 
        collision.gameObject.GetComponent<SpriteRenderer>().color = _colorWhenGOCollisionWithLava;
    }
}
