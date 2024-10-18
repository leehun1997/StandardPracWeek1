using System.Net.Sockets;
using TMPro;
using UnityEngine;

public class RocketDashBoard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentScoreTxt;
    [SerializeField] private TextMeshProUGUI HighScoreTxt;

    private DataManger dataManger;

    float currentScore;


    private void Awake()
    {
        dataManger = FindAnyObjectByType<DataManger>();
    }
    private void Start()
    {
        HighScoreTxt.text = $"{dataManger.HighScore}";
    }

    private void Update()
    {
        currentScore = transform.position.y;
        currentScoreTxt.text = $"{currentScore}";

        if (currentScore > dataManger.HighScore)
        {
            HighScoreTxt.text = currentScoreTxt.text;
        }
    }
    public void SaveHighScore()
    {
        if (currentScore > dataManger.HighScore)
            dataManger.HighScore = currentScore;
    }
}