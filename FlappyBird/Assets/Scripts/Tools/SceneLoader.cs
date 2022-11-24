using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator animator;
    public void LoadNextScene()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void LoadConcreteScene(int idx)
    {
        StartCoroutine(LoadScene(idx));
    }

    IEnumerator LoadScene(int sceneIndex)
    {
        animator.SetTrigger("TrLoadLevel");

        yield return Coroutines.WaitForUnscaledSeconds(2f);

        SceneManager.LoadScene(sceneIndex);
    }
}
