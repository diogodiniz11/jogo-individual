using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [Header("Moeda")]
    public GameObject moedaPrefab;

    [Header("Limites da tela")]
    public float xMin = -3f;
    public float xMax = 3f;
    public float yMin = -1f;
    public float yMax = 1f;

    void OnEnable()
    {
        GerarMoeda();
    }

    void Update()
    {
        // Verifica se não existe nenhuma moeda na cena
        if (GameObject.FindGameObjectWithTag("Coletar") == null)
        {
            GerarMoeda();
        }
    }

    void GerarMoeda()
    {
        float x = Random.Range(xMin, xMax);
        float y = Random.Range(yMin, yMax);
        Vector2 posicao = new Vector2(x, y);
        Instantiate(moedaPrefab, posicao, Quaternion.identity);
    }
}