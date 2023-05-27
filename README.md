# .Net 7 Logging

This is an extension of the [.Net 7 Middlewares](https://github.com/maiconghidolin/Net-7-Middlewares) project.
Here I show a little example of how to use Serilog in .NET 7 project.

Used Tools and Technologies:
 - .NET 7
 - Serilog
 - Mongo 
 - Elastic Search 
 - kibana

On the folder of the project, execute:

```
docker-compose up -d
```

This will execute the Elasticsearch and Kibana containers.

You can also create a local MongoDB connection:

```
mongodb://localhost:27017/
```

Execute the project and send a request to the Home/Get/{id} route.

You will be able to see a log like this:

![log](https://github.com/maiconghidolin/Net-7-Logging/assets/2272948/dd040633-478a-4eb8-9f3e-127efa7459f7)
