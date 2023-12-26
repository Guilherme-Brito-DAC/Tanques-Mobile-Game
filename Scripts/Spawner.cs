using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public GameObject inimigoPrefab;
    public GameObject atirarMaisRapidoPrefab;
    public GameObject atirarTriploPrefab;

    void Start()
    {
        StartCoroutine(SpawnarBonus());

        StartCoroutine(SpawnarInimigos());
    }

    IEnumerator SpawnarInimigos()
    {
        while (true)
        {
            Instantiate(inimigoPrefab, GerarPosicaoRandomica(), new Quaternion(180f, 0, 0, 0));

            yield return new WaitForSeconds(0.8f);
        }
    }

    IEnumerator SpawnarBonus()
    {
        while (true)
        {
            float proximoTempo = Random.Range(4f, 10f);

            if (Random.value > 0.5f)
                Instantiate(atirarMaisRapidoPrefab, GerarPosicaoRandomica(), new Quaternion(180f, 0, 0, 0));
            else
                Instantiate(atirarTriploPrefab, GerarPosicaoRandomica(), new Quaternion(180f, 0, 0, 0));

            yield return new WaitForSeconds(proximoTempo);
        }
    }

    #region [Particulares]
    private Vector3 GerarPosicaoRandomica()
    {
        Vector3 posicaoInicial = transform.position;

        float x = posicaoInicial.x + Random.Range(-2.6f, 2.6f);

        return new Vector3(x, posicaoInicial.y, posicaoInicial.z);
    }
    #endregion
}
