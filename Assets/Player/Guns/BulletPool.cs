using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour {
    [SerializeField]
    private GameObject _Bullet;
    [SerializeField]
    private int _Amount;
    private GameObject[] _Pool;
        // Use this for initialization
	void Awake() {
        _Pool = new GameObject[_Amount];
		for(int i = 0; i < _Amount; i++)
        {
            _Pool[i] = Instantiate(_Bullet, transform);
            _Pool[i].SetActive(false);

        }
	}
	
	public GameObject[] GetBullet()
    {
        return _Pool;
    }
}
