using UnityEngine;
using System.Collections;

public struct Node<T> : INodeBase{
	
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
	
	public INodeBase next;
	
};
