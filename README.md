# iot-webapp-2025

<p>IoT 개발자 과정 <a href="https://dotnet.microsoft.com/ko-kr/apps/aspnet">ASP.NET Core</a> 학습 리포지토리</p>

## 1일차

### Web
- 인터넷 상에 사용되는 서비스 중 하나
- 웹을 표현하는 기술 : HTML(Hyper Text Markup Language). XML(eXtensable Markup Language)의 경량화 버전
- 2014년 이후 HTML5로 적용되고 있음

#### 웹 기술
- 웹 표준기술(프론트엔드) : HTML5(웹 페이지 구조) + CSS3(디자인) + JavaScript6(인터렉티브)
- 웹 `서버`기술(백엔드) : ASP.NET Core(C#|VB), SpringBoot(Java), Flask|dJango(Python), CGI(PHP, C), Ruby, ...
- 웹 서비스 : 프론트엔드 + 백엔드
- 웹 브라우저 상에서 동작 : 현재는 웹 브라우저 상에서만 동작하는 경계가 사라졌음

#### HTML 5
- 웹 페이지를 구성하는 언어(근간, 기본)
- HTML 상에서도 디자인을 할 수 있으나, 현재는 CSS로 분기

### CSS 3
- Cascading Style Sheet : 객체 지향에 사용되는 부모 자식 관계로 디자인하는 기술
- 아주 쉬운 문법으로 구성됨

#### JavaScript 6
- 표준명 ECMAScript 2024
- Java와 전혀 관계없음. Java의 문법을 차용해서 사용한 웹 스크립트 언어
- 엄청난 발전을 이뤄 여러가지 기술로 분리
    - React.js, View.js 등의 프론트엔드 기술 언어로 분파
    - Node.js와 같은 웹 서버기술에도 적용
    - VS Code(아톰에디터 기반) 같은 개발도구를 만드는데도 사용
    - 3D 게임, 모바일 개발 등 다양한 분야에 사용

#### 웹 서버 기술
- `ASP.NET Core` : C#/VB 언어도 웹 서버를 개발
- SpringBoot, Flask 등 다른 언어로 웹 서버를 개발해도 무방

#### 왜 웹을 공부해야 하나?
- 스마트팩토리 솔루션을 대부분 웹으로 개발(사용 범위 제약을 없애기 위해)
    - 웹 사이트, 일부분 - 모바일 앱, 동시 개발
- 스마트홈(IoT), ERP, 호텔 예약, 인터넷뱅킹, 온라인 서점, ...
- 모든 IT/ITC 개발에 웹 기술은 포함되어 있음'

#### HTTP
- HyperText Transfer Protocol
- 웹을 요청/응답하는 프로토콜
- HTTPs : HTTP with secure. 보안을 강화한 HTTP 프로토콜

### 웹 표준기술 HTML

#### VS Code 확장설치
- Live Server

#### HTML 구조
- [소스](./day01/html01.html)
- html 태그 내에 head, body로 구성(무조건!)
- README.md에도 HTML 코드를 그대로 사용 가능(heading은 적용 불가)
- VS Code에서 html:5 자동생성
- [소스](./day01/html02.html), [소스](./day01/html03.html)
- CSS가 소스라인을 많이 사용. css는 외부 스타일로 분리 사용
- JS도 소스라인이 매우 김. JS도 외부 스크립트로 분리 사용
- 웹 브라우저의 개발자 모드(F12)로 디버깅을 하는 것이 일반적

#### HTML 기본 태그(body에 사용)
- [소스](./day01/html04.html)
- h1 ~ h6 : 제목 글자
- p, br, hr : 본문, 한 줄 내려가기, 가로줄
- a : 링크
- b/strong, i, small, sub, sup, ins/u, del : 굵은체, 이탤릭체, 작은 글씨, 아래첨자, 위첨자, 밑줄, 취소선
- Ul/ol, li : 동그라미 목록/순법 목록, 목록아이템
- table, tr, th, td : 테이블, 테이블로우, 테이블 헤더, 테이블컬럼
- img, audio, video :  이미지, 오디오, 비디오
- [소스](./day01/html05.html), (./day01/html06.html)
- form, input, button, select, textarea, label : 입력 양식, 텍스트박스, 버튼, 콤보박스, 여러줄텍스트, 라벨
- progress : 진행률
- div, span : 공간 분할

#### 공간 분할 태그
- [소스](./day01/html07.html)
- div 사용 이전엔 table, tr, td로 화면 분할을 활용
- table을 여러 번 중복하면 렌더링 속도 저하로 화면이 빨리 표시되지 않음
- 웹 기술 표준을 적용해 div 태그로 공간 분할 시작
- div를 CSS로 디자인 적용 해서 렌더링 속도를 빠르게 변경
- 게시판 목록, 상세보기 등에서는 아직도 table 사용 중

#### 시맨틱웹
- 웹 구조를 좀 더 구조적으로 세밀하게 구분짓는 의미로 만들어진 웹 구성 방식
- 시맨틱 태그
    - header, nav, main, section, aside, article, footer 등
    - 기본 HTML 태그가 아니고 필수도 아님
- 최근에는 잘 사용하지 않음. div 태그에 id로 부여해 유사하게 사용 중
- div만 잘 쓰면 됨

### 웹 표준기술 - CSS

#### 개요
- 마크업 언어에 표시방법을 기술하는 종속형 시트(계단식 스타일 시트)
- WPF는 CSS와 유사한 방식을 차용
- 문법
    ```css
    태그/아이디/클래스{
        /* key : value를 반복 */
        key : value; ./* C++ 주석 // 한줄 주석은 안됨 */
    }
    ```
- html 태그 속성
    - id : 웹페이지 하나당 한 번만 쓸 것
    - class : 여러 번, 여러 개 사용 가능

- UI 기술로 많은 분야에서 사용
    - Qt, PyQt, Electron, Flutter(모바일), React Native(모바일), React.js, ...

- [소스](./day01/html08.html)


## 2일차

### 웹 표준 기술 - CSS
- HTML, CSS, JS 동일하게 "(쌍따옴표), '(홑따옴표) 동시 사용 가능
- Python 은 '' 추천, 웹은 ""를 추천
- 스타일부터 레이아웃까지 연습
- [소스](./day02/html04.html)

### 웹 표준 기술 - JavaScript
- Java(컴파일러언어)와 아무런 관계 없음
- JavaScript(스크립트 언어) -> 실행 파일 X
- [소스](./day02/html05.html)

#### 기본 문법
- HTML 내에 script 태그 내에 작성
- 변수 선언이 var(전역, 지역), let(지역)
- 문장 끝에 ; 생략이 가능하지만 되도록 사용할 것
- 키워드

    <img src="./image/web001.png" width=600>

- 화면 메시지 박스 : alert()
- 디버깅 출력 : console.log()

    ```js
    <script>
        // 변수 선언
        var radius = 10;
        var PI = 3.14259265;

        // 출력
        alert(2 * radius * PI)
        console.log(2 * radius * PI)
        // 개발자 도구 > 소스에서 디버깅 가능
        // VisualStudio와 동일
    </script>
    ```
- 변수 타입 : 숫자, 문자열, 불린, ...
    - null : undefined
- 연산자 : 비교연산자, 수식연산자, 논리연산자, ...
    - 차이점 : === (타입과 값이 완전 일치)
- 흐름제어 : if, for, while
- 함수 : function 함수명
    - 익명함수 function() {}
- 거의 대부분 C 문법과 동일

#### JavaScript 객체
- [소스](./day02/html06.html)
- JSON : 자바스크립트 객체를 표현하는 방식
- 매우 편리하여 표준으로 지정하고 모든 IT분야에서 사용 중

    ```js
    var json_data = {
        key1 : value1,
        key2 : value2,
        method : functioni(){
            // ...
        },
    }
    ``

#### DOM
- [소스](./day02/html07.html)
- Document Object Model : HTML 문서의 구조를 JS에서 접근할 수 있는 개념
- HTML 태그를 JS로 조작한다는 의미
- JS에서 가장 중요한 부분 - 전통적인 JS 처리방식(구닥다리)
- DOM에서 쓰이는 주요 함수들

    ```js
    // 1개 선택
    document.querySelector(선택자);
    document.getElementById(아이디);
    // 다중 선택
    document.querySelectorAll(선택자); // for문으로 후처리
    document.getElementsByName(이름);
    document.getElementsByClassName(클래스);

    // 객체변수
    var obj = document.getElementById("container");
    obj.style.backgroundColor = 'red';
    obj.style.color = 'blue';
    obj.innerHTML = "변경 문자열";
    obj.getAttribute("속성");
    obj.setAttribute("속성", 변경할 값);

    window.onload = function(event){
        // ...
    }
    ```

#### jQuery
- JavaScript DOM의 복잡한 사용법을 개선하고 만든 라이브러리
- 2006년도 개발, 2023년까지 업데이트
- https://jquery.com/
- Vanilla JS(순수 JS) 방식으로 변경되고 있음
- CDN 방식으로 사용
    ```html
    <script src="https://code.jquery.com/jquery-3.7.1.min.js" integrity="sha256-/JqT3SQfawRcv/BIHPThkBvs0OEvtFFmqPF/lYI/Cxo=" crossorigin="anonymous"></script>
    ```
- 모든 DOM 객체에 접근할 때 `$(선택자|아이디|클래스)`로 처리
- jQuery on('이벤트', function() {}) 또는 이벤트(function() {})

    <img src="./image/web002.png" width="600">
- [소스](./day02/html09.html)

#### Vanilla JS
- 순수 JS로 불리며 jQuery처럼 CDN링크가 필요 없음
- 전통적 방식보다 효율적으로 변경됨
- 새로 개발되는 웹사이트는 Vanilla JS를 사용
 
## 3일차

### 반응형웹
- UTF-8이 적용되기 전 : 한국어웹, 영어웹, 일본어웹 등 웹페이지를 언어별로 개발 ㅠㅣㄹ요
- 반응형 웹 이전 : 모바일용, PC용, 태블릿용 등 따로 웹사이트를 개발해야 함
- 문제 : 하나의 웹페이지가 수정되면 다른 웹페이지들도 다 수정 -> 시간, 돈의 Loss
- 하나의 웹페이지로 기기, 언어 문제를 전부 해결하고자 나온 기술 중 화면 쪽 -> 반응형 웹
- `Responsive Web` : 웹, 모바일 등의 기기와 해상도에 상관없이 하나의 웹으로 모두 표현할 수 있는 웹하면 개발 기술

- HTML5에 반응형 웹 메타태그만 사용

    ```html
    <!DOCTYPE html>
    ...
    <head>
    <!-- 반응형 웹 중요 태그 -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    ```

- 부트스트랩으로 학습
- https://inpa.tistory.com/category/Style%20Sheet/Bootstrap5?page=2

### 부트스트랩
- 현재 전세계적으로 가장 많이 사용되는 오픈소스 CSS, JS 프레임워크
- 트위터 블루프린트로 시작. 트위터 웹사이트를 꾸미기 위해 개발 시작
- 현재 5.3 버전
- 이전에는  jQuery 사용했으나 현재는 Pure JS로 전향되었음
- [공식사이트](https://getbootstrap.com/)

#### 부트스트랩 시작
- [시작](https://getbootstrap.com/docs/5.3/getting-started/introduction/)
- GetStarted에 나와있는 CSS와 JS를 웹페이지에 붙여넣기

    <img src="./image/web003.png" width="600">

#### 부트스트랩 학습
- 버튼 사용법

    <img src="./image/web004.png" width="600">

- 미디어 쿼리 : 웹페이지 사이즈에 따른 사용법을 위해 필요                                                     
    - Bootstrap에서 sm, md, lg 등의 infix를 사용할 경우가 많음
    - X-Small : None(사용할 이름 없음) (< 576px)
    - Samll : sm (>= 576px)
    - Medium : md (>= 768px)
    - Large : lg (>= 992px)
    - Extra large : xl (>= 1200px)
    - Extra extra large : xxl (>= 1400px)

- 컨테이너 : 기본 레이아웃에서 가장 중요! 그리드 스타일이라고 부름
    - container - 일반적인 넓이 사용. 양쪽에 여백이 존재
    - container-fluid - 여백없이 웹페이지를 꽉 채우는 스타일
    - container > row > col 형식으로 사용
    - 각 grid는 최대 12개까지 사용

- 정렬 클래스
    - * : start, center, end
    - text-*
    - align-items-*
    - align-self-*
    - justify-content-*

- 거터 : 갭(안쪽여백), padding과 동일
    - g, gx, gy, g-number, gx-number, gy-number
    - number : 1 ~ 5 사용 가능
    - g : gx + gy
    - gx : 왼쪽, 오른쪽 안여백
    - gy : 위쪽, 아래쪽 안여백

- 여백을 위한 클래스
    - number포함 : 1 ~ 5까지
    - p, ps, pt, pd, pe, px, py : padding 
    - m, ms(left), mt, mb, me(right), mx, my : margin
    - start, top, end, bottom : 배율로 조정

- 컴포넌트 학습
    - Accordion
    - Alert : Button 클래스와 동일 primary ~ light(link는 없음)
    - Breadcrumb : 메뉴 경로
    - Navbar, Navs & tabs : 메뉴 내비게이션바
    - Button, Close button, Button group : 버튼 관련 컴포넌트
    - Card, Placeholders, Model, `Popovers`, Toasts, `Tooltips` : 화면 영역 컴포넌트
    - Pagination : 게시판 페이지 컴포넌트
    - Progress, Spinners : vmfhrmfptmqk, 대기용 컴포넌트
    - Carousel : 이미지 갤러리

    <img src="./image/web005.png" width="600">

- 아이콘
    - [사이트](https://icons.getbootstrap.com/)
    - 부트스트랩이 지원해주는 아이콘
    - Python PyQt, leaflet.js(Folium) 등에도 사용 가능
    - FontAwesome, XEICon, Google Icon Fonts

#### 이미지팁
- 화면 UI 설계시 이미지 찾는 시간을 절약하기 위해 만든 사이트
- placehold image Site
    - [플레이스홀드](https://placehold.co/)
    - [로렙플릭커](https://loremflickr.com/)
    - [로렘픽섬](https://picsum.photos/)(추천)

#### 부트스트랩 템플릿 사이트
- 유료
    - https://wrapbootstrap.com/templates
    - https://themeforest.net/search/sns%20bootstrap : 필요한 소스코드 구매 가능
    - https://themewagon.com/theme-price/pro/

- 무료
    - https://startbootstrap.com/ : 무료 템플릿 중 최고
    - https://bootswatch.com/
    - https://bootstrapmade.com/ : 출처를 표기해야 함
    - https://themewagon.com/theme-price/free/
    - https://graygrids.com/templates?type=free

### 프론트엔드 활용
- HTML5 + CSS3 + JS + BootStrap 응용예제
    - Bootstrap Image Gallery

    https://github.com/user-attachments/assets/c66b92d9-60fb-4d37-a7a4-67646faf1ef4

## 4일차

### 프론트엔드 활용
- HTML5 + CSS3 + JS 응용예제


### ASP.NET Core
