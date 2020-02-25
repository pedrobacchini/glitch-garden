using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] private GameObject defender = null;

    private void Start()
    {
        this.OnMouseDownAsObservable()
            .Select(_ => Camera.main.ScreenToWorldPoint(Input.mousePosition))
            .Subscribe(mousePosition => Instantiate(defender, getWorldPositionInGrid(mousePosition), Quaternion.identity));
    }

    private static Vector2 getWorldPositionInGrid(Vector2 mousePosition)
    {
        var roundToIntX = Mathf.RoundToInt(mousePosition.x);
        var roundToIntY = Mathf.RoundToInt(mousePosition.y);
        return new Vector2(roundToIntX, roundToIntY);
    }
}