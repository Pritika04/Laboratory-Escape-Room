using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class Entry : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   // Public function to load a scene by its name (string)
    public void LoadSceneByName(string testScene)
    {
        SceneManager.LoadScene(testScene);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
