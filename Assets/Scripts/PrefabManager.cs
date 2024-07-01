using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.UI.BoundsControl;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PrefabManager : MonoBehaviour
{
    private List<ExperimentData> experimentsList = new List<ExperimentData>();
    private ExperimentData currentExperiment;
    private GameObject spawnedPrefab;
    private int currentPrefabIndex = 0;
    private Color transparent = new Color(0, 0, 0, 0);
    private Color white = new Color(1, 1, 1, 1);
    private int tempPrefabIndex;

    [SerializeField] private List<ExperimentData> setupExperimentsList = new List<ExperimentData>();
    public GameObject spawnedPrefabParent;
    public TextMeshPro experimentTitle;
    public TextMeshProUGUI infoBoardText;
    public Image infoBoardImage;
    public GameObject sceneSelector;
    void Start()
    {
        experimentsList = new List<ExperimentData>(setupExperimentsList);
        // Spawn the first prefab when the scene starts
        SpawnPrefab();
    }
    public void AddExperimentsCombined(ExperimentDataCombined experimentDataCombined)
    {
        experimentsList = new List<ExperimentData>(setupExperimentsList);
        foreach (ExperimentDataList sublist in experimentDataCombined.experimentDataLists)
        {
            experimentsList.AddRange(sublist.experimentDatas);
        }
    }

    private void RemovePrefab()
    {
        if (spawnedPrefab != null)
        {
            if (spawnedPrefab.CompareTag("Selector"))
            {
                spawnedPrefab.SetActive(false);
            }
            else
            {
                Destroy(spawnedPrefab);
            }
        }
    }
    public void SpawnNextPrefab()
    {
        if (currentPrefabIndex >= experimentsList.Count - 1)
        {
            currentPrefabIndex = 0; // Wrap around to the start if reaching the end
        }
        // Destroy the currently spawned prefab, if any
        RemovePrefab();

        // Increment the index to move to the next prefab in the list
        currentPrefabIndex++;
        // Spawn the next prefab
        SpawnPrefab();

    }
    public void SpawnCalibrationSetup()
    {
        if (currentPrefabIndex != 0)
        {
            // Destroy the currently spawned prefab, if any
            RemovePrefab();

            // Decrement the index to move to the previous prefab in the list
            tempPrefabIndex = currentPrefabIndex - 1;
            currentPrefabIndex = 0;
            SpawnPrefab();
            currentPrefabIndex = tempPrefabIndex;
        }
    }

    public void SpawnPreviousPrefab()
    {
        if (currentPrefabIndex <= 0)
        {
            //currentPrefabIndex = experimentsList.Count - 1; // Wrap around to the end if reaching the start
        }
        else
        {
            // Destroy the currently spawned prefab, if any
            RemovePrefab();

            // Decrement the index to move to the previous prefab in the list
            currentPrefabIndex--;

            // Spawn the previous prefab
            SpawnPrefab();
        }
    }
    private void SpawnPrefab()
    {
        currentExperiment = experimentsList[currentPrefabIndex];

        // Disable calibration setup
        if (currentPrefabIndex == 0)
        {
            spawnedPrefabParent.GetComponentInChildren<BoundsControl>().enabled = true;
            spawnedPrefabParent.GetComponentInChildren<ObjectManipulator>().enabled = true;
        }
        else
        {
            spawnedPrefabParent.GetComponentInChildren<BoundsControl>().enabled = false;
            spawnedPrefabParent.GetComponentInChildren<ObjectManipulator>().enabled = false;
        }

        if (currentExperiment.experimentObject != null)
        {
            if (currentExperiment.experimentObject.CompareTag("Selector"))
            {
                spawnedPrefab = sceneSelector;
                spawnedPrefab.SetActive(true);
            }
            else
            {
                spawnedPrefab = Instantiate(currentExperiment.experimentObject, spawnedPrefabParent.transform);
            }
        }
        // Display the title for the spawned prefab
        experimentTitle.text = currentPrefabIndex + ": " + currentExperiment.experimentName;
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
