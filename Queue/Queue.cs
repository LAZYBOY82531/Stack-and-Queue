using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
	/******************************************************
	 * 큐 (Queue)
	 * 
	 * 선입선출(FIFO), 후입후출(LILO) 방식의 자료구조
	 * 입력된 순서대로 처리해야 하는 상황에 이용
	 * 이번에 만드는 것은 원형배열을 이용해 데이터가 들어오는 만큼
	 * 늘어나는 원형배열을 만들 예정
	 ******************************************************/

	public class Queue<T>
	{
		private const int DefaultCapacity = 4;

		private T[] array;
		private int head;
		private int tail;

		public Queue()
		{
			array = new T[DefaultCapacity + 1];
			head = 0;
			tail = 0;
		}

		private bool IsEmpty()
		{
			return head == tail;
		}

		private bool IsFull()
		{
			if (head > tail)
			{
				return head == tail + 1;
			}
			else
			{
				return head == 0 && tail == array.Length - 1;
			}
		}
		private void MoveNext(ref int index)
		{
			index = (index == array.Length - 1) ? 0 : index + 1;
		}

		public void Enqueue(T item)
		{
			if (IsFull())
			{
				Grow();
			}

			array[tail] = item;
			MoveNext(ref tail);
		}

		public T Dequeue()
		{
			if (IsEmpty())
				throw new InvalidOperationException();

			T result = array[head];
			MoveNext(ref head);
			return result;
		}

		public T Peek()
		{
			if (IsEmpty())
				throw new InvalidOperationException();

			return array[head];
		}

		public int Count
		{
			get
			{
				if (head <= tail)
					return tail - head;
				else
					return tail + array.Length - head;
			}
		}

		private void Grow()
		{
			int newCapacity = array.Length * 2;
			T[] newArray = new T[newCapacity + 1];
			if (!IsEmpty())
			{
				if (head < tail)
				{
					Array.Copy(array, head, newArray, 0, tail);
				}
				else
				{
					Array.Copy(array, head, newArray, 0, array.Length - head);
					Array.Copy(array, 0, newArray, array.Length - head, tail);
				}
			}
			array = newArray;
			tail = Count;
			head = 0;
		}

		public void Clear()
		{
			array = new T[DefaultCapacity + 1];
			head = 0;
			tail = 0;
		}

		public bool TryDequeue(out T result)
		{
			if (IsEmpty())
			{
				result = default(T);
				return false;
			}

			result = array[head];
			MoveNext(ref head);
			return true;
		}


		public bool TryPeek(out T result)
		{
			if (IsEmpty())
			{
				result = default(T);
				return false;
			}

			result = array[head];
			return true;
		}
	}
}
