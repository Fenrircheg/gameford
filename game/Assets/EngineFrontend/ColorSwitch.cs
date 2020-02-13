﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using e = Engine;

public class ColorSwitch : MonoBehaviour {
	public e.ColorSwitch ColorSwitcher;
	public Sprite[] sprites;
	public Dictionary<e.Color, Sprite> spritesDict = null;
	public float time = 0;
	public int step = 0;
	public e.Color color;
	public bool active = false;
	void Awake(){
		spritesDict = new Dictionary<e.Color, Sprite> {
			{e.Color.Green, sprites[0]},
			{e.Color.Purple, sprites[1]},
			{e.Color.Blue, sprites[2]},
			{e.Color.Yellow, sprites[3]},
			{e.Color.Red, sprites[4]}
		};
	}
	void Start () {
	}
	
	void Update () {
		// Понятия не имею, что это за код. С ним работает. Без него тоже. 
		// Пусть будет. 
		/*
		if (!this.active) { return; }

		time += Time.deltaTime;

		if (time >= 1) {
			time = 0;

			var action = this.ColorSwitcher.GetActions()[step];
			var grid = GameObject.Find("Grid").GetComponent<GridInit>();
			Cell cell = grid.cellsArray[action.Position.Y, action.Position.X];
			if (cell) {
				this.transform.position = cell.transform.position;
			}
			switch (action.Type) {
			}

			step++;
		}
 		*/
	}
}
