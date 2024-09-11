using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

[CreateAssetMenu]
public class ExperimentDataCombined : ScriptableObject
{
    [SerializeField] public List<ExperimentDataList> experimentDataLists = new List<ExperimentDataList>();
}
