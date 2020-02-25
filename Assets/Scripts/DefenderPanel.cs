using Sirenix.Utilities;
using UniRx;
using UniRx.Triggers;
using Unity.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DefenderPanel : MonoBehaviour
{
    private GameObjectExtensions.ChildrenEnumerable _childrenEnumerable;

    private void Start()
    {
        _childrenEnumerable = gameObject.Children();

        var first = _childrenEnumerable.First();
        var initialColor = first.GetComponent<Image>().color;

        SelectChild(first);

        _childrenEnumerable
            .ForEach(child =>
            {
                child.OnMouseDownAsObservable()
                    .Subscribe(_ =>
                    {
                        ResetColorChildren(initialColor);
                        SelectChild(child);
                    });
            });
    }

    private static void SelectChild(GameObject child)
    {
        child.GetComponent<Image>().color = Color.white;
        GameMaster.Instance.SelectDefender.Value = child.GetComponent<DefenderButton>().defender;
    }

    private void ResetColorChildren(Color initialColor)
    {
        foreach (var child in _childrenEnumerable)
            child.GetComponent<Image>().color = initialColor;
    }
}