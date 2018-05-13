using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    //static readonly Random random = new Random();

    public bool Boosting;
    public GameObject RightStarParticles;
    public GameObject LeftStarParticles;
    //public GameObject BoosterThrust;

    private ParticleSystem psRight;
    private ParticleSystem psLeft;
    //private ParticleSystemRenderer btMat;
    public static GameManager Instance;
    public GameObject player;
    public Material[] PlayerMaterials = new Material[4];
    public Material[] ObstacleMaterials = new Material[4];
    public float speed = 25f;
    public bool gameOver = false;
    public Text scoreText;
    public Text comboText;
    public GameObject particles;
    public int score = 0;
    public int highCombo = 0;
    public Material playerMaterial;

    private int scoreMultiplier = 0;
    private int currentCombo = 1;

    // Use this for initialization
    void Awake() // creating static instance of type GameManager
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(Instance);
        }

    }

    void Start()
    {
        psRight = RightStarParticles.GetComponent<ParticleSystem>();
        psLeft = LeftStarParticles.GetComponent<ParticleSystem>();
        //btMat = BoosterThrust.GetComponent<ParticleSystemRenderer>();
        InvokeRepeating("IncreaseScoreEverySecond", 1, 0.5f);
        GamePlayed();
        Debug.Log(ReturnGamesPlayed());
    }

    // Update is called once per frame

    void Update()
    {
        Boost();

        scoreText.text = "SCORE\n" + score.ToString();
        comboText.text = "COMBO\n" + " * " + currentCombo;

        if (speed < 99)
        {
            speed += Time.deltaTime / 5;
        }

    }

    private void IncreaseScoreEverySecond()
    {
        score++;
    }

    public void PlayerScored()
    {
        if (gameOver)
        {
            return;
        }

        currentCombo++;
        scoreMultiplier++;

    }

    public void BreakCombo()
    {
        if (currentCombo > highCombo)
        {
            highCombo = currentCombo;
        }
        SaveHighCombo(currentCombo);
        currentCombo *= scoreMultiplier;
        score += currentCombo;
        currentCombo = 1;
        scoreMultiplier = 0;
        AudioManager.Instance.comboNotesPosition = 0;
    }

    public IEnumerator PlayerDied()
    {
        BreakCombo();
        SaveHighScore(score);
        particles.SetActive(false);
        gameOver = true;
        CancelInvoke();
        yield return new WaitForSeconds(0.3f); //allows time for death particles animation

        float fadeTime = GameObject.Find("FaderScript").GetComponent<Fade>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("GameOver");
    }

    public Material AssignObstacleColor(Material[] materials)
    {
        return materials[Random.Range(0, materials.Length)];
    }

    public Material AssignPlayerColor(Material[] materials)
    {

        return materials[Random.Range(0, materials.Length)];
    }

    public void Boost()
    {
        var Rmain = psRight.main;
        var Lmain = psLeft.main;
        var Rtrails = psRight.trails;
        var Ltrails = psLeft.trails;

        if (Boosting)
        {
            Rmain.startSpeed = 20;
            Lmain.startSpeed = 20;

            Rtrails.sizeAffectsWidth = false;
            Rtrails.sizeAffectsLifetime = false;
            Ltrails.sizeAffectsWidth = false;
            Ltrails.sizeAffectsLifetime = false;

            //btMat.material.color = new Color32(0, 136, 218, 1);
        }
        else
        {
            Rmain.startSpeed = 5;
            Lmain.startSpeed = 5;

            Rtrails.sizeAffectsWidth = true;
            Rtrails.sizeAffectsLifetime = true;
            Ltrails.sizeAffectsWidth = true;
            Ltrails.sizeAffectsLifetime = true;

            //btMat.material.color = new Color32(9, 27, 38, 1);
        }
    }

    #region PLAYERPREFS
    public void SaveHighScore(int score)
    {
        if (PlayerPrefs.GetInt("HighScore") < score)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
    public int ReturnHighScore()
    {
        return PlayerPrefs.GetInt("HighScore");
    }
    public void SaveHighCombo(int combo)
    {
        if (PlayerPrefs.GetInt("HighCombo") < combo)
        {
            PlayerPrefs.SetInt("HighCombo", combo);
        }
    }
    public int ReturnHighCombo()
    {
        return PlayerPrefs.GetInt("HighCombo");
    }
    public void GamePlayed()
    {
        PlayerPrefs.SetInt("GamesPlayed", PlayerPrefs.GetInt("GamesPlayed") + 1);
    }
    public int ReturnGamesPlayed()
    {
        return PlayerPrefs.GetInt("GamesPlayed");
    }

    #endregion
}