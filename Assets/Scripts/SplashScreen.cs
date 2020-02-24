using System;
using Sirenix.OdinInspector;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SplashLoadType
{
    FixedTime,
    OnDemand
}

public class SplashScreen : MonoBehaviour
{
    [SerializeField] private SplashLoadType splashLoadType = SplashLoadType.FixedTime;

    [ShowIf("splashLoadType", SplashLoadType.FixedTime)] [SerializeField]
    private int timeToWaitSplashScreenInSeconds = 4;

    public ScheduledNotifier<float> ProgressObservable = new ScheduledNotifier<float>();

    private void Start()
    {
        switch (splashLoadType)
        {
            case SplashLoadType.FixedTime:
                Observable.Timer(TimeSpan.FromSeconds(timeToWaitSplashScreenInSeconds))
                    .Subscribe(_ => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1))
                    .AddTo(this);
                this.UpdateAsObservable()
                    .Subscribe(_ => ProgressObservable.Report(Time.time / timeToWaitSplashScreenInSeconds))
                    .AddTo(this);
                break;
            case SplashLoadType.OnDemand:
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1)
                    .AsAsyncOperationObservable(ProgressObservable)
                    .Subscribe()
                    .AddTo(this);
                break;
            default:
                throw new ArgumentException("Invalid SplashLoadType");
        }
    }
}