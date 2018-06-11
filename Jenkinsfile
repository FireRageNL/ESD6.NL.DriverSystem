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
				sh "dotnet test ${env.WORKSPACE}/ESD6.NL.DriverSystem.UnitTests/ESD6.NL.DriverSystem.UnitTests.csproj"
			}
		}
		stage('Build Docker Container'){
			steps{
				sh "dotnet publish -c Release -o publish"
				sh "docker build -t driversystem ./ESD6NL.DriverSystem"
				sh "docker tag driversystem:latest esd6nl/driver"
			}
		}
		stage('Push Image'){
			steps{
				withCredentials([usernamePassword(credentialsId: 'docker', passwordVariable: 'dockerPassword', usernameVariable: 'dockerUser')]) {
					sh "docker login -u ${env.dockerUser} -p ${env.dockerPassword}"
					sh 'docker push esd6nl/driver'
			}
			sshagent(credentials: ['38e51386-2cad-4c7e-b7a2-6d1c282d49f4']){
				sh 'ssh student@192.168.25.122'
				sh 'touch testfile'
			}
			}
		}
    }
}