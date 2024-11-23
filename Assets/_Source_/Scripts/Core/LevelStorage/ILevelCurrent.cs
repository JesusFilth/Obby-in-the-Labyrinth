using System;

public interface ILevelCurrent
{
    void InitGame(int level);
    int GetTrapsCount();
    int GetStarCountInMaze();
    int GetMazeSizeX();
    int GetMazeSizeY();

    int GetCurrentLevel();
    int GetCurrentMaze();
    int GetCurrentStars();
}
