## 📦 Package Name Update: RW is now ResponseWrapper

We are excited to announce that we have updated the package name from "RW" to "ResponseWrapper" to better reflect the purpose and contents of the package.

## 🚀 What's Changed

- **OldPackage:** [RW](https://www.nuget.org/packages/RW)
- **NewPackage:** [ResponseWrapper](https://www.nuget.org/packages/ResponseWrapper) 
- **Upgrade Instructions:** If you are currently using the "RW" package, please update your package references and code accordingly to use [ResponseWrapper](https://www.nuget.org/packages/ResponseWrapper).

We believe this update will provide greater clarity and consistency when working with service result responses. Thank you for your continued support, and we look forward to bringing you more improvements in the future!

## Response Wrapper

The `ResponseWrapper` package provides a set of static methods in the `ResultWrapper` class, allowing you to easily create and work with success and failure scenarios. These wrappers encapsulate various data, including payloads, errors, success and error messages, status codes, and pagination information, providing a standardized way to handle and represent the results of operations.

## Why to use?

The main benefit of this package is to provide access to strongly typed and loosely typed payloads and errors. By using this package, the returned response will only include the properties that you have explicitly returned. It ensures that no extra keys are included in the response.

## Installation

To install the `ResponseWrapper` package, you can use the following command in the NuGet Package Manager Console: `dotnet add package RW`

Alternatively, you can search for "RW" in the NuGet Package Manager UI and install it from there.

## Usage

The `ResultWrapper` class provides several overloaded methods for handling different success and failure scenarios. The methods are categorized into generic and non-generic overloads, allowing you to work with specific types or use the more general `object` type.


#### Success Overloads

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

#### Failure Overloads

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

#### Example: How to use IResultWrapper

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

#### Conclusion
The Response Wrapper package simplifies the process of creating and working with result success and failure scenarios. It provides a consistent way to handle and represent the results
