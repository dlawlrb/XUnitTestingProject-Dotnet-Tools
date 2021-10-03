# XUnitTestingProject-Dotnet-Tools
## Overview
ASP.NET CORE(.NET5) 에서 여러 테스트를 지원하는 XUnit 프레임워크, Mock 패키지를 이용하여 유닛 테스트, 통합 테스트( + 기능 테스트) 를 간단한 형태로 구성해보았다.
이번에 집중한 내용은
- 테스트 유형별 차이점
- XUnit, Mock를 이용한 테스트 프로젝트 구현 방법
- 애플리케이션, 테스트 프로젝트의 명확한 역할을 나타내기 위한 디렉토리(패키지) 구성 방법
- 테스트의 목적과 역할을 명확히 나타내기 위한 명명규칙

이며 따라서 애플리케이션 프로젝트의 비즈니스 로직은 최대한 간단한 형태로 구성했다.

## 테스트 유형
- 단위 테스트
애플리케이션 논리의 단일 부분을 테스트한다.
종속성이나 인프라와 작동하는 방식은 테스트하지 않기 때문에 추가적으로 통합 테스트가 필요하다.
메모리와 프로세스에서 전적으로 실행되며 파일 시스템, 네트워크, 데이터베이스와 통신하지 않는다. 즉, 단위 테스트는 코드만 테스트한다.

- 통합 테스트
데이터베이스, 파일 시스템 등 인프라와 상호작용하는 과정까지 포함하여 테스트한다.
단위 테스트에 비해 속도가 더 느리고 설정도 어렵다.
따라서 단위 테스트로 테스트가 가능한 항목은 통합 테스트가 아니라 단위 테스트에서 하는 것이 좋다.

- 기능 테스트
통합 테스트가 개발자의 관점에서 시스템의 구성 요소가 모두 제대로 동작하는지 확인하는 과정이라면 
기능 테스트는 사용자의 관점에서 시스템의 정확성을 확인하는 과정이다.
구현 내용을 보면 두 테스트는 비슷한 경향이 있지만 관점의 차이라고 해석할 수 있다.

## 애플리케이션 - 테스트 프로젝트 디렉토리 구성
유형별(단위 테스트, 통합 테스트, 기능 테스트), 기능별(프로젝트, 네임스페이스)로 구분하는 것이 좋다.
테스트 프로젝트의 구성은 src 폴더 하위에 애플리케이션 프로젝트들을 구성하고
test 폴더 하위에 테스트 프로젝트를 테스트 유형별로 나눈 뒤 각 유형 내에 애플리케이션 별 테스트 프로젝트로 디렉토리를 구성하는 것이 좋은 방법이다.

## 테스트 클래스 명명규칙
테스트 이름은 각 테스트의 기능을 정확히 나타낼 수 있도록 일관된 방식으로 지정한다.
좋은 방법으로는 테스트 클래스의 이름을 테스트 할 클래스의 메서드 이름의 조합으로 만드는 것이다. 이 과정에서 많은 소규모 테스트 클래스가 만들어지지만 각 테스트의 역할이 명확해진다. 그리고 테스트 메서드의 이름은 예상되는 동작, 주어지는 입력과 가정을 포함한다.
예시)
CatalogControllerGetImage.CallsImageServiceWithId
CatalogControllerGetImage.LogsWarningGivenImageMissingException
CatalogControllerGetImage.ReturnsFileResultWithBytesGivenSuccess
CatalogControllerGetImage.ReturnsNotFoundResultGivenImageMissingException

## 결론
닷넷의 대표적인 테스트 프레임워크인 XUnit FrameWork 를 사용하여 테스트 프로젝트를 구성해보았다.
또한 실무나 대규모 프로젝트에서 사용될 수 있도록 명확한 역할을 나타내거나 공간을 분리하는 여러 규칙들을 배웠다.
이를 기반으로 다음 프로젝트에서는 방대해진 비즈니스 로직을 위한 테스트들을 더 강화하고 
AWS CodeBuild 같은 CI/CD 과정에서 테스트 자동화까지 구성할 수 있을 것으로 기대한다.