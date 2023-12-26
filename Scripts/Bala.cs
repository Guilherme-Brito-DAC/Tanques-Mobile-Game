using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bala : MonoBehaviour
{
    public float velocidade = 10f;
    private Text _pontuacao;

    void Start()
    {
        _pontuacao = FindObjectOfType<Text>();
    }

    void Update()
    {
        transform.Translate(Vector3.up * velocidade * Time.deltaTime);

        if (!EstaNaTela())
        {
            Destroy(gameObject);
        }
    }

    bool EstaNaTela()
    {
        Vector3 tela = Camera.main.WorldToViewportPoint(transform.position);

        return tela.x > 0 && tela.x < 1 && tela.y > 0 && tela.y < 1;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Inimigo")
        {
            _pontuacao.text = (int.Parse(_pontuacao.text) + 10).ToString();

            Destroy(other.gameObject); 
            Destroy(gameObject); 
        }
    }
}
