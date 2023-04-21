using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
	internal class MyStack<T>
	{
		private const int DefaultCapacity = 8;            //기본 크기

		private T[] array;                                         //기본 배열
		private int topIndex;                                    //배열 인덱스

		public MyStack()
		{
			array = new T[DefaultCapacity];
			topIndex = -1;
		}

		public int Count { get { return topIndex + 1; } }       // 배열에 값이 들어가있는 갯수

		private bool IsEmpty()                  //배열이 비어있는지 확인하고 맞으면 true값을 안비어 있다면 false값을 반환하는 함수
		{
			return Count == 0;
		}
		 
		private bool IsFull()                   //배열이 꽉차있는지 확인하고 맞으면 true값을 안꽉차있다면 false값을 반환하는 함수
		{
			return Count == array.Length;
		}

		public void Clear()                                       //배열을 초기화 하는 함수
		{
			array = new T[DefaultCapacity];
			topIndex = -1;
		}

		public T Peek()                                      //배열에서 값을 반환하는 함수
		{
			if (IsEmpty())
				throw new InvalidOperationException();

			return array[topIndex];                  //인덱스가 가리키는 값 반환
		}

		public T Pop()                                  //값을 반환하고 맨 뒤의 값을 빼는 함수
		{
			if (IsEmpty())
				throw new InvalidOperationException();

			return array[topIndex--];          //값을 반환하고 인덱스를 하나 뺌
		}
		private void Grow()                        //배열을 크게 하는 함수
		{
			int newCapacity = array.Length * 2;         //배열의 크기를 두배로 늘림
			T[] newArray = new T[newCapacity];       //크기를 두배로 늘린 배열을 만듦
			Array.Copy(array, 0, newArray, 0, Count);     //배열안의 값을 새로운 배열에 복사함
			array = newArray;                 //새로운 배열을 반환함
		}

		public void Push(T item)                 //값을 넣는 함수
		{
			if (IsFull())                               //배열이 꽉 차있을 때
			{
				Grow();                                 //배열을 크게하는 함수를 실행
			}
			array[++topIndex] = item;        //인덱스 다음 배열에 받은 값을 넣음.
		}

	}
}
