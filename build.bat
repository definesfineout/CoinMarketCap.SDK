@echo Off
set config=%1
if "%config%" == "" (
   set config=Release
)
 
REM set version=1.0.0
REM if not "%PackageVersion%" == "" (
REM    set version=%PackageVersion%
REM )

REM set nuget=
REM if "%nuget%" == "" (
REM 	set nuget=nuget
REM )

dotnet msbuild CoinMarketCap\CoinMarketCap.csproj /p:Configuration="%config%" /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=diag /nr:false
dotnet pack CoinMarketCap\CoinMarketCap.csproj --configuration %config% --verbosity detailed --include-symbols
