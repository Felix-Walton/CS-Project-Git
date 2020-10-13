using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int count;
    public Text scoreText;

    void Start()
    {
        count = 0; // set score to 0, this is a precausion that a score does not carry over
    }

    public void Point() //This function is called from an enemy when they die 
    {
        count += 1;
        scoreText.text = count.ToString("0"); //This displays the score to the overlay
    }
}
