using JetBrains.Annotations;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "New Game Master", menuName = "Singletons/Game Master")]
public class GameMaster : SingletonScriptableObject<GameMaster>
{
    public ReactiveProperty<Defender> SelectDefender { get; } = new ReactiveProperty<Defender>();
    
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
    }
}