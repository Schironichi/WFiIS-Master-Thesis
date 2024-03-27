using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

[CreateAssetMenu]
public class ExperimentData : ScriptableObject
{
    public string experimentName;
    public TextAsset experimentDescription;
    public GameObject experimentObject;
    public Sprite experimentImage;
}
