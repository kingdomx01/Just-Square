using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreTrap : MonoBehaviour
{
    [SerializeField] private float _damage = 5;
    Coroutine StorageIE;
    private void Awake()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           StorageIE = StartCoroutine(InflictDamage(collision.gameObject));
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StopCoroutine(StorageIE);
        }
    }
    IEnumerator InflictDamage(GameObject player)
    {
        while (player != null)
        {
            player.GetComponent<ITakeDamage>().TakeDamage(_damage,false);
            yield return new WaitForSeconds(1);
        }
    }
}
