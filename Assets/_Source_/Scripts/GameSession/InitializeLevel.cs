using System;
using System.Collections.Generic;
using Reflex.Attributes;
using qtools.qmaze;
using UnityEngine;
using Random = UnityEngine.Random;

public class InitializeLevel : MonoBehaviour
{
    [SerializeField] private QMazeEngine _mazeEngine;

    private List<StartPointMaze> _startPoints = new();

    [Inject] private Player _player;
    [Inject] private LevelStorage _levelStorage;

    private void Start()
    {
        _mazeEngine.SetSize(_levelStorage.SizeMazeX,_levelStorage.SizeMazeY);
        _mazeEngine.generateMaze();
        SetPlayerRandomStartPosition();
    }

    public void AddStartPoint(StartPointMaze startPoint)
    {
        if (startPoint == null)
            throw new ArgumentNullException(nameof(startPoint));

        _startPoints.Add(startPoint);
    }

    private void SetPlayerRandomStartPosition()
    {
        int randomIndex = Random.Range(0, _startPoints.Count);

        _player.SetPosition(_startPoints[randomIndex].Point);
    }
}