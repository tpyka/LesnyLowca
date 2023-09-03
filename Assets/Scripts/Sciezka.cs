using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sciezka : MonoBehaviour
{
    BeeSpawner beeSpawner;
    Fala ukladSciezki;
    List<Transform> listaPunktowSciezki;
    int nrPunktuSciezki = 0;

    void Awake()
    {
        beeSpawner = FindObjectOfType<BeeSpawner>();
    }

    void Start()
    {
        ukladSciezki = beeSpawner.GetObecnaFala();
        listaPunktowSciezki = ukladSciezki.GetPunktySciezki();
        transform.position = listaPunktowSciezki[nrPunktuSciezki].position;
    }

    void Update()
    {
        GoPoSciezka();
    }

    void GoPoSciezka()
    {
        if (nrPunktuSciezki < listaPunktowSciezki.Count)
        {
            Vector3 targetPosition = listaPunktowSciezki[nrPunktuSciezki].position;
            float delta = ukladSciezki.GetBeePredkosc() * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, delta);
            if (transform.position == targetPosition)
            {
                nrPunktuSciezki++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
