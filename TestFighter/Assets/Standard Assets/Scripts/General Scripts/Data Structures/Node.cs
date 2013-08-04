using UnityEngine;
using System.Collections;

public struct Node<T> : NodeBase {
	
	private T data;
	public T Data
	{
		get
		{
			return data;
		}
		set
		{
			data = value;
		}
	}
	
	public NodeBase* next;
	
};
