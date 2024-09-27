public class ObstracleSpawn : EnviromentObjectSpawn
{
    protected override void InitOnLevel()
    {
        InitLevel.AddObstracleSpawn(this);
    }
}