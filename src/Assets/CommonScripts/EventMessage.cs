using System;
using System.Collections;

public class EventMessage
{
	private string _type;
	private Hashtable _args;

	public EventMessage(string type = "") {
		_type = type;
	}

	public Hashtable args {
		get { return _args; }
		set { _args = value; }
	}

	public string type {
		get { return _type; }
		set { _type = value; }
	}
}
