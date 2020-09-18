using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0918
{
	class Person
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public Person(string fname, string lname)
		{
			this.FirstName = fname;
			this.LastName = lname;
		}

		//tostring을 값을 반환 받고싶을때 재정의해서 쓸수있다
		public override string ToString()
		{
			#region 1번 방법
			//string val = $"성 : {this.FirstName}\n이름 : {this.LastName}";
			//return $"성 : {this.FirstName}\n이름 : {this.LastName}"; //한줄로도 가능
			#endregion
			#region 2번째 코드 이렇게도 가능
			// 문자열을 +연산으로 하면  정말 안좋은 코딩
			// 이렇게 문자열을 줄때마다 가비지가 나오게 됨
			// 가비지컬렉터가 일을 너무 많이 하게 됨
			/*
			string str = "======================== Person ========================\n";
			str += $" 성  : {this.FirstName}\n이름 : {this.LastName} \n";
			str += "========================================================\n";
			*/

			//한줄로도 가능
			string str = $"======================== Person ========================\n+" +
				$" 성  : {this.FirstName}\n이름 : {this.LastName} \n+" +
				$"========================================================\n";
			return str;
			#endregion
		}

		public override bool Equals(object obj) //Equals를 오버라이딩해 인스턴스 안에 값이 같은지 비교하게 만듬
		{
			#region 기본코딩
			//if (obj is Person)
			//{
			//	Person temp = (Person)obj;

			//	if (this.FirstName == temp.FirstName && this.LastName == temp.LastName)
			//		return true;
			//	else
			//		return false;
			//}
			//else
			//	return false;
			#endregion

			#region 요즘코딩으로 한줄로 쓰기

			//obj 가 Person 타입이면 temp에 형변환을 해서 넣어주고 그리고나서 내꺼와 재꺼의 퍼스트네임이 같고 라스트네임이 같으면  true 반환
			//하나라도 다르다면 false 반환
			return obj is Person temp && FirstName == temp.FirstName && LastName == temp.LastName; 
			
			#endregion
		}
		// 암호화 개념 두개의 인스턴스의 해쉬코드를 같게 만들어서 같은 값이라고 보게 만듬
		public override int GetHashCode()
		{
			int result = EqualityComparer<string>.Default.GetHashCode(FirstName);
			result += EqualityComparer<string>.Default.GetHashCode(LastName);

			return result;
		}

		public void PrintInfo()
		{
			Console.Write("이름 : {} /t{}");
		}

			
	}

	class Program
	{
		static void Main(string[] args)
		{
			Person per = new Person("류", "현진");
			//string str = per.ToString();
			Console.WriteLine(per.ToString()); //재정의 하기 전의 경우 per의 타입에대한 문자열만 나온다 ConsoleApp0918.Person출력

			//어떤 인스턴스가 어떤 타입인지 알아가지고 오는게 GetType()
			//2가지 방법 GetType()메서드 typeOf연산자
			//Type t1 = per.GetType();
			//Type t2 = typeof(Person);

			// 오브젝트안의 Equals는 인스턴스가 같냐 안같냐를 판단하는 메서드
			// 하지만 우리는 인스턴스가 아니라 그안에 값이 같냐를 보고싶음
			// 그래서 Override를 해야함
			Person per2 = new Person("류", "현진"); // new Person을 두번했으니 다른 인스턴스

			if(per.Equals(per2)) // 다른 이름이라고 나옴
				Console.WriteLine("동일한 이름입니다");
			else
				Console.WriteLine("다른 이름 입니다");

			string str = "류현진";
			string str2 = "류현진";
			if (str.Equals(str2)) // 같은 이름이라고 나옴
				Console.WriteLine("동일한 이름입니다");
			else
				Console.WriteLine("다른 이름 입니다");

			Console.WriteLine(per.GetHashCode());
			Console.WriteLine(per2.GetHashCode());


		}

	}

}
