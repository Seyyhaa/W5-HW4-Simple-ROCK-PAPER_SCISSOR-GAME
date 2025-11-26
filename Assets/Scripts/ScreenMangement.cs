using UnityEngine;
using UnityEngine.SceneManagement; 

public class MyLevelLoader : MonoBehaviour
{

    public void LoadGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    
    public void LoadMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
    
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}