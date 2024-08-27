using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    static string sceneName = "Null";

    [SerializeField] private Slider progressbar;
    [SerializeField] private TextMeshProUGUI loadingText;
    [SerializeField] private TextMeshProUGUI progressText;

    public static void SceneLoad(SceneName scene)
    {
        if (scene == SceneName.Null || scene == SceneName.Loading) return;
        if (scene.ToString() == SceneManager.GetActiveScene().name) return;

        var targetScene = scene;
        sceneName = scene.ToString();

        SceneManager.LoadScene(SceneName.Loading.ToString());
    }

    private void Start()
    {
        StartCoroutine(SceneLoadCoroutine());
    }

    private IEnumerator SceneLoadCoroutine()
    {
        yield return null;
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneName);
        op.allowSceneActivation = false;
        float timer = 0.0f;

        while (!op.isDone) {
            yield return null;
            timer += Time.deltaTime;

            if (op.progress < 0.9f) {
                progressbar.value = Mathf.Lerp(progressbar.value, op.progress, timer);
                progressText.text = (progressbar.value * 100f).ToString("F1") + " %";
                if (progressbar.value >= op.progress) {
                    timer = 0f;
                }
            }
            else {
                progressbar.value = Mathf.Lerp(progressbar.value, 1f, timer);
                progressText.text = "100 %";
                if (progressbar.value == 1.0f) {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }  
    }
}