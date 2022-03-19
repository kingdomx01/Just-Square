using UnityEngine;

public class Shooting : MonoBehaviour
{
    internal float damage = 10;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float _speed = 20.0f;
    [SerializeField] private GameObject buzzleFlash;
    private float _timeBtwShooting;
    private float timeTemp;
    private float timeTemp_2;
    private bool _isShooting = false;
    public Transform point;
    private WeaponStats weaponData;
    public Animator ani;
    private AudioSource gunAudio;
    public WeaponStats WeaponData { set{weaponData = value; } }
    public bool IsShooting
    {
        get { return this._isShooting; }
    }
    private void Awake()
    {
        gunAudio = FindObjectOfType<RotationGun>().GetComponent<AudioSource>();
        ani = FindObjectOfType<Gun>().GetComponent<Animator>();
        weaponData = FindObjectOfType<Gun>().GetComponent<Gun>().Data;
        point = FindObjectOfType<Gun>().GetComponent<Gun>().Point;
    }

    // Start is called before the first frame update
    void Start()
    {
        timeTemp = 0;
        _timeBtwShooting = weaponData.AttackSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        _timeBtwShooting = weaponData.AttackSpeed;
        Shoot();
    }
    private void Shoot()
    {
        if (timeTemp <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                GameObject buzzleFlashGameObject = Instantiate(buzzleFlash, point.position, point.rotation);
                buzzleFlashGameObject.transform.SetParent(gameObject.transform);
                GameObject bulletObject = Instantiate(bullet, point.position, point.rotation);
                if(weaponData.RatioCritDamage/100 > UnityEngine.Random.value)
                {
                    float random = Random.RandomRange(1.5f,3);
                    bulletObject.GetComponent<Bullet>().GetDamage(Mathf.FloorToInt(weaponData.Damage * random ),true);
                }
                else
                {
                    bulletObject.GetComponent<Bullet>().GetDamage(weaponData.Damage,false);
                }
                Destroy(bulletObject,0.2f);
                Destroy(buzzleFlashGameObject,0.2f);
                FindObjectOfType<Bullet>().Movement(point.right * -1, _speed);
                timeTemp = _timeBtwShooting;
                ani.SetTrigger("Shooting");
                float temp = Time.deltaTime * 2;
                if (gunAudio.volume >= 0.2f)
                {
                    gunAudio.volume = 0.2f;
                }
                else { gunAudio.volume += temp + 0.2f; }
            }
            else
            {
                gunAudio.volume -= Time.deltaTime * 3;
            }
        }
        else
        {
            timeTemp -= Time.deltaTime;
        }
        
    }
}
