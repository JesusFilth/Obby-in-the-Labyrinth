using System;

public interface ILevelStars
{
    event Action<int> StarsChanged;
    void AddStar(int count);
}