Version 1.0.0
✨ Initial release of the [ResultWrapper] package ✨

📦 The [ResultWrapper] package is introduced in this version, offering a comprehensive set of tools for generating service result responses. It includes the ResultWrapper class, which serves as the central component.

🚀 The ResultWrapper class provides both generic and non-generic overloads to handle success and failure scenarios. It enables developers to specify payload types and optional parameters such as messages, error codes, and pagination information.

🎉 Version 1.0.0 of the [ResultWrapper] package marks its initial release, delivering a robust solution for creating service result responses in a standardized and efficient manner.

Version 1.0.1
🐛 [Bug Fix] Fixed issues in the README.md file and updated the package description.

📝 In this version, we have resolved various issues and inconsistencies present in the README.md file. Additionally, we have also improved the package description to provide clearer and more accurate information about the ResultWrapper package.

Version 1.0.2
💡 [Enhancement] Added missing success overload for payload and paginations.

📝 This release introduces a new success overload that accepts payload and pagination as parameters, providing developers with the flexibility to omit the message and status code in the response when necessary.

Version 1.0.3
💡 [Enhancement] Added an extension method to convert loosely typed payload to strongly typed payload.

📝 This release introduces a new extension method to support payload conversion, updates the pagination class to a record type, adds a non-generic use of ResultWrapper in the documentation, and upgrades the project from .NET 6 to .NET 8 for improved performance and features.

Version 1.0.4
🚀 [Enhancement] Introducing TypedPayload Property in IResultWrapper for Strongly Typed Payload Access

📦 Changes: Removed the previously existing extension method used for converting loosely typed payloads to strongly typed ones.

📝 This release introduces the TypedPayload property within the Non-Generic IResultWrapper interface, providing a streamlined method to access strongly typed payloads. Additionally, we've deprecated the previous extension method used for payload conversion, simplifying your codebase and enhancing overall clarity.

Version 1.0.5
📦 [Package Name Update]: RW to ResponseWrapper, Bug Fixes

📦 Changes:
- **Package Name Update:** The package name has been changed from "RW" to "ResponseWrapper" to better represent the package's purpose and contents.
- **Bug Fixes:** This release addresses potential bugs that may occur when converting one collection or array to another type of collection.
- **Compatibility:** The package has been downgraded to ensure compatibility with .NET 6 while retaining all existing features.

📝 Release Notes: This update brings package compatibility for .NET 6 while retaining all existing features.


Version 1.0.6
📦 Package Name Update: Removed Generic Functions
📦 Changes:
This update removes support for generic methods within the package. From this version onwards, only non-generic methods are available.
To obtain strongly typed results, use the new TypedPayload<T>() method. Replace T with your desired result type when calling this method.
📝 Release Notes:
Version 1.0.6 introduces a significant change by discontinuing support for generic methods in the package. Users are encouraged to use TypedPayload<T>() for obtaining typed results instead of generics.
This change enhances clarity and maintainability by focusing on non-generic implementations, ensuring better compatibility and ease of use in future updates.

Version 1.0.7
📦 Package Name Update: Restructed implemenation
📦 Changes:
This update include restructuring the implementation to address generic issues while generating documentation for Swagger when using minimal APIs.
