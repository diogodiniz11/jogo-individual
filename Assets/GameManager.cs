using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Tempo")]
    public float tempoTotal = 60f;
    private float tempoRestante;
    private bool jogoAtivo = true;

    [Header("Score")]
    public int score = 0;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        tempoRestante = tempoTotal;
    }

    void Update()
    {
        if (!jogoAtivo) return;

        tempoRestante -= Time.deltaTime;

        if (tempoRestante <= 0)
        {
            tempoRestante = 0;
            GameOver();
        }

        if (UIManager.Instance != null)
            UIManager.Instance.AtualizarTempo(tempoRestante);
    }

    public void AdicionarScore(int pontos)
    {
        score += pontos;
        if (UIManager.Instance != null)
            UIManager.Instance.AtualizarScore(score);
    }

    public void GameOver()
    {
        if (!jogoAtivo) return;

        jogoAtivo = false;
        PlayerPrefs.SetFloat("TempoRestante", tempoRestante);
        PlayerPrefs.SetInt("ScoreFinal", score);
        Invoke(nameof(CarregarGameOver), 1f);
    }

    void CarregarGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}