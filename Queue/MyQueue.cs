using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    internal class MyQueue<T>
    {
        private const int DCapacity = 8;            //배열의 길이
        private T[] array;                                 //배열
        private int head;                                   //값을 불러오는 곳
        private int tail;                                      //값을 넣는 곳

        public MyQueue()
        {
            array = new T[DCapacity];                //초기값
            head = 0;
            tail = 0;
        }
        private void MoveNext(ref int index)   //배열을 원형배열로 만들어주는 함수
        {
            index = (index == array.Length - 1) ? 0 : index + 1;      //끝까지 가면 다시 처음으로 보내줌
        }
        public bool IsEmpty()                           // 비어있으면 true 아니면 false를 반환하는 함수
        {
            return head == tail;
        }

        public bool IsFull()                               //꽉차있으면 true 아니면 false를 반환하는 함수
        {
            if(head > tail)                                   //head가 tail앞에 있으면
            {
                return head == tail + 1;
            }
            else                                                  //head가 tail뒤에 있으면
            {
                return head == 0 && tail == array.Length - 1;
            }
        }

        public T Dequeue()                                //head에 있는 값을 불러오고 빼는 함수
        {
            if (IsEmpty())                                 //예외처리
                throw new InvalidOperationException();

            T result = array[head];                   //head에 있는 값을 불러옴
            MoveNext(ref head);                     //head를 다음 칸으로 옮김
            return result;                                 //head를 반환함
        }

        public T Peek()                                   //head에 있는 값을 불러오는 함수
        {
            if (IsEmpty())                                 //예외처리
                throw new InvalidOperationException();

            return array[head];
        }

        public int Count                                   //배열 속 자료의 갯수를 알려주는 함수
        {
            get
            {
                if (head <= tail)                          //배열이 비어있거나 head가 tail보다 작을때
                    return tail - head;
                else                                           //head가 tail보다 클때
                    return tail + array.Length - head;
            }
        }

        private void Grow()                            //배열이 꽉 찼을 때 배열을 늘려주는 함수
        {
            int newCapacity = array.Length * 2;       //배열의 크기를 두배로 늘림
            T[] newArray = new T[newCapacity + 1];    //배열을 만듦
            if (head < tail)                                           //head가 tail보다 작을 때
            {
                Array.Copy(array, head, newArray, 0, tail);      //배열을 그냥 복사
            }
            else                                                            //head가 tail보다 클때
            {
                Array.Copy(array, head, newArray, 0, array.Length - head);       //해드와 배열의 끝 사이에 있는 값을 복사
                Array.Copy(array, 0, newArray, array.Length - head, tail);         //배열의 처음부터 tail까지의 값을 복사
            }
            array = newArray;                                     //배열을 새로 만든 배열로 바꿈
            tail = Count;                                               // tail을 배열에서 값이 들어있는 마지막으로 옮김
            head = 0;                                                   // head를 맨앞으로 옮김
        }

        public void Enqueue(T item)                               //배열에 값을 넣는 함수
        {
            if (IsFull())                                  //배열이 꽉 차있을 때
            {
                Grow();                                    //배열을 크게 만듦
            }

            array[tail] = item;                        //tail에 값을 넣음
            MoveNext(ref tail);                     //tail을 다음 칸으로 놓음
        }
    }
}
