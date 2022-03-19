using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperEnemy : MonoBehaviour
{
    public static int amountOfEnemyKilled;
    [SerializeField] private List<GameObject> _enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (amountOfEnemyKilled > 25)
        {
            int random = Random.Range(0,_enemy.Count);
            
        }
    }
}
