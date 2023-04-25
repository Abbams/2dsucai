using UnityEngine;
using UnityEngine.UI;

public class scoreconl : MonoBehaviour
{
    public Text scoreText;
    private int scores;

    void Start()
    {
        scores = 0;
        scoreText.text = "Score: " + scores.ToString();
    }
    public void addscore()
        {
            scores+=5;
            scoreText.text = "Score: " + scores.ToString();
        }
void Update()
    {
        
    }
}