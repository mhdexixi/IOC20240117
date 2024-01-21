using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public CanvasGroup splashScreen; // 引用启动界面CanvasGroup组件
    public string gameSceneName = "GameScene"; // 游戏场景名称

    private AsyncOperation loadOperation;

    void Start()
    {
        StartCoroutine(LoadGameScene());
    }

    IEnumerator LoadGameScene()
    {
        // 开始异步加载游戏场景
        loadOperation = SceneManager.LoadSceneAsync(gameSceneName, LoadSceneMode.Single);

        // 显示启动界面
        splashScreen.alpha = 1f;
        splashScreen.interactable = false;
        splashScreen.blocksRaycasts = true;

        // 等待加载完成
        while (!loadOperation.isDone)
        {
            // 这里可以添加显示加载进度的逻辑，如果有的话
            yield return null;
        }

        // 加载完成后淡出并隐藏启动界面
        FadeOutSplashScreen();
    }

    void FadeOutSplashScreen()
    {
        // 使用LeanTween或其他插件进行淡出动画，或者直接设置alpha为0
        /*LeanTween.alpha(splashScreen.gameObject, 0f, 1f).setOnComplete(() =>
        {
            splashScreen.gameObject.SetActive(false); // 或者Destroy(splashScreen.gameObject);
        });*/
        Destroy(splashScreen.gameObject);
    }
}