using UnityEngine;

public class Gun : MonoBehaviour
{
    private Shooting shooting;
    private Animator ani;
    private AudioSource audioSource;
    [SerializeField] private float scaleY;
    [SerializeField] private WeaponStats data;
    [SerializeField] private Transform point;
    [SerializeField] private AudioClip audio;
    public WeaponStats Data { get { return data; } }
    public Transform Point { get { return point; } }
    public AudioClip Audio { get { return audio; } }
    public float Scale { get { return scaleY; } }
    // Start is called before the first frame update
    private void Awake()
    {
        audioSource = FindObjectOfType<RotationGun>().GetComponent<AudioSource>();
    }
    public void Start()
    {
    }
    public void SoundEffectGun()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = audio;
            audioSource.Play();
        }
    }
    public void StopSoundEffectGun()
    {
        if(audioSource.isPlaying)
         audioSource.Stop();
    }
}
