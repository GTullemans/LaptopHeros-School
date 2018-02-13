using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour {
    [SerializeField]
    private GameObject _EnemyPool;
    [SerializeField]
    private Transform[] _SpawnPositions;
    [SerializeField]
    private int _SuperWaveEvery;
    [SerializeField]
    private float _WaveEvery;
    [SerializeField]
    private int _StartEnemy;

    [SerializeField]
    private GameObject[] _Pool;
    [SerializeField]
    private float _Timer;
    [SerializeField]
    private int WaveCounter;
    [SerializeField]
    private int _AmountOfEnemys;
    [SerializeField]
    private float _Modifier;

	// Use this for initialization
	void Start () {
        _Pool = new GameObject[1000];
        _Pool = _EnemyPool.GetComponent<EnemyPool>().GetEnemyPool;
        _Timer = _WaveEvery;
        WaveCounter = 0;
        _AmountOfEnemys = _StartEnemy - 1;


    }
	
	// Update is called once per frame
	void Update () {
        _Timer += Time.deltaTime;

        if (_Timer > _WaveEvery)
        {
            _Timer = 0;
            WaveCounter += 1;
            _Modifier = 1 + (WaveCounter / 5);
            _AmountOfEnemys += 1;

            if (WaveCounter == _SuperWaveEvery)
            {
                EnemySpawn(2);
            }
            else
            {
                EnemySpawn(1);
            }


            
        }


		
	}


    private void EnemySpawn( int mod)
    {
        for (int i = 0; i < _AmountOfEnemys * mod; i++)
        {
            for (int j = 0; j < _Pool.Length; j++)
            {
                if (!_Pool[j].activeInHierarchy)
                {
                    _Pool[j].transform.position = _SpawnPositions[Random.Range(0, _SpawnPositions.Length - 1)].position;
                    _Pool[j].SetActive(true);
                    _Pool[j].GetComponent<Enemy>().Modifie(_Modifier);
                    break;
                }
            }
        }
    }
}
