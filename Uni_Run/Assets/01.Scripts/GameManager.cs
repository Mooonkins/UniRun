using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameover = false;
    public TextMeshProUGUI scoreText;
    public GameObject gameoverUI;

    private int score = 0;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;            
        }
        else
        {
            Debug.LogWarning("���� �ΰ� �̻��� ���ӸŴ����� �ֽ��ϴ�.");
            Destroy(gameObject);
        }
    }    
    void Update()
    {
        if(isGameover && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void AddScore(int newScore)
    {
        if (!isGameover)
        {
            score += newScore;
            scoreText.text = "Score : " + score;
        }
    }
    public void OnPlayerDead()
    {
        isGameover = true;
        gameoverUI.SetActive(true);
    }
}
