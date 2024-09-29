using System;

public interface ILevelStars
{
    event Action<int> StarsChanged;
    event Action<LevelStarModel[]> StarsModelChanged;
    void AddStar(int count);
    void UpdateStars();
}