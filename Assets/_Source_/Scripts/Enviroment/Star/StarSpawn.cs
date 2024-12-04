public class StarSpawn : EnviromentObjectSpawn
{
    protected override void InitOnLevel()
    {
        InitLevel.AddStarSpawn(this);
    }
}