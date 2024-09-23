using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConfigurationUtils
{
    public static float SawSpeed
    {
        get { return LevelConfiguration().SawSpeed; }
    }
    public static int SawSpawnMin
    {
        get { return LevelConfiguration().SawSpawnMin; }
    }
    public static int SawSpawnMax
    {
        get { return LevelConfiguration().SawSpawnMax; }
    }
    public static float SawSpawnFrequency
    {
        get { return LevelConfiguration().SawSpawnFrequency; }
    }
    public static float EnemySpawnTimeMin
    {
        get { return LevelConfiguration().EnemySpawnTimeMin; }
    }
    public static float EnemySpawnTimeMax
    {
        get { return LevelConfiguration().EnemySpawnTimeMax; }
    }
    public static float MushroomSpeed
    {
        get { return LevelConfiguration().MushroomSpeed; }
    }
    public static float RabbitSpeed
    {
        get { return LevelConfiguration().RabbitSpeed; }
    }
    public static float SnailSpeed
    {
        get { return LevelConfiguration().SnailSpeed; }
    }
    public static int MushroomHealth
    {
        get { return LevelConfiguration().MushroomHealth; }
    }
    public static int RabbitHealth
    {
        get { return LevelConfiguration().RabbitHealth; }
    }
    public static int SnailHealth
    {
        get { return LevelConfiguration().SnailHealth; }
    }
    public static int BossHealth
    {
        get { return LevelConfiguration().BossHealth; }
    }
    public static float BossTime
    {
        get { return LevelConfiguration().BossTime; }
    }
    public static float HalfGroundColliderHeight
    {
        get
        {
            return GroundSpawner().HalfGroundCollider();
        }
    }
    public static Vector2 GroundPosition
    {
        get
        {
            return GroundSpawner().GroundPosition();
        }
    }

    static LevelConfiguration LevelConfiguration()
    {
        return Camera.main.GetComponent<LevelConfiguration>();
    }
    static GroundSpawner GroundSpawner()
    {
        return Camera.main.GetComponent<GroundSpawner>();
    }
}
