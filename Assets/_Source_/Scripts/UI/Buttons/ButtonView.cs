﻿using Reflex.Attributes;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class ButtonView : MonoBehaviour
{
    private Button _button;

    [Inject] protected StateMashineUI StateMashine;

    protected virtual void Awake()
    {
        _button = GetComponent<Button>();
    }

    protected virtual void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    protected virtual void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    protected abstract void OnClick();
}