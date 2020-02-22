using System;
using JetBrains.Annotations;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "New Game Master", menuName = "Singletons/Game Master")]
public class GameMaster : SingletonScriptableObject<GameMaster>
{
    [SerializeField] private int timeToWaitSplashScreenInSeconds = 4;

    public static void LoadNextScene()
    {
        var currentIndexScene = SceneManager.GetActiveScene().buildIndex;
        if (currentIndexScene == 0)
        {
            Observable.Timer(TimeSpan.FromSeconds(Instance.timeToWaitSplashScreenInSeconds))
                .Subscribe(_ => SceneManager.LoadScene(currentIndexScene + 1));
        }
        else
        {
            SceneManager.LoadScene(currentIndexScene + 1);
        }
    }

    [UsedImplicitly]
    public void LoadStartScene()
    {
        SceneManager.LoadScene(1);
    }

    [UsedImplicitly]
    [RuntimeInitializeOnLoadMethod]
    private static void Initialize()
    {
//        _currentIndexLevel = 0;
//        _currentScore.Value = 0;
//        _currentLives.Value = 0;
    }
}