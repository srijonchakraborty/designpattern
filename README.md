# Design Patterns Practice Repository .NET C Sharp ( C# )

Welcome to the **Design Patterns Practice** repository! This repository serves as a learning playground for exploring and implementing various design patterns in software development. Currently, it contains examples and implementations of the Builder, Strategy, and Decorator patterns.

## Table of Contents

- [Introduction](#introduction)
- [Design Patterns](#design-patterns)
  - [Builder Pattern](#builder-pattern)
  - [Strategy Pattern](#strategy-pattern)
  - [Decorator Pattern](#decorator-pattern)
  - [Proxy Pattern](#proxy-pattern)
  - [Templet Method Pattern](#templet-method-pattern)
- [Getting Started](#getting-started)
- [Contributing](#contributing)
- [License](#license)

## Introduction

Design patterns are vital tools for software engineering that offer tested, reusable solutions to typical programming issues. This repository's goal is to make design pattern principles easier for developers to understand by offering concrete examples in the form of code implementations. 

## Design Patterns

### Builder Pattern

The Builder pattern is a **creational pattern** that separates the construction of a complex object from its representation, allowing the same construction process to create various representations. In this repository, you can find an example implementation of the Builder pattern, demonstrating its usage in creating complex objects step by step. I have added 2 different example with NotificationBuilder and Order Builder where my pattern class helps me to build PurchaseOrder, LC, and SpotPurchase object using this design pattern.

Check the Link: [Builder Pattern](https://github.com/srijonchakraborty/designpattern/tree/main/DesignPattern/BuilderPattern)

### Strategy Pattern

The Strategy pattern is a **behavioral pattern** that defines a family of algorithms, encapsulates each algorithm, and makes them interchangeable. This repository includes a practical implementation of the Strategy pattern, showcasing how different algorithms can be selected and switched dynamically during runtime. From my point of view I belive that it is necessary to learn design pattern from the book and develop some basic concept then try to implement it. In this repo I have used this pattern to generate Excel Report with dynamic report column depending on the object we get. So, depending on object my classes have their own streategy to generate column and set value in it and export as excel file.

Check the Link: [Strategy Pattern](https://github.com/srijonchakraborty/designpattern/tree/main/DesignPattern/StrategyPattern)

### Decorator Pattern

The Decorator pattern is a **structural pattern** that allows behavior to be added to an object, either statically or dynamically, without affecting its structure. Inside this repository, you'll discover an example of the Decorator pattern, illustrating how to wrap objects with additional behaviors and responsibilities. Using this design pattern I have implementation purchase order tax, discount , shipping fee calculation and also added responsibility to send email and mobile phone notification.

Check the Link: [Decorator Pattern](https://github.com/srijonchakraborty/designpattern/tree/main/DesignPattern/DecoratorPattern)

### Proxy Pattern 

As we know that, Proxy Pattern is one type of **structural design pattern** and in this Repository I have implemented 3 types of Proxy Pattern. 

Check the Link: [Proxy Pattern](https://github.com/srijonchakraborty/designpattern/tree/main/DesignPattern/ProxyPattern)

#### Protection Proxy

The Protection Proxy restricts access to critical operations or data, ensuring that only authorized users, such as administrators, can modify sensitive properties. In this repository, you can find an example of a Protection Proxy controlling the order status based on user roles. I have updated the PurchaseOrder or SpotPurchase OrderStatus using user Role Permission.

#### Virtual Proxy

The Virtual Proxy delays the creation or loading of resource-intensive objects until they are actually required. This optimization enhances performance and reduces resource consumption. In the code provided, a Virtual Proxy is demonstrated by initializing complex order processing components only when an order needs to be processed. I have implemented this pattern in orderitem document. As we know that, documents are resource intensive so I have design the code to read the file only when I need to read the the file. Additionally, I have also used the memory cache to store file and item document after reading the file from then drive. So, in future I can read file from remote server, however, it might be hybrid system of Remote Proxy and Virtual Proxy.

#### Remote Proxy

The Remote Proxy enables clients to interact with remote services or objects as if they were local. It abstracts the complexities of network communication, allowing operations to be executed on a separate server while maintaining a seamless user experience. This repository showcases a Remote Proxy used for processing orders remotely. I have used "openweathermap" free package to fetch weather information depending on location. Using this type of pattern I have segregate the part of code or feature from main feature. So, I do not have to change the main code for remote weather data. If any changes required in future I have deal with that class only. There can be other remote scenario like "posting some data to 3 party api" or "fetching remote files". We might have chance to implement caching hare if needed, however, "Virtual Proxy Pattern" is mostly used for caching related functionalities.

### Templet Method Pattern
The Template Method Pattern is a **behavioral design pattern** that defines the structure of an algorithm in a base class, allowing subclasses to provide specific implementations for certain steps while keeping the overall algorithm's framework intact. The design encourages code reuse and guarantees consistency in algorithm execution across many subclasses by encapsulating the common functionality in the template method and allowing modification through abstract methods.

## Getting Started

To explore the examples and implementations of design patterns in this repository, follow these steps:

1. Clone the repository to your local machine using the following command:
2. git clone https://github.com/srijonchakraborty/designpattern.git
  Navigate to the directory of the specific design pattern you want to explore, such as `builder-pattern`, `strategy-pattern`, or `decorator-pattern`.

3. Review the code and comments to understand how each design pattern is implemented and utilized.

4. Experiment with the code, make modifications, and see how different scenarios play out with the applied design pattern.

5. Share your insights and learning experiences with the community!

## Contributing

Contributions to this repository are welcomed and encouraged! If you'd like to contribute by adding more design patterns, improving existing implementations, fixing issues, or enhancing documentation, please follow these steps:

1. Fork the repository to your GitHub account.

2. Create a new branch from the `main` branch for your proposed changes.

3. Make your changes, following the established code style and structure.

4. Commit your changes with clear and concise commit messages.

5. Push your branch to your forked repository.

6. Open a pull request, explaining your changes and their benefits.

Your contributions will help this repository become a valuable resource for learning about design patterns.

## License

This repository is open-source and is available.

---
SEO Keywords: Design Patterns, Builder Pattern, Strategy Pattern, Decorator Pattern, Software Design, Creational Pattern, Behavioral Pattern, Structural Pattern.


