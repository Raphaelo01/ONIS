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
- MySQL 8

## Prerequisites

- Docker last version

## Installation

  - Run docker-compose
  -   To start services use docker-compose up -d 
  -   To stop services use docker compose down  
  - Run Dockerfile
  

## Usage

- use http://localhost:9000/streams to access grylog page
- user and password: admin
- go to System-Inputs
- on Inputs select GELF UDP then Launch
- Just modify Title adding for example SerilogAPI 
- at this moment when you ask endpoint getallProducts, the endpoint generate a simple message just at this moment for test
- api EndPoint https://localhost:44368/swagger/index.html



