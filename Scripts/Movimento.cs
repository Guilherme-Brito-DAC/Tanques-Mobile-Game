using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    public float velocidade = 2f;

    void Start()
    {
        velocidade += Random.Range(-1f, 0.6f);
    }

    void Update()
    {
        transform.Translate(Vector3.up * velocidade * Time.deltaTime);

        if (PassouDaLinha())
        {
            Destroy(gameObject);
        }
    }

    bool PassouDaLinha()
    {
        Vector3 tela = Camera.main.WorldToViewportPoint(transform.position);

        return tela.y < 0;
    }
}
