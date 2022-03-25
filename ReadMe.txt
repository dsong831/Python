# 유용한 packages (방화벽 제거 버전)
pip install gitpython --trusted-host pypi.python.org --trusted-host files.pythonhosted.org --trusted-host pypi.org
pip install pyinstaller --trusted-host pypi.python.org --trusted-host files.pythonhosted.org --trusted-host pypi.org
pip install python-docx --trusted-host pypi.python.org --trusted-host files.pythonhosted.org --trusted-host pypi.org
pip install xlsxwriter --trusted-host pypi.python.org --trusted-host files.pythonhosted.org --trusted-host pypi.org
pip install yattag --trusted-host pypi.python.org --trusted-host files.pythonhosted.org --trusted-host pypi.org
pip install openpyxl --trusted-host pypi.python.org --trusted-host files.pythonhosted.org --trusted-host pypi.org
pip install pandas --trusted-host pypi.python.org --trusted-host files.pythonhosted.org --trusted-host pypi.org

# 셔뱅(shebang)
현재 파일을 실행해 줄 프로그램을 지정할 때 사용.
셔뱅을 사용하면 ./hello.py 처럼 python3를 붙이지 않아도 파이썬 스크립트 파일을 실행할 수 있음.
#!/usr/bin/env python3

# python to exe
$ pip install pyinstaller
$ pyinstaller --onefile file_name.py
dist 디렉토리 안에 file_name.exe 파일 확인

# python script에서 한글 문자를 사용하려면 UTF-8 형식으로 저장해야 함
# python 코드블록은 공백 4칸 or 탭 을 사용하는게 기본이다.
# 기본연산
    int : 정수 / float : 실수 / complex : 복소수
    a // b : 나누기 하되, 버림 적용
    a ** b : 거듭제곱
    a % b : 나누기 하되, 나머지 구하기

# 튜플(tuple) : 파이썬에서 값을 괄호로 묶은 형태를 의미
    (5, 2)
# 입력 값을 변수에 할당하는 법
    변수 = input()
    변수1, 변수2 = input().split('기준문자열')
    변수1, 변수2 = map(int, input().split())    # 값 두 개를 입력 받아 변수 두 개에 정수 형태로 저장
# 출력 값 사이에 문자 넣는 법
    print(변수1, 변수2, sep='문자 또는 문자열')
    print(변수1, end=' ')    # print 함수의 자동 개행 제어문자 없애기

# 객체 비교하기
    ==, != 는 값 자체를 비교하고 is, is not 은 객체를 비교함
    값(숫자)를 비교할 때는 is가 아닌 비교 연산자(==)를 사용해야 함

# 리스트를 생성할 때는 [ ] 를 사용하고, 튜플을 생성할 때는 ( ) 를 사용. 튜플은 읽기 전용 리스트 (수정 안됨)

# 2차원 배열 정렬
예시)
list = [['a', 'A'], ['b', 'B']]
list = sorted(list, key=lambda list: list[1])
// 안쪽 배열 index 1 을 기준으로 정렬 ('A', 'B')

# 문자열의 특정 문자 삭제하기
>>> ', python.'.strip(',.')
' python'

# 파일 처리하기
with open(파일 이름, 파일 모드) as 파일객체
    코드
// with as 를 사용하면 자동으로 파일객체를 닫아 줌

# 파일의 내용 줄 단위로 읽기
with open('hello.txt', 'r') as file:    // hello.txt 파일을 읽기 모드(r)로 열기
    for line in file:                             // for에 파일 객체를 지정하면 파일의 내용을 한줄씩 읽어서 변수에 저장 함
        print(line.strip('\n'))               // 파일에서 읽어온 문자열에서 \n 을 삭제하여 출력

# 함수의 인수에 리스트나 튜플을 넣을 때에는 언패킹 해서 넣어줘야 함
// 리스트나 튜플 앞에 *(애스터리스트)를 붙여서 함수에 넣으면 언패킹 됨
>>> x = [10, 20, 30]
>>> print_numbers(*x)
10
20
30

# 함수의 인수에 딕셔너리를 넣을 때에는 언패킹 해서 넣어줘야 함
// 딕셔너리 앞에 **(애스터리스트 두개)를 붙여서 함수에 넣으면 언패킹 됨

# 가변 인수 함수 만들기
def 함수이름(* 매개변수):
    코드

# 키워드 인수를 사용하는 가변 인수 함수 만들기
def 함수이름(** 매개변수):
    코드
>>> def personal_info(**kwargs):
    for kw, arg in kwargs.items():
        print(kw, ' : ', arg, sep=' ')

# 고정 인수와 가변 인수를 함께 사용하기
def print_numbers(a, *args):
    print(a)
    print(args)
>>> print_numbers(1)
1
()
>>> print_numbers(1, 10, 20)
1
(10, 20)
>>> print_numbers(*[10, 20, 30])
10
(20, 30)

# 클래스와 메서드 만들기
class 클래스이름:
    def 메서드(self):
        코드
// 메서드의 첫번째 매개변수는 반드시 self를 지정해야 함
// 클래스는 특정 개념을 표현만 할 뿐, 사용하려면 인스턴스(객체)를 생성해야 함
// 메서드는 클래스가 아니라 인스턴스(객체)를 통해 호출 됨

# 클래스에 속성 만들기
class 클래스이름:
    def __init__(self):
        self.속성 = 값
// 속성(attribute)을 만들때는 __init__ 메서드 안에서 self.속성에 값을 할당

