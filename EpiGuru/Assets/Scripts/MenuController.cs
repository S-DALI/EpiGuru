using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Text allCoinsText;
    private void Start()
    {
        allCoinsText.text = PlayerPrefs.GetInt("coins").ToString();
    }
    public void StartEvent()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitEvent()
    {
        Application.Quit();
    }
}
