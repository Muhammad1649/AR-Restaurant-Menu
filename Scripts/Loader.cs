using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Loader : MonoBehaviour
{
    [SerializeField]private float loadingDelay = 5.0f;
    [SerializeField]private Slider loadingBar;
    private void Start() {
        Invoke("Load", loadingDelay);
    }
    void Load() {
        StartCoroutine(LoadAsyncronusly());
    }
    IEnumerator LoadAsyncronusly() {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        loadingBar.value =  operation.progress;
        while (operation.isDone) {
            yield return null;
        }
    }  
}
