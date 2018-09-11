using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorResistencia : MonoBehaviour {
    public int NumeroRecistencia;
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		NumeroRecistencia = gameObject.GetComponentInParent<Shelter>().MaxResistance;
        GetComponent<Text>().text = NumeroRecistencia.ToString();
    }
}
