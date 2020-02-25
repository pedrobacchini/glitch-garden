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
        var initialColor = _childrenEnumerable.First().GetComponent<Image>().color;
        _childrenEnumerable
            .ForEach(child =>
            {
                child.OnMouseDownAsObservable()
                    .Subscribe(_ =>
                    {
                        ResetColorChildren(initialColor);
                        child.GetComponent<Image>().color = Color.white;
                    });
            });
    }

    private void ResetColorChildren(Color initialColor)
    {
        foreach (var child in _childrenEnumerable)
            child.GetComponent<Image>().color = initialColor;
    }
}