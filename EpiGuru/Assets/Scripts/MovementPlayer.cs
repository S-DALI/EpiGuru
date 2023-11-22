using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float start = 5f;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text timerText;

    private float score;
    private Rigidbody rigidbodyPlayer;
    private bool gameStart;

    private void Start()
    {
        if(GetComponent<Rigidbody>() != null)
            rigidbodyPlayer = GetComponent<Rigidbody>();
        gameStart = false;
        StartCoroutine(StartGame());
        score = 0;
    }

    private void Update()
    {
        if (gameStart)
        {
            Vector3 currentVelocity = rigidbodyPlayer.velocity;
            Vector3 forwardVelocity = transform.forward * speed;

            currentVelocity = new Vector3(forwardVelocity.x, currentVelocity.y, forwardVelocity.z);

            rigidbodyPlayer.velocity = currentVelocity;

            score += Time.deltaTime * speed;
            scoreText.text=((int)score).ToString();
        }
    }
    IEnumerator StartGame()
    {
        timerText.text = "Ready";
        yield return new WaitForSeconds(start);
        timerText.text = "Start";
        yield return new WaitForSeconds(1);
        gameStart = true;
        timerText.text = "";
    }
}
