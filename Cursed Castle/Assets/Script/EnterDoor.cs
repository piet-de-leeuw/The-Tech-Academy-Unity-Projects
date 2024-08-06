using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDoor : MonoBehaviour
{
    Animator animator;
    [SerializeField] AudioClip openSFX;
    [SerializeField] AudioClip closeSFX;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("open");
        StartCoroutine(WaitToClose());

    }

    IEnumerator WaitToClose()
    {
        yield return new WaitForSeconds(1.5f);
        animator.SetTrigger("close");
    }

    public void OpenSFX()
    {
        AudioSource.PlayClipAtPoint(openSFX, Camera.main.transform.position);
    }

    public void CloseSFX()
    {
        AudioSource.PlayClipAtPoint(closeSFX, Camera.main.transform.position);
    }

}
