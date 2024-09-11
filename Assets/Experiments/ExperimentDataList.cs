using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

[CreateAssetMenu]
public class ExperimentDataList : ScriptableObject
{
    [SerializeField] public List<ExperimentData> experimentDatas = new List<ExperimentData>();
}
