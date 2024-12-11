using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI GameRestartText;
    public TextMeshProUGUI YouWinText; // Reference to "You Win" text UI
    private int score;

    public Transform dog; // Reference to the dog's transform
    public Transform farmer; // Reference to the farmer's transform
    public float winDistance = 2f; // Distance at which the dog reaches the farmer

    // Start is called before the first frame update
    void Start()
    {
        score = 0; // Initialize the score
        scoreText.text = "Score: " + score; // Update the score UI
        GameRestartText.gameObject.SetActive(false); // Ensure Game Restart text is hidden initially
        YouWinText.gameObject.SetActive(false); // Ensure "You Win!" text is hidden initially
    }

    public void UpdateScore(int scoreToAdd)
    {
        // Increase the score
        score += scoreToAdd;
        scoreText.text = "Score = " + score; // Update the score UI
    }

    public void GameOver()
    {
        // Show the Game Over text
        GameRestartText.gameObject.SetActive(true);

        // Hide the "Game Restart" text after a short delay
        StartCoroutine(HideGameRestartText());
    }

    private IEnumerator HideGameRestartText()
    {
        // Wait for 2 seconds and then hide the "Game Restart" text
        yield return new WaitForSeconds(2f);
        GameRestartText.gameObject.SetActive(false);
    }

    public void DisplayWinText()
    {
        // Show the "You Win!" text
        YouWinText.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the dog is close enough to the farmer
        if (Vector3.Distance(dog.position, farmer.position) <= winDistance)
        {
            DisplayWinText(); // Show "You Win!" text when dog reaches the farmer
        }
    }
}


