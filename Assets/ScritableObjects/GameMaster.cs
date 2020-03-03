using JetBrains.Annotations;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "New Game Master", menuName = "Singletons/Game Master")]
public class GameMaster : SingletonScriptableObject<GameMaster>
{
    [SerializeField] private int InitialStars = 100;
    public ReactiveProperty<Defender> SelectDefender { get; } = new ReactiveProperty<Defender>();
    public IntReactiveProperty Starts { get; } = new IntReactiveProperty(100);
    
    public static void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
        Instance.Starts.Value = Instance.InitialStars;
    }
}