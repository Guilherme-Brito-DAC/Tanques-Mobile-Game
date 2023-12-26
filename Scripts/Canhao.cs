using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canhao : MonoBehaviour
{
    public GameObject bala;

    public float VelocidadeDeTiro;

    public bool AtirarTriplo;

    void Start()
    {
        AtirarTriplo = false;

        StartCoroutine(Atirar());
    }

    void Update()
    {

    }

    IEnumerator Atirar()
    {
        while (true)
        {
            if (AtirarTriplo)
            {
                Quaternion quaternionNovaBala1 = new Quaternion(-25f, 180f, 0f, 0);

                Quaternion quaternionNovaBala2 = new Quaternion(25f, 180f, 0f, 0);

                GameObject novaBala1 = Instantiate(bala, transform.position, quaternionNovaBala1);

                GameObject novaBala2 = Instantiate(bala, transform.position, quaternionNovaBala2);
            }

            GameObject novaBala = Instantiate(bala, transform.position, Quaternion.identity);

            yield return new WaitForSeconds(VelocidadeDeTiro);
        }
    }
}
