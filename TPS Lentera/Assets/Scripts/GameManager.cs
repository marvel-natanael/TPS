using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private GameObject _enemies;
    [SerializeField]
    private TextMeshProUGUI _loseText;
    [SerializeField]
    private TextMeshProUGUI _healthText;
    [SerializeField]
    private TextMeshProUGUI _winText;

    private void OnEnable()
    {
        PlayerController.onPlayerDied += OnLoseGame;
    }

    private void OnDisable()
    {
        PlayerController.onPlayerDied -= OnLoseGame;
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        _loseText.gameObject.SetActive(false);
        _winText.gameObject.SetActive(false);
    }

    void Update()
    {
        int playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().GetHealth();
        _healthText.text = "Health: " + playerHealth;
        
        int enemyAmount = _enemies.transform.childCount;
        if (enemyAmount <= 0)
        {
            OnWinGame();
        }
    }

    private void OnLoseGame()
    {
        _loseText.gameObject.SetActive(true);
        StartCoroutine(RestartGame());
    }

    private void OnWinGame()
    {
        _winText.gameObject.SetActive(true);
        StartCoroutine(RestartGame());
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(3f);
        string scene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(scene);
    }
}
