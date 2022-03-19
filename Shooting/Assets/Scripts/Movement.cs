using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float _speed ;
    [SerializeField] private float _force = 5.0f;

    Rigidbody2D rd;

    private bool _grounded = true;
    private bool _doubleJump = false;
    [Tooltip("Enter the scale of object it's help to flip object")]
    [SerializeField] private float scaleObject = 0.6f;
    public bool flipx = false;
    [SerializeField] private GameObject body;
    private HandleItemStats characterData;
    // Start is called before the first frame update
    private void Awake()
    {
        characterData = FindObjectOfType<HandleItemStats>();
    }
    void Start()
    {
        _speed = characterData.Speed;
        rd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _speed = characterData.Speed;
        Move();
        Jump();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _grounded == true)
        {
            _grounded = false;
            _doubleJump = true;
            rd.AddForce(_force * Vector2.up, ForceMode2D.Impulse);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && _doubleJump)
        {
            rd.AddForce(4 * Vector2.up, ForceMode2D.Impulse);
            _doubleJump = false;
        }
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed * Time.deltaTime * Vector2.left, 0);
            if (!GetComponent<Shooting>().IsShooting)
            {
                body.transform.localScale = new Vector3(1, body.transform.localScale.y, body.transform.localScale.z);
            }
            flipx = false;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime * Vector2.right, 0);
            if (flipx ==false)
            {
                if (!GetComponent<Shooting>().IsShooting)
                {
                    body.transform.localScale = new Vector3(1, body.transform.localScale.y, body.transform.localScale.z);
                }
                flipx = true;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
            _grounded = true;
            _doubleJump = false;
    }
}
