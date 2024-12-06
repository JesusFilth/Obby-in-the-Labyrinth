public interface ILevelNavigation
{
    void NextMaze();
    void NextLevel();
    void RestartLevel();
    void OpenLevel(int levelNumber);
    bool IsLastMazeLevel();
}