using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollisionController : MonoBehaviour
{
    [SerializeField] private Text coinText;
    [SerializeField] private float timeDestroy=3f;
    [SerializeField] private ParticleSystem particleDestroy;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private Text loseScoreText;
    [SerializeField] private Text gameScoreText;
    private int currentCoin = 0;

    private void Start()
    {
        Time.timeScale = 1f;
        losePanel.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("let"))
        {
            StartCoroutine(DestroyPlayer());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("coin"))
        {
            Destroy(other.gameObject);
            currentCoin++;
            coinText.text=currentCoin.ToString();
        }
    }
    IEnumerator DestroyPlayer()
    {
        Instantiate(particleDestroy, this.transform);
        yield return new WaitForSeconds(timeDestroy);
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + currentCoin);
        losePanel.SetActive(true);
        loseScoreText.text = gameScoreText.text;
        gamePanel.SetActive(false);
        Time.timeScale = 0f;
    }
}
