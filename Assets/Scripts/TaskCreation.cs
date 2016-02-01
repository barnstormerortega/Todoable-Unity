using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TaskCreation : MonoBehaviour {


	public InputField taskName ;
	public ToggleGroup taskTimer;
	public TaskHolder taskHolder;

	// Use this for initialization
	void Start () {
	
	}


	public void TaskSubmit (){

		Frequency activeTimer = Frequency.Weekly;


		foreach (Toggle activeToggle in taskTimer.ActiveToggles()) {



			if (activeToggle.name == "Daily")
				activeTimer = Frequency.Daily;
			else if (activeToggle.name == "Weekly")
				activeTimer = Frequency.Weekly;
			else if (activeToggle.name == "Monthly")
				activeTimer = Frequency.Monthly;
			else
				activeTimer = Frequency.Quarterly;

		}
	
		Debug.Log ("New Task entered!" + taskName.text + activeTimer);


		Task newTask = new Task (taskName.text, activeTimer);


	


		taskHolder.AddTask (newTask);
	
	}







	// Update is called once per frame
	void Update () {
	
	}
}
