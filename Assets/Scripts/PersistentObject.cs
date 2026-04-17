using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentObject : MonoBehaviour
{
    public static string staticPublicDebugText = "";
    private static string staticPrivateDebugText = "";
    private string instancePrivateDebugText = "instance private";
    public string instancePublicDebugText = "instance public";

    private static PersistentObject staticInstance;

    public static PersistentObject GetInstance()
    {
        return staticInstance;
    }

    public static PersistentObject Instance
    { 
        get { return staticInstance; } 
    }

    void Awake()
    {
        if (staticInstance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        staticInstance = this;
    }

    void Start()
    {
        staticPublicDebugText = "Hello (public)";
        staticPrivateDebugText = "Hello (private)";
        StartCoroutine(Loop());

        Debug.Log(GameSetting.difficulty);
        Debug.Log(GameSetting.GetapiKey());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Load Scene Singleton02");
            SceneManager.LoadScene("Singleton02");
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(gameObject);
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            staticPrivateDebugText += "K";
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            GameSetting.difficulty++;
        }
    }

    IEnumerator Loop()
    {
        while (true)
        {
            Debug.Log($"static - publicDebugText: {staticPublicDebugText}");
            Debug.Log($"static - privateDebugText: {staticPrivateDebugText}");
            Debug.Log($"instance - publicDebugText: {instancePublicDebugText}");
            Debug.Log($"instance - privateDebugText: {instancePrivateDebugText}");
            yield return new WaitForSeconds(1);
        }
    }

    public static void SetStaticPrivateText(string text)
    {
        staticPrivateDebugText = text;
    }

    public void SetInstancePrivateText(string text)
    {
        instancePrivateDebugText = text;
    }

}
