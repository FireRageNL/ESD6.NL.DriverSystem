pipeline{
    agent any
    stages{
        stage('Build project'){
            steps {
                sh 'dotnet restore'
				sh 'dotnet msbuild'
            }
        }
		stage('Test project'){
			steps{
				sh 'dotnet test'
			}
		}
    }
}