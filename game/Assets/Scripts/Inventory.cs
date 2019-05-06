﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cb = ControlBlock;

public class Inventory : MonoBehaviour {
	Vector3 switcherItemPosition = new Vector3(0F, 0F, 0F);
	private GameObject [] switcherInInventoryArray = null;
	Vector3 conditionItemPosition = new Vector3(0F, 0F, 0F);
	private GameObject [] conditionInInventoryArray = null;
	private int switcherCounter = 10;
	private int conditionCounter = 10;
	GameObject draggedBlock = null;

	public void OnBlockUp(GameObject block){
		this.draggedBlock = block;
	}

	public void OnBlockDown(GameObject block){
		this.draggedBlock = null;
	}

	void Start(){
		this.switcherInInventoryArray = new GameObject[switcherCounter];
		this.conditionInInventoryArray = new GameObject[conditionCounter];

		var tmp_switncher = GameObject.Find("Switcher");
		tmp_switncher.GetComponent<SpriteRenderer>().enabled = false;
		tmp_switncher.GetComponent<Collider2D>().enabled = false;

		switcherItemPosition = tmp_switncher.GetComponent<SpriteRenderer>().transform.position;

		for (var i=0; i<switcherCounter; i++){
			var clone = Instantiate(tmp_switncher);
			clone.transform.position = switcherItemPosition;
			clone.transform.parent = this.transform;
			clone.GetComponent<SpriteRenderer>().enabled = false;
			clone.GetComponent<Collider2D>().enabled = false;
			this.switcherInInventoryArray[i] = clone;
		}

		var tmpCondition = GameObject.Find("Condition");
		tmpCondition.GetComponent<SpriteRenderer>().enabled = false;
		tmpCondition.GetComponent<Collider2D>().enabled = false;

		switcherItemPosition = tmpCondition.GetComponent<SpriteRenderer>().transform.position;

		for (var i=0; i<conditionCounter; i++){
			var clone = Instantiate(tmpCondition);
			clone.transform.position = switcherItemPosition;
			clone.transform.parent = this.transform;
			clone.GetComponent<SpriteRenderer>().enabled = false;
			clone.GetComponent<Collider2D>().enabled = false;
			this.conditionInInventoryArray[i] = clone;
		}
		
		ShowNextChangeBlock();
		ShowNextConditionBlock();
	}
	public void FailDropBlock(GameObject block){
		switch (block.GetComponent<ControlBlock>().GetBlockType()){
			case cb.BlockType.cbAction:
				block.transform.position = switcherItemPosition;
				ReturnBlockToInventory(block);
				break;
			case cb.BlockType.cbCondition:
				block.transform.position = conditionItemPosition;
				//ReturnBlockToInventory(block);
				break;
			case cb.BlockType.cbCicle:
				Debug.Log("Cicle");
				break;
		}
	}
	public void SuccedDropBlock(GameObject block){
		switch (block.GetComponent<ControlBlock>().GetBlockType()){
			case cb.BlockType.cbAction:
				ShowNextChangeBlock();
				break;
			case cb.BlockType.cbCondition:
				break;
			case cb.BlockType.cbCicle:
				break;
		}
	}

	void ShowNextChangeBlock(){
		if (switcherCounter == 0)	{	return;	}
		
		GameObject next_item = this.switcherInInventoryArray[switcherCounter - 1];

		next_item.GetComponent<SpriteRenderer>().enabled = true;
		next_item.GetComponent<Collider2D>().enabled = true;

		switcherCounter--;
	}
	void ShowNextConditionBlock(){
		if (conditionCounter == 0)	{	return;	}
		
		GameObject next_item = this.conditionInInventoryArray[conditionCounter - 1];

		next_item.GetComponent<SpriteRenderer>().enabled = true;
		next_item.GetComponent<Collider2D>().enabled = true;

		conditionCounter--;
	}
	void ReturnBlockToInventory(GameObject block){
		if (switcherCounter > 0){
			block.GetComponent<SpriteRenderer>().enabled = false;
			block.GetComponent<Collider2D>().enabled = false;
		}		
		this.switcherInInventoryArray[switcherCounter] = block;
		switcherCounter++;
	}
}
