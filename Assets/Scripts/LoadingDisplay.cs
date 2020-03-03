using UniRx;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class LoadingDisplay : MonoBehaviour
{
    [SerializeField] private SplashScreen _splashScreen = null;

    private void Start()
    {
        var image = GetComponent<Image>();
        _splashScreen.ProgressObservable.Subscribe(loading => image.fillAmount = loading).AddTo(this);
    }
}
