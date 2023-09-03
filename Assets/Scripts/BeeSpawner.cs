using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeSpawner : MonoBehaviour
{
    [SerializeField] List<Fala> fale;
    Fala obecnaFala;

    void Start()
    {
        StartCoroutine(GenerateBeeFale());
    }

    public Fala GetObecnaFala()
    {
        return obecnaFala;
    }

    IEnumerator GenerateBeeFale()
    {
        do
        {
            foreach (Fala fala in fale)
            {
                Debug.Log("Zaladowalo fale??");
                obecnaFala = fala;
                for (int i = 0; i < obecnaFala.GetBeeIlosc(); i++)
                {
                    Instantiate(obecnaFala.GetEnemyPrefab(i),
                                obecnaFala.GetStartingWaypoint().position,
                                Quaternion.identity,
                                transform);
                    yield return new WaitForSeconds(obecnaFala.GetBeeSpawnTime());
                }
                yield return new WaitForSeconds(0f);
            }
        } while (true);
        

    }
}
