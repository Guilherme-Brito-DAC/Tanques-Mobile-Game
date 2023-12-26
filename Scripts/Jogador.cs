using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    public float velocidadeDeMovimento = 5f;
    public Canhao canhao;
    private Coroutine removerTiroTriplo;
    private Coroutine removerTiroMaisRapido;

    void Start()
    {

    }

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");

        Vector3 novaPosicao = transform.position + new Vector3(inputX * velocidadeDeMovimento * Time.deltaTime, 0, 0);

        float x = Mathf.Clamp(novaPosicao.x, -2.6f, 2.6f);

        transform.position = new Vector3(x, novaPosicao.y, novaPosicao.z);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.tag == "Inimigo")
        //{
        //    _pontuacao.text = (int.Parse(_pontuacao.text) + 10).ToString();

        //    Destroy(other.gameObject);
        //    Destroy(gameObject);
        //}

        if (other.tag == "AtirarMaisRapido")
        {
            float velocidadeAtual = canhao.VelocidadeDeTiro;

            if ((velocidadeAtual -= 0.2f) > 0.2f)
            {
                canhao.VelocidadeDeTiro -= 0.2f;

                if (removerTiroMaisRapido != null)
                    ResetarCountdownTiroRapido();

                removerTiroMaisRapido = StartCoroutine(RemoverTiroRapido());
            }
            else
            {
                ResetarCountdownTiroRapido();
            }

            Destroy(other.gameObject);
        }
        else if (other.tag == "AtirarTriplo")
        {
            if (!canhao.AtirarTriplo)
            {
                canhao.AtirarTriplo = true;

                if (removerTiroTriplo != null)
                    ResetarCountdownTiroTriplo();

                removerTiroTriplo = StartCoroutine(RemoverTiroTriplo());
            }
            else
            {
                ResetarCountdownTiroTriplo();
            }

            Destroy(other.gameObject);
        }
    }

    void ResetarCountdownTiroTriplo()
    {
        if (removerTiroTriplo != null)
        {
            StopCoroutine(removerTiroTriplo);
        }

        removerTiroTriplo = StartCoroutine(RemoverTiroTriplo());
    }

    IEnumerator RemoverTiroTriplo()
    {
        yield return new WaitForSeconds(16f);

        canhao.AtirarTriplo = false;
    }

    void ResetarCountdownTiroRapido()
    {
        if (removerTiroMaisRapido != null)
        {
            StopCoroutine(removerTiroMaisRapido);
        }

        removerTiroMaisRapido = StartCoroutine(RemoverTiroRapido());
    }

    IEnumerator RemoverTiroRapido()
    { 
        yield return new WaitForSeconds(16f);

        float velocidadeAtual = canhao.VelocidadeDeTiro;

        if ((velocidadeAtual += 0.2f) <= 1f)
            canhao.VelocidadeDeTiro += 0.2f;
    }
}
