using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventManager : MonoBehaviour
{
	public static EventManager Instance;
	private bool _created;

	private Dictionary<string, List<GameObject>> _listeners = new Dictionary<string, List<GameObject>> ();

	void Awake ()
	{
		if (!_created) {
			DontDestroyOnLoad (this);
			Instance = this;
			_created = true;
		} else {
			Debug.LogWarning ("Only a single instance of " + this.name + " should exists!");
			Destroy (gameObject);
		}
	}

	public bool AddListener (string eventType, GameObject listener)
	{
		if (null == eventType || null == listener) {
			Debug.LogWarning ("Event Manager: AddEventHandler failed, eventType or listener was null.");
			return false;
		}
		return recordListener (eventType, listener);
	}

	public bool RemoveListner (string eventType, GameObject listener)
	{
		return deleteListener (eventType, listener);
	}

	public void DispatchEvent (EventMessage evt)
	{
		if (_listeners.ContainsKey (evt.type)) {
			foreach (GameObject l in _listeners[evt.type]) {
				l.SendMessage ("ReceieveEvent", evt);
			}
		} else {
			Debug.LogWarning ("No listeners configured for event: " + evt.type);
		}
	}

	private void recordEvent (string eventType)
	{
		if (!_listeners.ContainsKey (eventType)) {
			_listeners [eventType] = new List<GameObject> ();
		}
	}

	private bool checkForListner (string eventType, GameObject listener)
	{
		if (!_listeners.ContainsKey (eventType)) {
			return false;
		}

		foreach (GameObject l in _listeners[eventType]) {
			if (Object.ReferenceEquals (listener, l)) {
				return true;
			}
		}
		return false;
	}

	private bool recordListener (string eventType, GameObject listener)
	{
		recordEvent (eventType);

		if (!checkForListner (eventType, listener)) {
			_listeners [eventType].Add (listener);
			return true;
		}
		return false;
	}

	private bool deleteListener (string eventType, GameObject listener)
	{
		if (!_listeners.ContainsKey (eventType)) {
			return false;
		}
		return _listeners [eventType].Remove (listener);
	}

}
