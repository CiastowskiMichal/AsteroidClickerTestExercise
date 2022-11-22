using System.Collections.Generic;
using System.Linq;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    [SerializeField]
    AsteroidController asteroidBase;
    [SerializeField]
    ScoreController scoreController;
    private int score = 0;
    private List<AsteroidController> asteroids = new List<AsteroidController>();
    private float timeToUpdate = 0.3f;
    private float timeToUpdateOriginal = 0.3f;
    [SerializeField]
    GameObject endGamePanel;
    [SerializeField]
    GameObject startGamePanel;
    private bool endGame = true;
    private Ray ray;
    private RaycastHit hit;

    private readonly Timer timer = new Timer();

    void Start()
    {
        endGamePanel.SetActive(false);
        startGamePanel.SetActive(true);
        endGame = true;

        timer.Interval = 200;
        timer.Elapsed += delegate {
            timer.Stop();
        };
    }

    void Update()
    {
        CheckWinGame();
        UpdateAsteroids();
        MouseClickDetection();
    }

    void InitScene()
    {
        for (int i = 0; i < 10; i++)
        {
            asteroidBase.InitAsteroid();
            if (i < 5)
            {
                asteroidBase.gameObject.SetActive(false);
            }
            asteroids.Add(Instantiate(asteroidBase, Utils.GetRandomPosition(), Utils.GetRandomRotation()));
        }
    }

    public void RestartGame()
    {
        score = 0;
        scoreController.SetScore(score);

        foreach (AsteroidController asteroid in asteroids)
        {
            asteroid.InitAsteroid();
            if (asteroids.IndexOf(asteroid) < 5)
            {
                asteroid.gameObject.SetActive(false);
            }
        }

        endGamePanel.SetActive(false);
        endGame = false;
    }

    public void StartGame()
    {
        InitScene();
        endGame = false;
        startGamePanel.SetActive(false);
    }

    void MouseClickDetection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (timer.Enabled == false)
            {
                timer.Start();
                return;
            }
            else
            {
                timer.Stop();
                ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit)
                    && hit.collider.CompareTag("Asteroid")
                    && hit.collider.GetComponent<AsteroidController>().IsDestroyed())
                {
                    scoreController.SetScore(++score);
                    hit.collider.gameObject.SetActive(false);
                }
            }
        }
    }

    void UpdateAsteroids()
    {
        if (!endGame)
        {
            timeToUpdate -= Time.deltaTime;
            if (timeToUpdate < 0f)
            {
                timeToUpdate = timeToUpdateOriginal;
                if (asteroids.Where(x => x.gameObject.activeSelf == false).Count() > 0)
                {
                    asteroids.Where(x => x.gameObject.activeSelf == false).First().RespawnAsteroid();
                }
            }
        }
    }

    void CheckWinGame()
    {
        if (score >= 15)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        endGamePanel.SetActive(true);
        endGame = true;
        foreach (AsteroidController asteroid in asteroids)
        {
            asteroid.gameObject.SetActive(false);
        }
    }
}
