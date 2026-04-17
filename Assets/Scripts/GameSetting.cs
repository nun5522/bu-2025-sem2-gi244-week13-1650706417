using UnityEngine;

public class GameSetting
{
    public static bool enableShadow;
    public static float globalGravity;
    public static int difficulty;

    private static string apiKey = "12345667";

    public static string GetapiKey()
    {
        return apiKey;
    }
}
