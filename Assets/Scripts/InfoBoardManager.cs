using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoBoardManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> prefabList = new List<GameObject>();
    private GameObject spawnedPrefab;
    private int currentPrefabIndex = 0;
    private GameObject spawnedPrefabParent;
    void Start()
    {
        spawnedPrefabParent = new GameObject("Components");
        spawnedPrefabParent.transform.position = new Vector3(0, 1, 5);
        // Spawn the first prefab when the scene starts
        SpawnPrefab();
    }
    public void SpawnNextPrefab()
    {
        // Destroy the currently spawned prefab, if any
        if (spawnedPrefab != null)
        {
            Destroy(spawnedPrefab);
        }

        // Increment the index to move to the next prefab in the list
        currentPrefabIndex++;
        if (currentPrefabIndex >= prefabList.Count)
        {
            currentPrefabIndex = 0; // Wrap around to the start if reaching the end
        }

        // Spawn the next prefab
        SpawnPrefab();
    }

    public void SpawnPreviousPrefab()
    {
        // Destroy the currently spawned prefab, if any
        if (spawnedPrefab != null)
        {
            Destroy(spawnedPrefab);
        }

        // Decrement the index to move to the previous prefab in the list
        currentPrefabIndex--;
        if (currentPrefabIndex < 0)
        {
            currentPrefabIndex = prefabList.Count - 1; // Wrap around to the end if reaching the start
        }

        // Spawn the previous prefab
        SpawnPrefab();
    }
    private void SpawnPrefab()
    {
        spawnedPrefab = Instantiate(prefabList[currentPrefabIndex], spawnedPrefabParent.transform);
    }
}
