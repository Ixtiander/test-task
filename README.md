# Test application


## Decription

The solution consists of the server and the client applications.
Docker (v20.10.12) and Compose (v2.2.3) are needed to build the images and run. Previous versions may work, but not tested.
Multistage build process is used to avoid dependencies on the target machine.

## Server application

Built with .Net 6 and C#.
EF Migrations create and populate the Database with data. It may take some time on the first run

## Client application

Built with React and Typescript

## Database
Postgres is used as a storage.

## Deploying to Docker

To build Docker images run the following commands:
```
> cd TestBuild
> build-and-dockerize.cmd

```

To run the Docker containers run the following command:
```
> cd TestBuild
> docker-compose up -d

```