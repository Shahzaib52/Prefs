using UnityEngine;
using Newtonsoft.Json;

public static class Prefs
{
    #region Where Magic Happens
    private static T Deserialize<T>(string baseKey, T defaultValue, bool debug = false)
    {
        var value = JsonConvert.DeserializeObject<T>(PlayerPrefs.GetString(baseKey, JsonConvert.SerializeObject(defaultValue)));
        if (debug) Debug.Log($"{baseKey} Value: {value}");
        return value;
    }
    private static string Serialize<T>(string baseKey, T value, bool debug = false)
    {
        var serialized = JsonConvert.SerializeObject(value);
        PlayerPrefs.SetString(baseKey, serialized);
        if (debug) Debug.Log($"{baseKey} Value: {value}");
        return serialized;
    }
    #endregion

    #region Methods
    public static void SetInt(string baseKey, int value, bool debug = false) => Serialize(baseKey, value, debug);
    public static void SetFloat(string baseKey, float value, bool debug = false) => Serialize(baseKey, value, debug);
    public static void SetObject<T>(string baseKey, T value, bool debug = false) => Serialize(baseKey, value, debug);
    public static void SetColor(string baseKey, Color value, bool debug = false) => Serialize(baseKey, value, debug);
    public static void SetString(string baseKey, string value, bool debug = false) => Serialize(baseKey, value, debug);
    public static void SetVector3(string baseKey, Vector3 value, bool debug = false) => Serialize(baseKey, value, debug);
    public static void SetVector2(string baseKey, Vector2 value, bool debug = false) => Serialize(baseKey, value, debug);
    public static void SetBool(string baseKey, bool value, bool debug = false) => Serialize(baseKey, value, debug);
    #endregion

    #region Properties
    public static int GetInt(string baseKey, int defaultValue = 0, bool debug = false) => Deserialize(baseKey, defaultValue, debug);
    public static float GetFloat(string baseKey, float defaultValue = 0, bool debug = false) => Deserialize(baseKey, defaultValue, debug);
    public static T GetObject<T>(string baseKey, T defaultValue, bool debug = false) => Deserialize(baseKey, defaultValue, debug);
    public static Color GetColor(string baseKey, Color defaultValue, bool debug = false) => Deserialize(baseKey, defaultValue, debug);
    public static string GetString(string baseKey, string defaultValue, bool debug = false) => Deserialize(baseKey, defaultValue, debug);
    public static Vector3 GetVector3(string baseKey, Vector3 defaultValue, bool debug = false) => Deserialize(baseKey, defaultValue, debug);
    public static Vector2 GetVector2(string baseKey, Vector2 defaultValue, bool debug = false) => Deserialize(baseKey, defaultValue, debug);
    public static bool GetBool(string baseKey, bool defaultValue, bool debug = false) => Deserialize(baseKey, defaultValue, debug);
    public static bool HasKey(string baseKey) => PlayerPrefs.HasKey(baseKey);
    #endregion
}
