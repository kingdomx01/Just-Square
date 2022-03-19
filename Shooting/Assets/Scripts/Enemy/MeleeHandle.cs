using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeHandle : MonoBehaviour
{
    private float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<ITakeDamage>().TakeDamage(damage,false);
        }
        Destroy(gameObject);
    }
    public void GetDamage(float damage)
    {
        this.damage = damage;
    }
}
