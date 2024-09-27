using System;
using Reflex.Attributes;
using UnityEngine;

public class EnviromentObjectSpawn : MonoBehaviour
{
    [SerializeField] private EnviromentObject _item;

    [Inject] protected InitializeLevel InitLevel;

    public bool IsActive => _item.gameObject.activeSelf;

    private void Awake()
    {
        if (DIGameConteiner.Instance != null)
        {
            DIGameConteiner.Instance.InjectRecursive(gameObject);
            InitOnLevel();
        }
    }

    private void OnEnable()
    {
        try
        {
            Validate();
        }
        catch (ArgumentNullException ex)
        {
            enabled = false;
            throw ex;
        }
    }

    protected virtual void InitOnLevel() 
    {
    }

    public void On()
    {
        if (_item == null)
            return;

        _item.gameObject.SetActive(true);
    }

    private void Validate()
    {
        if (_item == null)
            throw new ArgumentNullException(nameof(_item));
    }
}
