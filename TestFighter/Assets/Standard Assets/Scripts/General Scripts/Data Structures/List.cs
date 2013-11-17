using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class List<T> {
	public int m_size = 0;
	private Node<T> m_front;
	//private Node<T> back;
	
	public List()
	{
		m_size = 0;
	}
	
	/*public virtual Node<T> this[int i]
	{
		get
		{
			return GetAt(i);
		}
	}*/
	
	LinkedList<int> link;
	
	public Node<T> GetAt(int i)
	{
		if(i < m_size && i >=0)
		{
			Node<T> currentNode = m_front;
			for(int j = 1; j < i; j++)
			{
				//starting at j = 1 because we want to iterate i-1 times
				currentNode = (Node<T>)currentNode.next;
			}
			return currentNode;
		}
		else
		{
			Debug.LogError("Index " + i + " is out of bounds: 0-" + m_size);
			return m_front;
		}	
	}
	
	public bool AddAtIndex(int i, T newData)
	{
		if(i == 0)
		{
			Node <T> newNode = new Node<T>(newData);
			newNode.next = m_front;
			m_front = newNode;
			m_size++;
			return true;
		}
		else if(i <= m_size && i >= 1)
		{
			Node <T> newNode = new Node<T>(newData);
			Node<T> currentNode = m_front;
			for(int j = 1; j < i; j++)
			{
				currentNode = (Node<T>)currentNode.next;
			}
			newNode.next = currentNode.next;
			currentNode.next = newNode;
			m_size++;
			return true;
		}
		else
		{
			Debug.LogError("Index " + i + " is out of bounds. List size: " + m_size);
			return false;
		}
	}
}
