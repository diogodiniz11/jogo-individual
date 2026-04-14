using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [Header("Movimento")]
    public float velocidade = 3f;

    private Transform jogador;

    void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Play").transform;
    }

    void Update()
    {
        if (jogador == null) return;

        transform.position = Vector2.MoveTowards(
            transform.position,
            jogador.position,
            velocidade * Time.deltaTime
        );
    }

    void OnCollisionEnter2D(Collision2D outro)
    {
        if (outro.gameObject.CompareTag("Play"))
        {
            GameManager.Instance.GameOver();
        }
    }
}