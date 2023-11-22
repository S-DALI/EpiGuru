using UnityEngine;
using UnityEngine.SceneManagement;
public class GameUIController : MonoBehaviour
{
    [SerializeField] private GameObject gameUIPanel;
    [SerializeField] private GameObject pauseUIPanel;
    void Start()
    {
        gameUIPanel.SetActive(true);
        pauseUIPanel.SetActive(false);
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        gameUIPanel.SetActive(false);
        pauseUIPanel.SetActive(true);
    }
    public void Continue()
    {
        Time.timeScale = 1f;
        gameUIPanel.SetActive(true);
        pauseUIPanel.SetActive(false);
    }
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
