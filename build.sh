#!/bin/sh

npm install
dotnet ./SonarCloud/SonarScanner.MSBuild.dll begin /k:"KekManager" /d:sonar.organization="eragra3-github" /d:sonar.host.url="https://sonarcloud.io" /d:sonar.login="ee89d26215f97e2f576e0577e990cc8ecb1c2d2c"
dotnet build
dotnet ./SonarCloud/SonarScanner.MSBuild.dll end /d:sonar.login="ee89d26215f97e2f576e0577e990cc8ecb1c2d2c"
