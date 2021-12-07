using UnityEngine;
using System.Collections;

public class EnemyGeneratorCtrl : MonoBehaviour {
	// 생겨날 적 프리팹.
	public GameObject enemyPrefab;
	// 적을 저장한다. 
	GameObject[] existEnemys;
	// 액티브 최대 수.
	EnemyObjectPool objectPool;
	public int maxEnemy;
	public int enemyCount = 0;

	public float respawnTime = 5.0f;

	void Awake() {
		objectPool = transform.GetChild(0).GetComponent<EnemyObjectPool>();
	}

	void Start()
	{
		// 배열 확보.
		existEnemys = new GameObject[maxEnemy];
		// 주기적으로 실행하고 싶을 때는 코루틴을 사용하면 쉽게 구현할 수 있다.
		StartCoroutine(Exec());
	}

	// 적을 생성한다.
	IEnumerator Exec()
	{
		while (true) { 
			if (enemyCount < maxEnemy)
				Generate();
			yield return new WaitForSeconds( respawnTime );
		}
	}

	void Generate()
	{
		// for(enemyCount = 0; enemyCount < existEnemys.Length; ++ enemyCount)
		// {
		// 	if( existEnemys[enemyCount] == null ){
		// 		// 적 생성.
		// 		existEnemys[enemyCount] = EnemyObjectPool.GetObject(); //Instantiate(enemyPrefab,transform.position,transform.rotation) as GameObject;
		// 		existEnemys[enemyCount].transform.position = transform.position;
		// 		return;
		// 	}
		// }
		objectPool.GetObject();
		enemyCount++;
	}
	
}
