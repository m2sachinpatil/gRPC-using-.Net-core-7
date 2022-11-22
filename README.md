
# gRPC and.NET7

A brief description of what this project does and who it's for

# Requirement 
- Time-based electricity consumption data
- Meter usage is captured every 15 min of interval ( Looks its unique value) 
- Collection to process time series data 

# Prerequisite:

- Download and install .NET 7 SDK
- Visual Studio 2022 17.4+

# Achievement 

    1. Create a gRPC service in .NET 7
    2. gRPC JSON Transcoding. -API Gateway provides protocol translation for your gRPC services on Cloud Run allowing clients to use HTTP/JSON to communicate with a gRPC service through the API Gateway.
    3. Consuming a gRPC Service Using Postman.
    4. Using Server reflection and Postman
    5. Add Swagger Specification.


# INPUT

https://github.com/m2sachinpatil/gRPC-using-.Net-core-7/blob/main/gRPC_Service/Input/meterusage.csv 


# OUTPUT

- gRPC server using postman 

![ezgif com-gif-maker (2)](https://user-images.githubusercontent.com/51775632/203187074-7a1387d4-1e1f-41c1-a16e-3bb758e571ea.gif)

- gRPC Client using swagger and Fornt end using HTTP call to client.  

<img width="1784" alt="image" src="https://user-images.githubusercontent.com/51775632/203185510-a65ae825-36fa-47cf-b30a-1073a02b8d53.png">




# Future Scope
- gRPC client caches connection
- gRPC Load Balancing
- introduce API gateway as BFF for multiple microservices
- Event sourcing using gRPC streams as Kafka replacement

Welcome with pull request. 

