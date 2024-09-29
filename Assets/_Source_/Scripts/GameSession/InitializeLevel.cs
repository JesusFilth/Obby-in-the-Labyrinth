using System;
using System.Collections.Generic;
using System.Linq;
using Reflex.Attributes;
using UnityEngine;
using qtools.qmaze;
using Random = UnityEngine.Random;
using System.Collections;

public class InitializeLevel : MonoBehaviour
{
    [SerializeField] private QMazeEngine _mazeEngine;

    private List<StartPointMaze> _startPoints = new();
    private List<EnviromentObjectSpawn> _obstracleSpawn = new();
    private List<EnviromentObjectSpawn> _starsSpawn = new();

    [Inject] private Player _player;
    [Inject] private ILevelCurrent _levelCurrent;
    [Inject] private UserStorage _userStorage;
    [Inject] private GlueCreator _glueCreator;

    private IEnumerator Start()
    {
        if(_levelCurrent.InitGame(_userStorage.GetLastLevelNumber()))
            _glueCreator.Create();

        GenerateMaze();
        yield return new WaitForSeconds(0.55f);

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

        Debug.Log("StarSpawn");
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
        _mazeEngine.SetSize(_levelCurrent.GetMazeSizeX(), _levelCurrent.GetMazeSizeY());
        _mazeEngine.generateMaze();
    }

    private void CreateTraps()
    {
        if (_obstracleSpawn.Count == 0)
            throw new ArgumentNullException(nameof(_obstracleSpawn));

        for (int i = 0; i < _levelCurrent.GetTrapsCount(); i++)
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

        for (int i = 0; i < _levelCurrent.GetStarCountInMaze(); i++)
        {
            EnviromentObjectSpawn[] freeStars = _starsSpawn.Where(obst => obst.IsActive == false).ToArray();
            int randomIndex = Random.Range(0, freeStars.Length);
            freeStars[randomIndex].On();
        }
    }
}