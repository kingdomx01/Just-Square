using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationGun : MonoBehaviour
{
    Movement player;
    [SerializeField] private GameObject body;
    private GameObject gun;
    public GameObject Gun { set { gun = value; } }
    public void Start()
    {
        player =GameObject.Find("Player").GetComponent<Movement>();
        gun = FindObjectOfType<Gun>().gameObject;
    }       
    void Update()
    { 
        //Get the Screen positions of the object
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
         
        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        if (angle > -90 && angle < 90)
        {
            body.transform.localScale = new Vector3(1, body.transform.localScale.y, body.transform.localScale.z);
            gun.transform.localScale = new Vector3(gun.transform.localScale.x,gun.GetComponent<Gun>().Scale, gun.transform.localScale.z);
        }
        else
        {
            body.transform.localScale = new Vector3(-1, body.transform.localScale.y, body.transform.localScale.z);
            gun.transform.localScale = new Vector3(gun.transform.localScale.x, -gun.GetComponent<Gun>().Scale, gun.transform.localScale.z);
        }
        
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
