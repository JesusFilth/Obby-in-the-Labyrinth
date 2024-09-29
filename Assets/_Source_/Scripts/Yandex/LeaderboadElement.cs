using System;
using TMPro;
using UnityEngine;

public class LeaderboadElement : MonoBehaviour
{
    [SerializeField] private TMP_Text _rank;
    [SerializeField] private TMP_Text _playerName;
    [SerializeField] private TMP_Text _playerScore;

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

    public void Init(string rank, string name, string score)
    {
        _rank.text = rank;
        _playerName.text = name;
        _playerScore.text = score;
    }

    private void Validate()
    {
        if (_rank == null)
            throw new ArgumentNullException(nameof(_rank));

        if (_playerName == null)
            throw new ArgumentNullException(nameof(_playerName));

        if (_playerScore == null)
            throw new ArgumentNullException(nameof(_playerScore));
    }
}
