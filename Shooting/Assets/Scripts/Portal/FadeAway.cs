using UnityEngine;
public class FadeAway : MonoBehaviour
{
    [SerializeField] private Animator ani;
    private void Start()
    {
        ani = GetComponent<Animator>();
    }
    public void Fade()
    {
        ani.SetTrigger("FadeOut");
    }
}
