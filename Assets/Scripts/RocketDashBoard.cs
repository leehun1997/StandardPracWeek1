using System.Net.Sockets;
using TMPro;
using UnityEngine;

public class RocketDashBoard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentScoreTxt;
    [SerializeField] private TextMeshProUGUI HighScoreTxt;

    private DataManger dataManger;

    float currentScore;
    float highScore;


    private void Awake()
    {
        dataManger = FindAnyObjectByType<DataManger>();
    }
    private void Start()
    {
        highScore = dataManger.HighScore;
        HighScoreTxt.text = $"{highScore}";
    }

    private void Update()
    {
        currentScore = transform.position.y;
        currentScoreTxt.text = $"{currentScore}";

        if (currentScore > highScore)
        {
            HighScoreTxt.text = currentScoreTxt.text;
        }
    }
    public void SaveHighScore()
    {
        if (currentScore > highScore)
            dataManger.HighScore = currentScore;
    }
}