using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public int playerLives;
    public Text livesText;
    public int playerScore;
    public Text scoreText;

    public void RemoveLives()
    {
        playerLives--;
        livesText.text = playerLives.ToString();
    }
}
