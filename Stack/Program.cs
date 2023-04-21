namespace Stack
{
    internal class Program
	{
		/******************************************************
		 * 스택 (Stack)
		 * 
		 * 선입후출(FILO), 후입선출(LIFO) 방식의 자료구조
		 * 가장 최신 입력된 순서대로 처리해야 하는 상황에 이용
		 ******************************************************/

		static void Test()
		{
			Stack<int> stack = new Stack<int>();

			for (int i = 0; i < 5; i++) stack.Push(i);  // 입력순서 : 0 1 2 3 4

			Console.WriteLine(stack.Peek());            // 최상단 : 4

			while (stack.Count > 0)
			{
				Console.WriteLine(stack.Pop());         // 출력순서 : 4 3 2 1 0
			}
		}
		public static bool ParenthesesChecker(Stack.MyStack<char> mystack)     //MyStack을 이용한 괄호검사기 함수
		{
			int count = mystack.Count;                                    //스택의 배열값의 갯수를 저장
			if (mystack.Peek() == '(')                                      //'('가 마지막일경우 무조건 false이므로 처음에 제외
				return false;
			else
			{
				int answer = 0;
				for (int i = 0; i < count; i++)
				{
					switch (mystack.Pop())                                 //스택에서 값을 하나씩 뺌
					{
						case '(':
							answer++;
							break;
						case ')':
							answer--;
							break;
					}
				}
				return answer == 0;         //'('이면 +1 ')' -1해서 둘의 짝이 맞으면 0이 나올 것이고 맞지 않다면 0외에 값이 나올 것임 그것을 0과 비교한 값을 반환
			}
		}


		static void Main(string[] args)
        {
			Stack.MyStack<char> stack = new Stack.MyStack<char>();
			stack.Push('(');
			stack.Push('(');
			stack.Push(')');
			stack.Push(')');
			stack.Push(')');
			Console.WriteLine(ParenthesesChecker(stack));
		}
    }
}