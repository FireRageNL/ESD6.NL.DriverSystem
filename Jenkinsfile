pipeline{
    agent any
    stages{
        stage('Build project'){
            steps {
                sh 'dotnet restore'
				sh 'dotnet build'
            }
        }
    }
}