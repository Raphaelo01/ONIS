# Excersice Web API (Draft)

    This is a little example of endpoint using .NET 7 
    (this code is on development maybe you get some errors when you start testing)

## Features

- Access to Product catalog endpoint

## Technologies Used

- NET Core 7
- GrayLog 4.2.5
- SQL Server for Linux 2019
- MongoDB
- Elasticsearch
- Rabbitmq:3.8.34-management-alpine

## Prerequisites

- Docker last version

## Installation

  - To use Docker via Windows/Mac/Linux visit https://docs.docker.com/engine/install/
  - To execute via Docker follow Usage secction

## Usage

- Run docker-compose
-   To start services use docker-compose up -d 
-   To stop services use docker compose down  

- Configure and use Serilog  
- Use http://localhost:9000/streams to access grylog page
- Use http://localhost:15672/ to access rabbitmq managment
- User and password: admin
- Go to System-Inputs
- On Inputs select GELF UDP then Launch
- Just modify Title adding for example SerilogAPI 
- At this moment when you ask endpoint getallProducts, the endpoint generate a simple message just at this moment for test

- Use APIS
- API Catalog EndPoint http://localhost:5102/Products/getallProducts (at this moment my container doen't work when I execute docker logs mycontainerid my container still no launch ports for listen, but if the api runs out of the container works perfect)
- API Order is not up to day, I had some problems with it container and I'm rebuilding



