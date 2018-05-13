using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public Text scoreText;
    public Text comboText;
    public Text highScoreText;
    public Text highComboText;

	// Use this for initialization
	void Start ()
    {
        scoreText.text = GameManager.Instance.score.ToString();
        comboText.text = GameManager.Instance.highCombo.ToString();
        highScoreText.text = GameManager.Instance.ReturnHighScore().ToString();
        highComboText.text = GameManager.Instance.ReturnHighCombo().ToString();
	}
	
}
