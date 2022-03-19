using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private string nameToTakeDamage;
    private Vector3 _deflection;
    private Shooting playerAttack;
    private Attack enemyAttack;
    float damage;
    bool crit;
    private void Start()
    {

    }
    public void Update()
    {
        
    }
    public void Movement(Vector3 direction,float speed)
    {
        _deflection = new Vector3(Random.Range(-0.2f, 0.2f), 0, 0);
        GetComponent<Rigidbody2D>().AddForce((direction + _deflection) * speed, ForceMode2D.Impulse);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<ITakeDamage>().TakeDamage(damage,crit);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Ground") )
        {
            Destroy(gameObject);
        }
    }
    public void GetDamage(float damage,bool crit)
    {
        this.damage = damage;
        this.crit = crit;
    }
}
