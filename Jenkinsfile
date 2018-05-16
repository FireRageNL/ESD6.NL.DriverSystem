pipeline{
    agent any
	tools{
	sonar 'scanner'
	}
    stages{
        stage('Build project'){
            steps {
                sh 'dotnet restore'
				sh 'dotnet msbuild'
            }
        }
		stage('Test project'){
			steps{
				sh "dotnet test ${env.WORKSPACE}/ESD6.NL.DriverSystem.UnitTests/ESD6.NL.DriverSystem.UnitTests.csproj"
			}
		}
		stage('Execute SonarQube Scanner'){
			steps{
				sh "dotnet sonar begin /k:'Project-test' /d:sonar.host.url=http://192.168.25.121:9000 /d:sonar.login=33d2bf0931e4ba870789a1cf8e6276a20de55fe1'"
				sh "dotnet build"
				sh "dotnet sonar end"
			}
		}
    }
}