using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    [SerializeField] float secondsToLoad = 2f;

    [SerializeField] AudioClip openSFX;
    [SerializeField] AudioClip closeSFX;

    private void OnTriggerEnter2D(Collider2D other)
    {
        GetComponent<Animator>().SetTrigger("open");

    }

    public void StartLoadingNextLevel()
    {
        GetComponent<Animator>().SetTrigger("close");
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        int currendSceneIndex = SceneManager.GetActiveScene().buildIndex;

        yield return new WaitForSeconds(secondsToLoad);
        SceneManager.LoadScene(currendSceneIndex + 1);

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
