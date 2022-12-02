using UnityEngine;
using TMPro;

public class DisplayScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI oversText;

    public void UpdateScore(Innings innings)
    {
        scoreText.text = innings.Score + "/" + innings.Wickets;
        oversText.text = innings.Overs.ToString();
    }
}
