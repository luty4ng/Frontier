//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;
using SimpleJSON;



namespace LubanConfig.DataTable
{

public sealed partial class GameConfig :  Bright.Config.BeanBase, System.ICloneable 
{
    public GameConfig(JSONNode _json) 
    {
        { if(!_json["is_david_dead"].IsBoolean) { throw new SerializationException(); }  IsDavidDead = _json["is_david_dead"]; }
        { if(!_json["is_rebellion_start"].IsBoolean) { throw new SerializationException(); }  IsRebellionStart = _json["is_rebellion_start"]; }
        { if(!_json["current_day"].IsNumber) { throw new SerializationException(); }  CurrentDay = _json["current_day"]; }
        { if(!_json["current_weekday"].IsNumber) { throw new SerializationException(); }  CurrentWeekday = _json["current_weekday"]; }
        { if(!_json["current_week"].IsNumber) { throw new SerializationException(); }  CurrentWeek = _json["current_week"]; }
        PostInit();
    }

    public GameConfig(bool is_david_dead, bool is_rebellion_start, int current_day, int current_weekday, int current_week ) 
    {
        this.IsDavidDead = is_david_dead;
        this.IsRebellionStart = is_rebellion_start;
        this.CurrentDay = current_day;
        this.CurrentWeekday = current_weekday;
        this.CurrentWeek = current_week;
        PostInit();
    }

    public static GameConfig DeserializeGameConfig(JSONNode _json)
    {
        return new DataTable.GameConfig(_json);
    }

    public bool IsDavidDead { get; private set; }
    public bool IsRebellionStart { get; private set; }
    public int CurrentDay { get; private set; }
    public int CurrentWeekday { get; private set; }
    public int CurrentWeek { get; private set; }

    public const int __ID__ = -2012855298;
    public override int GetTypeId() => __ID__;

    public  void Resolve(Dictionary<string, object> _tables)
    {
        PostResolve();
    }

    public  void TranslateText(System.Func<string, string, string> translator)
    {
    }

    public override string ToString()
    {
        return "{ "
        + "IsDavidDead:" + IsDavidDead + ","
        + "IsRebellionStart:" + IsRebellionStart + ","
        + "CurrentDay:" + CurrentDay + ","
        + "CurrentWeekday:" + CurrentWeekday + ","
        + "CurrentWeek:" + CurrentWeek + ","
        + "}";
    }

    public object Clone()
    {
        return new GameConfig(this.IsDavidDead, this.IsRebellionStart, this.CurrentDay, this.CurrentWeekday, this.CurrentWeek);
    }
    
    partial void PostInit();
    partial void PostResolve();
}
}
