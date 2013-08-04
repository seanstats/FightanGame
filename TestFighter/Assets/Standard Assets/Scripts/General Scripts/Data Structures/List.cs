using UnityEngine;
using System.Collections;

public class List<T> {
	public int size = 0;
	private Node<T> front;
	private Node<T> back;
	
	public List()
	{
		size = 0;
	}
	
	/*public virtual Node<T> this[int i]
	{
		get
		{
			GetAt(i);
		}
	}*/
	
	private Node<T> GetAt(int i)
	{
		if(i < size && i >=0)
		{
			Node<T> currentNode = front;
			for(int j = 1; j < i; j++)
			{
				currentNode = currentNode.next;
			}
			return currentNode;
		}
		else
		{
			Debug.LogError("Index " + i + " is out of bounds.");
			return front;
		}	
	}
}
