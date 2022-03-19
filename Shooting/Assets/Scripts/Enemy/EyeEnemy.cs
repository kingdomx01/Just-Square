using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeEnemy : MonoBehaviour
{
    [SerializeField] private Vector3 setting;
    private GameObject enemy;
    private bool _CanWalkThisWay = false;

    public bool CanWalkThisWay
    {
        get { return _CanWalkThisWay; }
    }

    // Start is called before the first frame update
    void Start()
    {
        enemy = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawLine(gameObject.transform.position, gameObject.transform.position + setting, Color.red);
        //if (GetComponentInParent<Enemy>().Body.transform.localScale.x > 0)
        //{
        //    setting.x = -70;
        //}
        //else
        //{
        //    setting.x = 2; // -5
        //}
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.position + setting, 10, LayerMask.GetMask("Ground"));
        if (hit.collider != null)
        {
            Debug.DrawRay(transform.position, (transform.position + setting ), Color.yellow);
            _CanWalkThisWay = true;
        }
        else
        {
            Debug.DrawRay(transform.position,( transform.position + setting ), Color.white);
            _CanWalkThisWay = false;
        }
    }
}
