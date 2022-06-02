using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Text scoreText;
    private int score = 0; 

    public void EarnPoints(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }
}
