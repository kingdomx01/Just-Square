using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFollow : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private bool randomPos;
    private void Update()
    {
        if (randomPos)
        {
            float randomX = Random.Range(-0.3f,0.3f);
            offset.x += randomX;
            transform.position = Camera.main.WorldToScreenPoint(target.transform.position + offset);
        }
        else
        {
            transform.position = Camera.main.WorldToScreenPoint(target.transform.position + offset);
        }
    }
}
