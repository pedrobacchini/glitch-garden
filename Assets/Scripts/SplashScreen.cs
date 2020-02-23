using System;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SplashLoadType
{
    FixedTime,
    OnDemand
}

public class SplashScreen : MonoBehaviour
{
    [SerializeField] private int timeToWaitSplashScreenInSeconds = 4;
    [SerializeField] private SplashLoadType splashLoadType = SplashLoadType.FixedTime;
    public FloatReactiveProperty CurrentLoading { get; } = new FloatReactiveProperty(0);

    private void Start()
    {
        switch (splashLoadType)
        {
            case SplashLoadType.FixedTime:
                Observable.Interval(TimeSpan.FromSeconds(1))
                    .Take(timeToWaitSplashScreenInSeconds)
                    .Timestamp()
                    .Subscribe(x => CurrentLoading.Value += 1f / timeToWaitSplashScreenInSeconds,
                        () => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1))
                    .AddTo(this);
                break;
            case SplashLoadType.OnDemand:
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1)
                    .ToObservable()
                    .Do(x => CurrentLoading.Value = x)
                    .Last()
                    .Subscribe()
                    .AddTo(this);
                break;
            default:
                throw new ArgumentException("Invalid SplashLoadType");
        }
    }
}