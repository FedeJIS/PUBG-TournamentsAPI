using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TournamentInfo : MonoBehaviour
{
    private TextMeshProUGUI id;
    private TextMeshProUGUI date;
    private void Awake() {
        id = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        date = transform.GetChild(1).GetComponent<TextMeshProUGUI>();

    }
    public string ID
    {
        set
        {
            id.text = value;
        }
        get
        {
            return id.text;
        }
    }

    public string DATE
    {
        set
        {
            date.text = value;
        }
        get
        {
            return date.text;
        }
    }

}
