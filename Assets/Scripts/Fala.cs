using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Konfiguracja Fali", fileName = "Konfiguracja Nowej Fali")]
public class Fala : ScriptableObject
{
    [SerializeField] List<GameObject> beePrefabs;
    [SerializeField] Transform sciezkaWithTransforms;
    [SerializeField] float beeMoveSpeed = 9f;
    [SerializeField] float beeSpawnTimeInFala = 0.7f;

    public int GetBeeIlosc()
    {
        return beePrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return beePrefabs[index];
    }

    public Transform GetStartingWaypoint()
    {
        return sciezkaWithTransforms.GetChild(0);
    }

    public List<Transform> GetPunktySciezki()
    {
        List<Transform> listaPunktowSciezki = new List<Transform>();
        foreach (Transform transformPunktuSciezki in sciezkaWithTransforms)
        {
            listaPunktowSciezki.Add(transformPunktuSciezki);
        }
        return listaPunktowSciezki;
    }

    public float GetBeePredkosc()
    {
        return beeMoveSpeed;
    }

    public float GetBeeSpawnTime()
    {
        return beeSpawnTimeInFala;
    }
}
