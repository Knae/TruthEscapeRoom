using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticVariables : MonoBehaviour
{
    [Header("Game Variables")]
    [SerializeField]static public int iDay = 1;

    // Start is called before the first frame update
    void Start()
	{

    }

	// Update is called once per frame
	void Update()
    {
        
    }

	private void Awake()
	{
        DontDestroyOnLoad(transform.gameObject);
	}
}
