using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator animator;

    public void loadNextScene()
    {
        StartCoroutine(LoadNext());
    }

    public IEnumerator LoadNext()
    {
        animator.SetTrigger("FadeIn");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
