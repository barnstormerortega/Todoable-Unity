using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TaskDisplay : MonoBehaviour {

	// Use this for initialization



	public Text taskName;
	public Text taskFrequency;
	public Text taskDue;
	public Text taskCountdown;

	public Task taskToDisplay;

	void Start () {


	
	
	}


	public void UpdateTaskDisplay (Task newTaskToDisplay){
		this.taskToDisplay = newTaskToDisplay;

		taskName.text = newTaskToDisplay.name;
//		taskFrequency.text = taskToDisplay.frequency.ToString();
//		taskDue.text = taskToDisplay.due.ToString("d MMM");
		UpdateCountdown();
	}


	public void OnDoneButtonPressed() {
		taskToDisplay.MarkDone ();
	}

	public void OnDeleteButtonPressed() {
	
		FindObjectOfType<TaskHolder> ().DeleteTask ( taskToDisplay );

		Destroy (gameObject);
	
	}

	private void UpdateCountdown() {


	
		taskCountdown.text = taskToDisplay.countdown.Days.ToString("## 'd'") + ":" + taskToDisplay.countdown.Hours.ToString("## 'h'") + ":" + taskToDisplay.countdown.Minutes.ToString("## 'm'");
	
	
	}





	// Update is called once per frame
	void Update () {
	
		UpdateCountdown ();

	}
}
