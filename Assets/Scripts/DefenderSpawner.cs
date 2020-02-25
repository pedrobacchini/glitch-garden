using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    private Defender _defender = null;

    private void Start()
    {
        this.OnMouseDownAsObservable()
            .Select(_ => Camera.main.ScreenToWorldPoint(Input.mousePosition))
            .Subscribe(mousePosition =>
                Instantiate(_defender, getWorldPositionInGrid(mousePosition), Quaternion.identity));

        GameMaster.Instance.SelectDefender.Subscribe(defender => _defender = defender);
    }

    private static Vector2 getWorldPositionInGrid(Vector2 mousePosition)
    {
        var roundToIntX = Mathf.RoundToInt(mousePosition.x);
        var roundToIntY = Mathf.RoundToInt(mousePosition.y);
        return new Vector2(roundToIntX, roundToIntY);
    }
}