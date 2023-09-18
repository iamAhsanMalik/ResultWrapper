## Result Wrapper

The `ResultWrapper` package provides a set of static methods in the `ResultWrapper` class, allowing you to easily create and work with success and failure scenarios. These wrappers encapsulate various data, including payloads, errors, success and error messages, status codes, and pagination information, providing a standardized way to handle and represent the results of operations.

## Why to use?

The main benefit of this package is to provide access to strongly typed and loosely typed payloads and errors. By using this package, the returned response will only include the properties that you have explicitly returned. It ensures that no extra keys are included in the response.

### Note
It's important to note that the return type of the service or method where this package is used depends on whether it is generic or non-generic. If you use `IResultWrapper` as the return type, you will receive a non-generic result by default. On the other hand, if you use `IResultWrapper<Type>`, you will receive a strongly typed object.


## Installation

To install the `ResultWrapper` package, you can use the following command in the NuGet Package Manager Console: `dotnet add package RW`

Alternatively, you can search for "RW" in the NuGet Package Manager UI and install it from there.

## Usage

The `ResultWrapper` class provides several overloaded methods for handling different success and failure scenarios. The methods are categorized into generic and non-generic overloads, allowing you to work with specific types or use the more general `object` type.


#### Success Generic Overloads

Return empty success result.

```csharp
return ResultWrapper.Success<MyPayload>();
```
Return success result with payload only.

```csharp
var payload = new MyPayload();
return ResultWrapper.Success<MyPayload>(payload);
```

Return success result with message and status

```csharp
return ResultWrapper.Success<MyPayload>("Success message", 200);
```

Return success result with a payload, message, and status code.

```csharp
var payload = new MyPayload();
return ResultWrapper.Success<MyPayload>(payload, "Success message", 200);
```
Return success result with a payload, pagination information, message, and status code.

```csharp
var payload = new MyPayload();
var paginationInfo = new Pagination();
return ResultWrapper.Success(payload, paginationInfo, "Success message", 200);
```

#### Success Non Generic Overloads

Return empty success result.

```csharp
return ResultWrapper.Success();
```
Return success result with payload only.

```csharp
var payload = new MyPayload();
return ResultWrapper.Success(payload);
```

Return success result with message and status

```csharp
return ResultWrapper.Success("Success message", 200);
```

Return success result with a payload, message, and status code.

```csharp
var payload = new MyPayload();
return ResultWrapper.Success(payload, "Success message", 200);
```
Return success result with a payload, pagination information, message, and status code.

```csharp
var payload = new MyPayload();
var paginationInfo = new Pagination();
return ResultWrapper.Success(payload, paginationInfo, "Success message", 200);
```

#### Failure Generic Overloads

Return empty failure.

```csharp
return ResultWrapper.Failure<MyErrors>();
```

Return failure with a message and status code.

```csharp
return ResultWrapper.Failure<MyErrors>("Error message", 500);
```

Return failure with errors of type TErrors

```csharp
var errors = new MyErrors();
return ResultWrapper.Failure<MyErrors>(errors);
```

Return failure with errors of type TErrors, message, and status code.

```csharp
var errors = new MyErrors();
var result = ResultWrapper.Failure<MyErrors>(errors, "Error message", 500);

```

#### Failure Non Generic Overloads

Return empty failure.

```csharp
return ResultWrapper.Failure();
```

Return failure with a message and status code.

```csharp
return ResultWrapper.Failure("Error message", 500);
```

Return failure with errors

```csharp
var errors = new MyErrors();
return ResultWrapper.Failure(errors);
```

Return failure with errors, message, and status code.

```csharp
var errors = new MyErrors();
var result = ResultWrapper.Failure(errors, "Error message", 500);

```

### Sample Code

Note: The result wrapper will return a payload of type WeatherForecastInfo[] when using a generic approach.
However, when a non-generic approach is used, the payload will be of type object.

#### Example: How to use Non Generic IResultWrapper

```csharp
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{

	[HttpGet(Name = "GetWeatherForecast")]
	public ActionResult Get()
	{
		var result = Weather.GetWeatherInfo();

		/*
		// These are the properties available in IResultWrapper
		var payload = result.Payload; // To get the payload
		bool isSuccess = result.IsSuccess; // To check whether a success case is returned or a failure
		string message = result.Message; // Get the failure or success message if you have passed it as an argument
		int statusCode = result.Code; // Get the failure or success codes if you have passed them as arguments
		var errors = result.Errors; // To get a list of errors
		*/

		// Note: If you are using non generic IResult Wrapper, you can still get strongly typed payload by using TypedPayload method

		WeatherForecast[]? weatherForecasts = result.TypedPayload<WeatherForecast[]>();

		if (result.IsSuccess)
		{
			return Ok(result);
		}
		return BadRequest();
	}
}

public static class Weather
{
	public static IResultWrapper GetWeatherInfo()
	{
		var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

		var weatherForecasts = Enumerable.Range(1, 5).Select(index =>
				new WeatherForecast
				{
					Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
					Summary = summaries[Random.Shared.Next(summaries.Length)],
					TemperatureC = Random.Shared.Next(-20, 55),
				})
				.ToArray();

		if (weatherForecasts != null)
		{
			return ResultWrapper.Success(weatherForecasts, "Hello", 300);
		}
		return ResultWrapper.Failure("Not Found", 404);
	}
}
```
#### Example: How to use Generic IResultWrapper<T>

```csharp
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{

	[HttpGet(Name = "GetWeatherForecast")]
	public ActionResult Get()
	{
		var result = Weather.GetWeatherInfo();

		/*
		// These are the properties available in IResultWrapper
		var payload = result.Payload; // To get the payload
		bool isSuccess = result.IsSuccess; // To check whether a success case is returned or a failure
		string message = result.Message; // Get the failure or success message if you have passed it as an argument
		int statusCode = result.Code; // Get the failure or success codes if you have passed them as arguments
		var errors = result.Errors; // To get a list of errors
		*/

		if (result.IsSuccess)
		{
			return Ok(result);
		}
		return BadRequest();
	}
}

public static class Weather
{
	public static IResultWrapper<WeatherForecast[]> GetWeatherInfo()
	{
		var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

		var weatherForecasts = Enumerable.Range(1, 5).Select(index =>
				new WeatherForecast
				{
					Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
					Summary = summaries[Random.Shared.Next(summaries.Length)],
					TemperatureC = Random.Shared.Next(-20, 55),
				})
				.ToArray();

		if (weatherForecasts != null)
		{
			return ResultWrapper.Success<WeatherForecast[]>(weatherForecasts, "Hello", 300);
		}
		return ResultWrapper.Failure<WeatherForecast[]>("Not Found", 404);
	}
}
```
#### Conclusion
The ResultWrapper package simplifies the process of creating and working with result success and failure scenarios. It provides a consistent way to handle and represent the results
