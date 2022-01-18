using System.Collections;
using UnityEngine.AI;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField] private PlayerStatus playerStatus;
    [SerializeField] private GameObject enemyPrefab;

    private void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            var distanceVector = new Vector3(10, 0);

            var SpawnPositionFromPlayer = Quaternion.Euler(0,Random.Range(0,
                360f), 0) * distanceVector;

            var spawnPosition = playerStatus.transform.position
                + SpawnPositionFromPlayer;

            NavMeshHit navMeshHit;

            if (NavMesh.SamplePosition(spawnPosition , out navMeshHit, 
                10, NavMesh.AllAreas)) //指定座標から一番近いNavMeshの座標を探す
            {
                Instantiate(enemyPrefab,navMeshHit.position,Quaternion
                    .identity);
            }
            yield return new WaitForSeconds(10);

            //プレイヤーが倒れたらループを抜ける
            if (playerStatus.Life <= 0)
            {
                break;
            }
        }
    }

}
