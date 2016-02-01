using UnityEngine;
using System.Collections;
using System;


public enum Frequency {
	Daily, Weekly, Monthly, Quarterly
}

[Serializable]
public class Task : ISerializationCallbackReceiver {

	public string name ;
	public Frequency frequency ;
	public DateTime lastComplete ;

	[HideInInspector]
	[SerializeField]
	string lastCompleteString;


	public static TimeSpan FrequencyToTimeSpan(Frequency frequencyToConvert){

		if (frequencyToConvert == Frequency.Daily)
			return TimeSpan.FromDays (1);

		if (frequencyToConvert == Frequency.Weekly)
			return TimeSpan.FromDays (7);

		if (frequencyToConvert == Frequency.Monthly)
			return TimeSpan.FromDays (30);
		
		else if (frequencyToConvert == Frequency.Quarterly)
			return TimeSpan.FromDays (90);

		return TimeSpan.FromDays (0);

	}




	public Task (string newName, Frequency newFrequency) {

		this.name = newName;
		this.frequency = newFrequency;
		lastComplete = DateTime.Now;
	}

	public void MarkDone() {
		lastComplete = DateTime.Now;
	}


	// adds the TimeSpan value of the task's Frequency to the DateTime of the last complete)
	public DateTime due {
		get { return lastComplete + FrequencyToTimeSpan (frequency);
		}
	}

	// finds the difference between the current DateTime and the due DateTime. 

	public TimeSpan countdown {
		get {return due.Subtract(DateTime.Now);
		}
	}

	#region ISerializationCallbackReceiver implementation
	public void OnBeforeSerialize ()
	{
		lastCompleteString = lastComplete.ToString ();
	}

	public void OnAfterDeserialize ()
	{
		if ( !DateTime.TryParse (lastCompleteString, out lastComplete)) {
			Debug.LogWarning ("Date time couldn't be parsed: " + lastCompleteString);
		}
	}
	#endregion
}
