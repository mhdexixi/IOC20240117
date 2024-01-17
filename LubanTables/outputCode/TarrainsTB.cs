
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;
using SimpleJSON;


namespace cfg
{
public sealed partial class TarrainsTB : Luban.BeanBase
{
    public TarrainsTB(JSONNode _buf) 
    {
        { if(!_buf["id"].IsNumber) { throw new SerializationException(); }  Id = _buf["id"]; }
        { if(!_buf["height"].IsNumber) { throw new SerializationException(); }  Height = _buf["height"]; }
        { if(!_buf["tiles"].IsString) { throw new SerializationException(); }  Tiles = _buf["tiles"]; }
        { if(!_buf["desc"].IsString) { throw new SerializationException(); }  Desc = _buf["desc"]; }
    }

    public static TarrainsTB DeserializeTarrainsTB(JSONNode _buf)
    {
        return new TarrainsTB(_buf);
    }

    /// <summary>
    /// ID
    /// </summary>
    public readonly int Id;
    /// <summary>
    /// 海拔
    /// </summary>
    public readonly float Height;
    /// <summary>
    /// 贴图名称
    /// </summary>
    public readonly string Tiles;
    /// <summary>
    /// 描述
    /// </summary>
    public readonly string Desc;
   
    public const int __ID__ = -766181656;
    public override int GetTypeId() => __ID__;

    public  void ResolveRef(Tables tables)
    {
        
        
        
        
    }

    public override string ToString()
    {
        return "{ "
        + "id:" + Id + ","
        + "height:" + Height + ","
        + "tiles:" + Tiles + ","
        + "desc:" + Desc + ","
        + "}";
    }
}

}