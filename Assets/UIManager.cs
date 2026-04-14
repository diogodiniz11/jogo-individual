using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Textos UI")]
    public TextMeshProUGUI textoTempo;
    public TextMeshProUGUI textoScore;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AtualizarTempo(float segundos)
    {
        int mins = Mathf.FloorToInt(segundos / 60);
        int secs = Mathf.FloorToInt(segundos % 60);
        textoTempo.text = $"Tempo: {mins:00}:{secs:00}";

        // Fica vermelho quando está acabando
        textoTempo.color = segundos <= 10f ? Color.red : Color.white;
    }

    public void AtualizarScore(int score)
    {
        textoScore.text = $"Score: {score}";
    }
}