# BlogEngine

BlogEngine is a demo project showing some techniques and approaches of developing a REST API application using ASP.NET Core as a base framework. Some things are not finished yet, and many other things are even not yet in development. The project is incomplete and is unlikely to ever be completed, as new approaches, libraries and practices will be constantly tested and successful ones will be adopted.

### Frameworks/Libraries Used:

* [AspNetCore](https://github.com/dotnet/aspnetcore)
* [EntityFrameworkCore](https://github.com/dotnet/efcore)
* [MassTransit](https://github.com/MassTransit/MassTransit)
* [MediatR](https://github.com/jbogard/MediatR)
* [Swashbuckle](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)
* [XUnit](https://github.com/xunit/xunit)

In Development:

* [AutoMapper](https://github.com/AutoMapper/AutoMapper)
* [FluentValidation](https://github.com/FluentValidation/FluentValidation)

### Getting Started
The easiest way to run the project is the Docker Compose. In the current implementation, 4 containers are launched:

* Articles Service
* Subscriptions Service
* SqlServer
* RabbitMQ

In real life, such a domain is likely to be implemented in a single context, but they were separated to demonstrate their interaction.

Before starting, you need to configure the services.

**Emails** in Subscriptions Service. **NotificationsFrom** is what your subscribers will see in the _FROM_ field of the email. Make sure your SMTP provider allows you to use the value specified here.
```js
"Emails": {
  "NotificationsFrom": "some@email.com"
},
```

**SMTP** in Subscriptions Service. These settings are default for any SMTP provider. If you don't have one or don't know one you can use [sendinblue.com](https://sendinblue.com). It's free for a reasonable amount of daily emails.
```js
"Smtp": {
  "Host": "host",
  "Port": 587,
  "Username": "username",
  "Password": "password"
}
```

If you are running with the default docker-compose and have no other RabbitMQ or SqlServer containers running on your Docker Host with default ports, there is no need to configure anything else for everything to work. 

### Services
The Solution consists of a Core with class libraries shared and reused in Services.

**Articles**

This service is responsible for Article management. We can Get and Article by ID, Get a list of all Articles, Get a list of all Articles with a specified HashTag and Create Comments on the Article as an unauthorized user. We must authorize (Basic Auth is used currently) to Create, Update and Delete Articles and Delete Comments. Every time a new Article is created or updated, its content is parsed for HashTags and the Article is associated with that HashTag. Also an ArticleCreatedEvent is published each time a new Article is created.

**Subscriptions**

This service is responsible for Subscriptions management. A User may subscribe to HashTags with their email and get a notification when new Article is created with that HashTag. 

### Service Architecture
**Domain and Events**

Each Service is built around a Domain and Events class libraries. Here has been applied the [Rich Domain](https://thevaluable.dev/anemic-domain-model/) model. Events are separated so other Services may reference them without referencing the Domain. This is not the only existing approach, but in this project it was decided to implement it this way.

**Application**

This layer is based on the [MediatR](https://github.com/jbogard/MediatR) library. All possible requests from the "outside world" are described here, as well as the corresponding handlers. Also here we have the DbContext interfaces for each Service so our handlers can use it without knowing about the actual implementation and referencing Infrastructure/Persistence layer. Although it looks like this "on paper", in real life, unfortunately, when changing data storage technology, it may be necessary to make some changes in the higher layers.

**Infrastructure/Persistence**

This layer provides communication with all external services, be it databases, mail services, third-party APIs etc. A single project is created for each external service. 

**API**

Following the principles of single responsibility at each layer, this layer is responsible for mapping HTTP requests to internal system requests defined in the application layer. Also here, as in the place where "everything starts", services of all layers are registered, and also their configuration takes place.
