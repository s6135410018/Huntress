using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class loadSceneGame : MonoBehaviour
{
    [SerializeField] GameObject loading;
    [SerializeField] Text loading_text;
    float progess;
    public string sceneName;
    private void Start()
    {
        if (loading && loading_text != null)
        {
            loading.SetActive(false);

        }
    }
    public void NextScene(string sceneName)
    {
        StartCoroutine(LoadNextScene(sceneName));
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            StartCoroutine(LoadNextScene(sceneName));
        }
    }
    IEnumerator LoadNextScene(string sceneName)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        asyncOperation.allowSceneActivation = false;
        while (!asyncOperation.isDone)
        {
            progess = (asyncOperation.progress / 0.9f);
            if (loading && loading_text != null)
            {
                loading.SetActive(true);
                loading_text.text = "Loading: " + (progess * 100).ToString("n0") + " %";
            }
            if (progess == 1)
            {
                asyncOperation.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
