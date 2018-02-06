using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;



public class Shoot : MonoBehaviour {
    [SerializeField]
    private GameObject _BulletPool;
    [SerializeField]
    private float _RateOfFire;
    [SerializeField]
    private Vector3 _Ofset;
    private float Timer;
    private GameObject[] _Pool;


	// Use this for initialization
	void Start () {
        _Pool = new GameObject[1000];
        Timer = _RateOfFire;
        _Pool = _BulletPool.GetComponent<BulletPool>().GetBullet();

	}

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer > _RateOfFire && XCI.GetAxis(XboxAxis.RightTrigger) == 1)
        {
            Timer = 0;
            for (int i = 0; i < _Pool.Length; i++)
            {
                if (!_Pool[i].activeInHierarchy)
                {
                    
                    _Pool[i].SetActive(true);
                    _Pool[i].transform.position = transform.position + _Ofset;
                    _Pool[i].GetComponent<Bullet>().SetDir(transform.rotation);
                    break;
                }
            }
        }
    }
}
