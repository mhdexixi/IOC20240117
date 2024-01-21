using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;
using Vector3Int = UnityEngine.Vector3Int;

public class MB_StartGame : MonoBehaviour
{
    //定义出生坐标
    Vector3Int birthChunkPos;
    Vector3Int birthWorldPos;
    void Awake()
    {
        //赋值出生坐标
        birthChunkPos = Config.Instance.RandomBirthChunkPos();
        //初始化出生地图
        InitBirthMap(birthChunkPos);
        //初始化九宫格出生地图
        InitBirthMap8(birthChunkPos);
        //初始化角色
        InitCharacter();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    #region 初始化出生地图
    
    void InitBirthMap(Vector3Int birthChunkPos)
    {
        birthWorldPos = new Vector3Int(birthChunkPos.x * 32, birthChunkPos.y * 32);
        //新建tilemap
        GameObject objTilemap = new GameObject("tilemap(" + birthChunkPos.x + "," + birthChunkPos.y + ")");
        objTilemap.AddComponent<Tilemap>();
        objTilemap.AddComponent<TilemapRenderer>();
        objTilemap.transform.position = birthWorldPos;
        objTilemap.transform.SetParent(GameObject.Find("Grid").transform);
        
        //绘制Tiles
        Tilemap tilemap = objTilemap.GetComponent<Tilemap>();
        TileBase[] tiles = Config.Instance.tilesDefault;
        AddTiles(tilemap,tiles);
    }

    void AddTiles(Tilemap tilemap,TileBase[] tiles)
    {
        for (int x = 0; x < Config.Instance.ChunkSize; x++)
        {
            for (int y = 0; y < Config.Instance.ChunkSize; y++)
            {
                tilemap.SetTile(new Vector3Int(x-Config.Instance.ChunkSize/2,y-Config.Instance.ChunkSize/2),RandomTile(tiles));
            }
        }
    }

    TileBase RandomTile(TileBase[] tiles)
    {
        int l = tiles.Length;
        int n = Random.Range(0, l * 10);
        if (n<l)
        {
            return tiles[n];
        }
        else
        {
            return tiles[0];
        }
    }

    void InitBirthMap8(Vector3Int birthChunkPos)
    {
        InitBirthMap(new Vector3Int(birthChunkPos.x-1,birthChunkPos.y+1));
        InitBirthMap(new Vector3Int(birthChunkPos.x,birthChunkPos.y+1));
        InitBirthMap(new Vector3Int(birthChunkPos.x+1,birthChunkPos.y+1));
        InitBirthMap(new Vector3Int(birthChunkPos.x+1,birthChunkPos.y));
        InitBirthMap(new Vector3Int(birthChunkPos.x+1,birthChunkPos.y-1));
        InitBirthMap(new Vector3Int(birthChunkPos.x,birthChunkPos.y-1));
        InitBirthMap(new Vector3Int(birthChunkPos.x-1,birthChunkPos.y-1));
        InitBirthMap(new Vector3Int(birthChunkPos.x-1,birthChunkPos.y));
    }
    
    #endregion

    #region 初始化角色

    void InitCharacter()
    {
        birthWorldPos = new Vector3Int(birthChunkPos.x * 32, birthChunkPos.y * 32);
        GameObject.Find("Character").transform.position = birthWorldPos;
    }

    #endregion
}
