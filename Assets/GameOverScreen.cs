using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI textoTempoFinal;
    public TextMeshProUGUI textoScoreFinal;

    void Start()
    {
        float tempo = PlayerPrefs.GetFloat("TempoRestante", 0f);
        int score = PlayerPrefs.GetInt("ScoreFinal", 0);

        int mins = Mathf.FloorToInt(tempo / 60);
        int secs = Mathf.FloorToInt(tempo % 60);

        textoTempoFinal.text = $"Tempo restante: {mins:00}:{secs:00}";
        textoScoreFinal.text = $"Score final: {score}";
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene("SampleScene");
    }
}