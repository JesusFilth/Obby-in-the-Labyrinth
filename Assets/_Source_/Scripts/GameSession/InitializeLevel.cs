using System;
using System.Collections.Generic;
using System.Linq;
using Reflex.Attributes;
using UnityEngine;
using qtools.qmaze;
using Random = UnityEngine.Random;

public class InitializeLevel : MonoBehaviour
{
    [SerializeField] private QMazeEngine _mazeEngine;

    private List<StartPointMaze> _startPoints = new();
    private List<EnviromentObjectSpawn> _obstracleSpawn = new();
    private List<EnviromentObjectSpawn> _starsSpawn = new();

    [Inject] private Player _player;
    [Inject] private LevelStorage _levelStorage;

    private int TrapCount = 3;//temp, later create so for this 
    private int StarCount = 1;//temp, later create so for this 

    private void Start()
    {
        GenerateMaze();
        SetPlayerRandomStartPosition();
        CreateTraps();
        CreateStar();
    }

    public void AddStartPoint(StartPointMaze startPoint)
    {
        if (startPoint == null)
            throw new ArgumentNullException(nameof(startPoint));

        _startPoints.Add(startPoint);
    }

    public void AddObstracleSpawn(ObstracleSpawn obstracleSpawn)
    {
        if (obstracleSpawn == null)
            throw new ArgumentNullException(nameof(obstracleSpawn));

        _obstracleSpawn.Add(obstracleSpawn);
    }

    public void AddStarSpawn(StarSpawn starSpawn)
    {
        if (starSpawn == null)
            throw new ArgumentNullException(nameof(starSpawn));

        _starsSpawn.Add(starSpawn);
    }

    private void SetPlayerRandomStartPosition()
    {
        if (_startPoints.Count == 0)
            throw new ArgumentNullException(nameof(_startPoints));

        int randomIndex = Random.Range(0, _startPoints.Count);
        _player.SetPosition(_startPoints[randomIndex].Point);
    }

    private void GenerateMaze()
    {
        _mazeEngine.SetSize(_levelStorage.SizeMazeX, _levelStorage.SizeMazeY);
        _mazeEngine.generateMaze();
    }

    private void CreateTraps()
    {
        if (_obstracleSpawn.Count == 0)
            throw new ArgumentNullException(nameof(_obstracleSpawn));

        if (_obstracleSpawn.Count<TrapCount)
            TrapCount = _obstracleSpawn.Count;

        for (int i = 0; i < TrapCount; i++)
        {
            EnviromentObjectSpawn[] freeObstracle = _obstracleSpawn.Where(obst => obst.IsActive == false).ToArray();
            int randomIndex = Random.Range(0, freeObstracle.Length);
            freeObstracle[randomIndex].On();
        }
    }

    private void CreateStar()
    {
        if (_starsSpawn.Count == 0)
            throw new ArgumentNullException(nameof(_starsSpawn));

        if (_starsSpawn.Count < StarCount)
            StarCount = _starsSpawn.Count;

        for (int i = 0; i < StarCount; i++)
        {
            EnviromentObjectSpawn[] freeStars = _starsSpawn.Where(obst => obst.IsActive == false).ToArray();
            int randomIndex = Random.Range(0, freeStars.Length);
            freeStars[randomIndex].On();
        }
    }
}