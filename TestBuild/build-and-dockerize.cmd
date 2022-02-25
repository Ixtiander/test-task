pushd .
cd ..\react-app
docker build -f Dockerfile . -t react-ui --build-arg REACT_APP_API_ROOT="http://localhost:8081/api"
cd ..\NetServer\TestApplication.Web
docker build -f Dockerfile .. -t net-server
popd
pause