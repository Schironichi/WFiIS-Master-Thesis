using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PrefabManager : MonoBehaviour
{
    [SerializeField] private List<ExperimentData> experimentsList = new List<ExperimentData>();
    private ExperimentData currentExperiment;
    private GameObject spawnedPrefab;
    private int currentPrefabIndex = 0;
    private Color transparent = new Color(0, 0, 0, 0);
    private Color white = new Color(1, 1, 1, 1);

    public GameObject spawnedPrefabParent;
    public TextMeshPro experimentTitle;
    public TextMeshProUGUI infoBoardText;
    public Image infoBoardImage;
    void Start()
    {
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
        if (currentPrefabIndex >= experimentsList.Count)
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
            currentPrefabIndex = experimentsList.Count - 1; // Wrap around to the end if reaching the start
        }

        // Spawn the previous prefab
        SpawnPrefab();
    }
    private void SpawnPrefab()
    {
        currentExperiment = experimentsList[currentPrefabIndex];
        spawnedPrefab = Instantiate(currentExperiment.experimentObject, spawnedPrefabParent.transform);
        // Display the title for the spawned prefab
        experimentTitle.text = currentExperiment.experimentName;
        // Display the instruction for the spawned prefab
        if (currentExperiment.experimentDescription != null)
        {
            infoBoardText.text = currentExperiment.experimentDescription.text;
        }
        else
        {
            infoBoardText.text = "";
        }
        // Display the instruction for the spawned prefab
        if (currentExperiment.experimentImage != null)
        {
            infoBoardImage.color = white;
            infoBoardImage.sprite = currentExperiment.experimentImage;
        }
        else
        {
            infoBoardImage.color = transparent;
        }
    }
}
