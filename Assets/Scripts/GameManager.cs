using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool gameHasEnding = false;

    public float restartDelay = 2f;

    public GameObject comletelevelUI;

    public void CompleteLevel()
    {
        comletelevelUI.SetActive(true);
    }

    public void EndGame()
    {
        if (gameHasEnding == false)
        {
            gameHasEnding = true;
            Debug.Log("GAME OVER");
            Invoke("Restart", restartDelay);
        }
        
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
