using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using qtools.qmaze;
using Reflex.Attributes;
using UnityEngine;
using Random = UnityEngine.Random;

public class InitializeLevel : MonoBehaviour
{
    [SerializeField] private QMazeEngine _mazeEngine;
    [Inject] private ILevelCurrent _levelCurrent;
    private List<EnviromentObjectSpawn> _obstracleSpawn = new();

    [Inject] private Player _player;
    private List<EnviromentObjectSpawn> _starsSpawn = new();

    private List<StartPointMaze> _startPoints = new();
    [Inject] private UserStorage _userStorage;

    private void Awake()
    {
        _levelCurrent.InitGame(_userStorage.GetLastLevelNumber());
    }

    private IEnumerator Start()
    {
        GenerateMaze();
        yield return new WaitForSeconds(1.0f);

        SetPlayerRandomStartPosition();
        CreateTraps();
        CreateStar();
    }

    public void AddPlayerStartPoint(StartPointMaze startPoint)
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

        var randomIndex = Random.Range(0, _startPoints.Count);
        _player.SetPosition(_startPoints[randomIndex].Point);
    }

    private void GenerateMaze()
    {
        _mazeEngine.SetSize(_levelCurrent.GetMazeSizeX(), _levelCurrent.GetMazeSizeY());
        _mazeEngine.generateMaze();
    }

    private void CreateTraps()
    {
        if (_obstracleSpawn.Count == 0)
            throw new ArgumentNullException(nameof(_obstracleSpawn));

        for (var i = 0; i < _levelCurrent.GetTrapsCount(); i++)
        {
            var freeObstracle = _obstracleSpawn.Where(obst => obst.CanSpawn(_levelCurrent.GetCurrentLevel())).ToArray();

            if (freeObstracle.Length == 0)
                continue;

            var randomIndex = Random.Range(0, freeObstracle.Length);
            freeObstracle[randomIndex].On();
        }
    }

    private void CreateStar()
    {
        if (_starsSpawn.Count == 0)
            throw new ArgumentNullException(nameof(_starsSpawn));

        for (var i = 0; i < _levelCurrent.GetStarCountInMaze(); i++)
        {
            var freeStars = _starsSpawn.Where(obst => obst.IsActive == false).ToArray();
            var randomIndex = Random.Range(0, freeStars.Length);
            freeStars[randomIndex].On();
        }
    }
}