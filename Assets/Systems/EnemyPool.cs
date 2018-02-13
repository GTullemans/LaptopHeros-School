using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour {
    [SerializeField]
    private GameObject _EnemyPrefab;
    [SerializeField]
    private int _Amount;
    private GameObject[] _EnemyPool;
    [SerializeField]
    private GameObject _PlayerParent;
    private List<GameObject> _Player;
	// Use this for initialization
	void Awake () {
        _Player = new List<GameObject>();
        for(int i = 0;i< _PlayerParent.transform.childCount; i++)
        {
            _Player.Add(_PlayerParent.transform.GetChild(i).gameObject);
        }
        _EnemyPool = new GameObject[_Amount];
        for(int i = 0; i < _Amount; i++)
        {
            _EnemyPool[i] = Instantiate(_EnemyPrefab, gameObject.transform);
            _EnemyPool[i].SetActive(false);
            _EnemyPool[i].GetComponent<Enemy>().Set_player(_Player[Random.Range(0,_Player.Count)]);
        }
	}

    public GameObject[] GetEnemyPool
    {
        get { return _EnemyPool; }
    }
	
	
}
