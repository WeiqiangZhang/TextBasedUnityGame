using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {
	private enum States {cell, mirror, sheets, sleep, key, bloody, freedom};
	private States myState;
	private enum Condition {healthy, sick, dead, real_death};
	private Condition myCondition;
	private int currCellState;
	private int currSheetsState;
	private int currMirrorState;
	private int bloody;
	private int currKeyState;
	public Text text;
	// Use this for initialization
	void Start () {
		myState = States.cell;
		currSheetsState = 0;
		currCellState = 0;
		currMirrorState = 0;
		bloody = 0;
		currKeyState = 0;
		myCondition = Condition.healthy;
	}
	
	// Update is called once per frame
	void Update () {
		if (myCondition == Condition.dead) {
			condition_dead ();
		} else if (myCondition == Condition.real_death) {
			actual_death();
		}
		else if (myState == States.cell) {
			state_cell ();
		} else if (myState == States.sheets) {
			state_sheets ();
		} else if (myState == States.sleep) {
			state_sleep ();
		} else if (myState == States.mirror) {
			state_mirror ();
		} else if (myState == States.bloody) {
			state_bloody ();
		} else if (myState == States.key) {
			state_key ();
		}else if (myState == States.freedom) {
			state_freedom ();
		}
	}
	void condition_dead(){
		text.text = "Nothing happened. Told you ghosts weren't real \n\n" +
					"Press R to return to cell";
		if (Input.GetKeyDown (KeyCode.R)) {
			myCondition = Condition.real_death;
		}
	}
	void actual_death(){
		text.text = "As you turn away from the mirror you hear a loud gust of wind. You look down and see a" +
					" knife sticking out of your chest. I guess ghosts are real \n\n" +
					"Press P to play again";
		if (Input.GetKeyDown (KeyCode.P)) {
			Start();
		}
	}
	void state_cell(){
		if(currCellState == 0){
			text.text = "You wake up in a deserted asylum, the lights are dimly lit and you hear the sound of " +
						"creaking. This place is starting to creep you out, you better find the exit " +
						"before it's too late " +
						"There are some dirty sheets on the bed, a mirror on the wall, and the door " +
						"is locked from the outside.\n\n" +
						"Press S to view Sheets, M to view Mirror and L to view Lock";
		}
		else if(currCellState == 1){
			text.text = "You still have a vivid smell of the blood stain running up your nose but you decide to " +
						"focus on finding the exit before anything bad happens \n\n" +
						"Press S to view Sheets, M to view Mirror and L to view Lock";
		}else if(currCellState == 2){
			text.text = "You can't help but to feel that the flash you saw on the mirror was important \n\n" +
						"Press S to view Sheets, M to view Mirror and L to view Lock";
		}else if(currCellState == 3){
			text.text = "Now, I wonder what keys are for \n\n" +
						"Press S to view Sheets, M to view Mirror and L to view Lock";
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			myState = States.sheets;
		} else if (Input.GetKeyDown (KeyCode.M)) {
			myState = States.mirror;
		} else if (Input.GetKeyDown (KeyCode.L)) {
			myState = States.freedom;
		}
	}
	void state_sheets(){
		if(currSheetsState == 0){
			text.text = "You walk up to the worn out rags that is riddled with bugs and spiders and what seems " +
						"like a blood stain, you think to yourself it'll probably be best not to even touch " +
						"those things \n\n" +
						"Press S to sleep under the Sheets and R to return to roaming the cell" ;
			if (Input.GetKeyDown (KeyCode.S)) {
				currSheetsState = 1;
				myState = States.sleep;
			}
		}
		else if(currSheetsState == 1){
			text.text = "There's nothing else I can do here \n\n" +
						"Press R to return to roaming the cell" ;
		}
		else if(currSheetsState == 2){
			text.text = "You put the key on the rags. Nothing happened.... \n\n" +
						"Who would've thought \n\n" +
						"Press R to return to roaming the cell" ;
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
		}
	}
	void state_sleep(){
		text.text = "You haven't had proper sleep in days and even with the disgusting rags you've slept on you " +
					"felt refereshed, and also a huge bump on your head \n\n" +
					"R to return to roaming the cell" ;	
		if (Input.GetKeyDown (KeyCode.R)) {
			myCondition = Condition.sick;
			currSheetsState = 1;
			currCellState = 1;
			myState = States.cell;
		}
	}

	void state_mirror(){
		if (currMirrorState == 0) {
			text.text = "As you walk up to the mirror you pray under your breath hoping there won't be a ghost to " +
						"greet you the moment you take look. \n\n" +
						"To your surprise you catch a flash coming from the other side of the room\n\n" +
						"Press L walk towards the flash, B to say bloody Mary and R to return to roaming the cell";
			if (Input.GetKeyDown (KeyCode.B)) {
				bloody++;
				if(bloody == 3){
					myCondition = Condition.dead;
				}
				else{
					myState = States.bloody;
				}
			} else if (Input.GetKeyDown (KeyCode.L)) {
				myState = States.key;
			}
		} else if (currMirrorState == 1) {
			text.text = "Why hello there handsome \n\n" +
				"Press L walk towards the flash, B to say bloody Mary and R to return to roaming the cell";
			if (Input.GetKeyDown (KeyCode.B)) {
				bloody++;
				if(bloody == 3){
					myCondition = Condition.dead;
				}
				else{
					myState = States.bloody;
				}
			} else if (Input.GetKeyDown (KeyCode.L)) {
				myState = States.key;
			}
		} else if (currMirrorState == 2) {
			text.text = "You chuck the key at the mirror and it shatters into a hundred pieces.... oops \n\n" +
						"Press R to return to roaming the cell";
		}
		else if (currMirrorState == 3) {
			text.text = "I don't think the mirror is going magically fix itself \n\n" +
						"Press R to return to roaming the cell";
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			if(currMirrorState == 0){
				currCellState = 2;
				currMirrorState = 1;
			} else if(currMirrorState == 2){
				currMirrorState = 3;
			}
			myState = States.cell;
		}
	}

	void state_bloody(){
		if (bloody == 1) {
			text.text = "So you've already said Bloody Mary once, one more wouldn't hurt right?\n\n" +
						"Press B to say Bloody Mary again and R to return to roaming the cell";
		}
		else if (bloody == 2) {
			text.text = "Only kids believe in ghost stories, just one more time \n\n" +
						"Press B to say Bloody Mary again and R to return to roaming the cell";
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			if(currMirrorState == 0){
				currCellState = 2;
				currMirrorState = 1;
			}
			myState = States.cell;
		} else if (Input.GetKeyDown (KeyCode.B)) {
			bloody++;
			if(bloody == 3){
				myCondition = Condition.dead;
			}
			else{
				myState = States.bloody;
			}
		}
	}
	void state_key (){
		text.text = "Huh it's a key. Neat! \n\n" +
					"Press R to return to roaming the cell";
		if (Input.GetKeyDown (KeyCode.R)) {
			currMirrorState = 2;
			currSheetsState = 2;
			currCellState = 3;
			currKeyState = 1;
			myState = States.cell;
		}
	}
	void state_freedom(){
		if (currKeyState == 0) {
			text.text = "The lock won't budge no matter how hard you stare at it, maybe another option is available \n\n" +
						"Press R to return to roaming the cell";
			if (Input.GetKeyDown (KeyCode.R)) {
				myState = States.cell;
			}
		}
		else{
			text.text = "With your incredible intellect and outstanding wits, you figured out keys are for locks, " +
				" and you made it home free! \n\n";
			if (myCondition == Condition.sick){
				text.text += "Right before you leave the asylum you feel excruciating pain comming from the bump " +
							 "on your head, you thought to yourself \"Maybe I shouldn't have slept on those rags\" " +
							 "as you passed out \n\n" +
							 "You lose. Press P to play again.";
			}else{
				text.text += "You win! Press P to play again.";
			}
			if (Input.GetKeyDown (KeyCode.P)) {
				Start();
			}
		}
	}
}
