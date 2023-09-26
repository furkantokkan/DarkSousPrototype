using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldSaveGameManager : MonoBehaviour
{
    public static WorldSaveGameManager instance;

    [SerializeField] private int worldSceneIndex = 1;

    public int WorldSceneIndex { get { return worldSceneIndex; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Default value only load world scene
    /// </summary>
    public void LoadNewScene()
    {
        StartCoroutine(LoadScene(worldSceneIndex));
    }

    /// <summary>
    /// Load the given ýndex
    /// </summary>
    /// <param name="index"></param>
    public void LoadNewScene(int index)
    {
        StartCoroutine(LoadScene(index));
    }

    IEnumerator LoadScene(int Index)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(Index);

        yield return null;
    }
}
