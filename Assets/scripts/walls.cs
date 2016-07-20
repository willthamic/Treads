﻿using UnityEngine;
using System.Collections;

public class walls : MonoBehaviour {

	public float colDepth = 4f;
	public float zPosition = 0f;
	private Vector2 screenSize;
	private Transform topCollider;
	private Transform bottomCollider;
	private Transform leftCollider;
	private Transform rightCollider;
	private Vector3 cameraPos;

	void Start () {
		StartCoroutine(ExecuteAfterTime(1));
	}


	IEnumerator ExecuteAfterTime(float time) {
		yield return new WaitForSeconds(time);
		topCollider = new GameObject().transform;
		bottomCollider = new GameObject().transform;
		rightCollider = new GameObject().transform;
		leftCollider = new GameObject().transform;
		
		topCollider.name = "TopCollider";
		bottomCollider.name = "BottomCollider";
		rightCollider.name = "RightCollider";
		leftCollider.name = "LeftCollider";
		
		topCollider.gameObject.AddComponent<BoxCollider2D>();
		bottomCollider.gameObject.AddComponent<BoxCollider2D>();
		rightCollider.gameObject.AddComponent<BoxCollider2D>();
		leftCollider.gameObject.AddComponent<BoxCollider2D>();
		
		topCollider.parent = transform;
		bottomCollider.parent = transform;
		rightCollider.parent = transform;
		leftCollider.parent = transform;
		
		cameraPos = Camera.main.transform.position;
		screenSize.x = Vector2.Distance (Camera.main.ScreenToWorldPoint(new Vector2(0,0)),Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0))) * 0.5f;
		screenSize.y = Vector2.Distance (Camera.main.ScreenToWorldPoint(new Vector2(0,0)),Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height))) * 0.5f;
		
		rightCollider.localScale = new Vector3(colDepth, screenSize.y * 2, colDepth);
		rightCollider.position = new Vector3(cameraPos.x + screenSize.x + (rightCollider.localScale.x * 0.5f), cameraPos.y, zPosition);
		leftCollider.localScale = new Vector3(colDepth, screenSize.y * 2, colDepth);
		leftCollider.position = new Vector3(cameraPos.x - screenSize.x - (leftCollider.localScale.x * 0.5f), cameraPos.y, zPosition);
		topCollider.localScale = new Vector3(screenSize.x * 2, colDepth, colDepth);
		topCollider.position = new Vector3(cameraPos.x, cameraPos.y + screenSize.y + (topCollider.localScale.y * 0.5f), zPosition);
		bottomCollider.localScale = new Vector3(screenSize.x * 2, colDepth, colDepth);
		bottomCollider.position = new Vector3(cameraPos.x, cameraPos.y - screenSize.y - (bottomCollider.localScale.y * 0.5f), zPosition);
	}
}
