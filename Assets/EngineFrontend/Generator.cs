﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using e = Engine;

public class Generator : MonoBehaviour {
	public e.BallGenerator BallGenerator;

	public float time = 0;
	public int step = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;

		if (time >= 1) {
			time = 0;

			var actions = this.BallGenerator.GetActions()[step];
			this.transform.position = new Vector2(actions.Position.X, actions.Position.Y);

			Debug.Log("Generator: " + actions.Type);

			switch (actions.Type) {
				case e.ActionType.GenerateNewBall:
					Debug.Log("GENERATE NEW BALL!!!!");
				break;
			}

			step++;
		}
	}
}
