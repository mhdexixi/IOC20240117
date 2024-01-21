using UnityEngine;
using UnityEngine.Tilemaps;

public class Config:MonoSingleton<Config>
{
    #region 地图相关

    //区块大小
    public int ChunkSize = 32;

    //地图Tiles
    public TileBase[] tilesDefault;
    
    //出生位置
    public Vector3Int RandomBirthChunkPos()
    {
        return new Vector3Int(Random.Range(1000,9999), Random.Range(1000,9999));
    }    

    #endregion

    #region 角色相关

    //角色移动速度
    public float moveSpeed = 10;

    #endregion
}
