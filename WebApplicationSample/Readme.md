
Password: Pass#word1

Docker Mongo:
docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db -e MONGO_INITDB_ROOT_USERNAME=mongoadmin -e MONGO_INITDB_ROOT_PASSWORD=Pass#word1 mongo

HealtCheck:
Es gibt NugetPackage für SQL Server: AspNetCore.HealthChecks.SqlServer
https://github.com/Xabaril/AspNetCore.Diagnostics.HealthChecks


Starten mit Network

docker network create net6tutorial
docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db -e MONGO_INITDB_ROOT_USERNAME=mongoadmin -e MONGO_INITDB_ROOT_PASSWORD=Pass#word1 --network=net6tutorial mongo
docker run -it --rm -p 8080:80 -e MongoDbSettings:Host=mongo -e MongoDbSettings:Password=Pass#word1 --network=net6tutorial catalog:v1

Kubernetes

Secrets:
 kubectl create secret generic webapplicationsample-secrets --from-literal=mongodb-password='Pass#word1'

Mongo DB Pod starten
kubectl apply -f mongodb.yaml

WebApi starten
kubectl apply -f webapplicationsample.yaml

Logs
kubectl logs webapplicationsample-deployment-588bcc64c-c7tdb

kubectl delete -f ./webapplicationsample.yaml     