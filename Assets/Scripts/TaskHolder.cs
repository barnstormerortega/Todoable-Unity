using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TaskHolder : MonoBehaviour {


	List<Task> taskList = new List<Task>();
	public TaskDisplay taskDisplayPrefab;
	public Transform taskDisplayBox;

	const string TASK_KEY = "tasks";

	void Awake() {
		string savedTasksString = PlayerPrefs.GetString (TASK_KEY);
		SavedTasks savedTasks = JsonUtility.FromJson<SavedTasks>( savedTasksString );
		if ( savedTasks.taskList != null ) {
			foreach (var savedTask in savedTasks.taskList) {
				AddTask (savedTask);
			}
		}
	}

	public void AddTask (Task taskToAdd){


		taskList.Add (taskToAdd);
		CreateTaskDisplay (taskToAdd);


	}

	public Task[] GetTask (){

		return null;

	
	}

	public void DeleteTask (Task taskToDelete){
	
		taskList.Remove (taskToDelete);
	
	
	}

	void CreateTaskDisplay (Task taskToAdd){

		TaskDisplay newTaskDisplay = Instantiate (taskDisplayPrefab);
		newTaskDisplay.UpdateTaskDisplay (taskToAdd);
		newTaskDisplay.transform.SetParent (taskDisplayBox);
	}

	void OnApplicationQuit() {
		var savedTasks = new SavedTasks ();
		savedTasks.taskList = taskList;

		string savedTasksString = JsonUtility.ToJson (savedTasks);
		PlayerPrefs.SetString ( TASK_KEY, savedTasksString);
	}

	public struct SavedTasks {
		public List<Task> taskList;
	}

}
