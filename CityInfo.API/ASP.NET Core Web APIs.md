
**See commonalities across all styles of ASP.NET Core applications from [[ASP.NET Core]] notes:*
-  `Program.cs`: builder, dependency injection, request pipeline and middleware, running the app, web servers

API has to be able to send and receive data: serialization is used to transform C# objects into a format that can be send over the wire, such as JSON. The receiving end can then turn the serialized data into object again using deserialization.

![[Pasted image 20230502145322.png]]

 ![[Pasted image 20230502145616.png]]

In ASP.NET Core, Web API is used to create REST based (Restful) APIs.
- Typically in REST API, the HTTP protocol is leveraged: Use HTTP requests and responses 
- Each piece of data is availabe at unique location, an endpoint. 
- HTTP methods are mapped to actions: they are used to determine what to do. 
- HTTP status codes of the responses are used to determine outcomes: tell how it went, e.g. 404 means that the requested data wasn't found
- Responses can also contain pointers in the form of URLs with suggestion on what to do next
- JSON is the default serialization format
- JSON --> Controller - Model --> JSON
- WebAPI can be created using **Controller pattern** or **minimal API pattern**

**Swagger** is another word for **OpenAPI**, a standard that describes a **REST API**. With Swagger UI, the API can be opened in browser -> Swagger acts as documentation for the API: can see from the UI, which endpoints the API has available


## MVC

- The MVC pattern is standard for building ASP.NET Core APIs. 
	- Model: logic for application data. e.g. code to retrieve or store data
	- View: displaying data for the consumer. In API terminology, view is the representation of data or resources (usually JSON) and the user or consumer is typically another application
	- Controller: handles interaction between View and Model
- Routing matches a request URI to a method on the controller 
- content negotiation allows selecting the best representation for a given response, i.e. configure the format of the response that is sent back to the consumer of the API. 

#### Model

**What is returned from or accepted by an API is not the same as the entities used by the underlying data store.** The **entity classes** that **Entity Framework Core** uses, can be different from **model classes**. 

For example, a city **DTO** might contain calculated fields like NumberOfPointsOfInterest. A person DTO class might contain a FullName property, which is a concatenation of first name and last name database fields. These are two examples of fields that are not saved as such in a database. They're calculated on the go, and they won't be part of the city entity class. 

And the other way around exists as well. When we learn how to create resources, the model accepted by such a method doesn't contain an ID for a city, as it will be the responsibility of the underlying data store to create that. So that will be another class as well. It won't be the city entity class we'll use with Entity Framework Core.



## Status codes 

5 level of status codes
- **100: infomational**, not usually used by APIs
- **200: success**
	- 200: ok
	- 201: created
	- 204: successful request that should not return anything, like delete
- **300: redirection**, most APIs don't need
- **400: client mistake**
	- 400 - Bad request
	- 401 - Unauthorized
	- 403 - Forbidden
	- 404 - Not found
	- 409 - Conflict, e.g. edit conflict between two simultaneous updates
- **500: server mistakes**
	- 500: Internal server error


## IActionResult

JsonResult implements **IActionResult**. IActionResult is implemented by all ActionResults. It defines a contract that represents the result of an action method.

C# has built-in helper methods to return IActionResult. For example, `Ok` returns an OK result, which implements IActionResult.


## Content Negotiation  

**Process of selecting the best representation for a given response when there are multiple representations available.** Useful when API used by many different kind of clients because possibly not all of them can consume JSON representation as a response.

Consumer can request a specific format by passing the requested media type through as value for the Accept header.

ASP.NET Core supports this via output formatters. The consumer of the API can request a specific type of output by setting the Accept header to the requested media type.

For example, if that Accept header has a value of application/json, the consumer states that if the API supports application/json, it should return a JSON representation. If the Accept header has a value of application/xml, it should try and return an XML representation, and so on. If no Accept header is available or if it doesn't support requested format, it can always default to its default format, in most cases today, that's JSON (unless other format is configured to be default by adding it as the firs).

Technically, support for content negotiation from actions is implemented by `ObjectResult` and builds into the status code‑specific action results returned from the helper methods like the `OK` and `Not Found` methods. These action result helper methods are based on `ObjectResult`, and thus support content negotiation. Were we to only return a model class, this is automatically wrapped in `ObjectResult`, so that to support content negotiation. All we need to do to ensure that these object results deriving results support the format we want is to add or **configure the correct formatter**.


## References

- [Pluralsight course: ASP.NET Core 6: Big Picture](https://app.pluralsight.com/library/courses/asp-dot-net-core-6-big-picture/table-of-contents)
- [Pluralsight course: ASP.NET Core 6 Web API Fundamentals](https://app.pluralsight.com/library/courses/asp-dot-net-core-6-web-api-fundamentals/table-of-contents)
