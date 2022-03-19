using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private Transform spawnPos;
    [SerializeField] private float distance;
    // Start is called before the first frame update
    void Start()
    {
        if (spawnPos == null) return;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < distance)
        {
            transform.position = spawnPos.position;
        }
    }
}
