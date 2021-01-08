using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAIPoint : MonoBehaviour {
	public GameObject Point1;
	public GameObject Point2;
	public GameObject Point3;
	public GameObject Point4;
	public GameObject Point5;
	public GameObject Point6;
	public GameObject Point7;
	public GameObject Point8;
	public GameObject Point9;

	public float TimeStart;
	private bool PointTarget;
	private int RandoM;
	public int TimeRandom = 5;

	
	// Update is called once per frame
	void Update () 
	{
		
		if (PointTarget == false) {
			RandoM = Random.Range (1, 9);
			if (RandoM == 1) {
				gameObject.transform.position = Point1.transform.position;
				PointTarget = true;
			}
			if (RandoM == 2) {
				gameObject.transform.position = Point2.transform.position;
				PointTarget = true;
			}
			if (RandoM == 3) {
				gameObject.transform.position = Point3.transform.position;
				PointTarget = true;
			}
			if (RandoM == 4) {
				gameObject.transform.position = Point4.transform.position;
				PointTarget = true;
			}
			if (RandoM == 5) {
				gameObject.transform.position = Point5.transform.position;
				PointTarget = true;
			}
			if (RandoM == 6) {
				gameObject.transform.position = Point6.transform.position;
				PointTarget = true;
			}
			if (RandoM == 7) {
				gameObject.transform.position = Point6.transform.position;
				PointTarget = true;
			}
			if (RandoM == 8) {
				gameObject.transform.position = Point6.transform.position;
				PointTarget = true;
			}
			if (RandoM == 9) {
				gameObject.transform.position = Point6.transform.position;
				PointTarget = true;
			}
		}
		if (PointTarget == true) {
			TimeStart += 1 * Time.deltaTime;
			if (TimeStart >= TimeRandom) {
				TimeStart = 0;
				PointTarget = false;
			}
		}
	}

}
