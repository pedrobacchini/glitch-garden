﻿using TMPro;
using UniRx;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class StarDisplay : MonoBehaviour
{
    private void Start()
    {
        var textMeshProUgui = GetComponent<TextMeshProUGUI>();
        GameMaster.Instance.Starts.Subscribe(stars => textMeshProUgui.text = stars.ToString()).AddTo(this);
    }
}
