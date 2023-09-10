# Design Patterns Practice Repository .NET C Sharp ( C# )

Welcome to the **Design Patterns Practice** repository! This repository serves as a learning playground for exploring and implementing various design patterns in software development. Currently, it contains examples and implementations of the Builder, Strategy, Decorator and other patterns. 

## Table of Contents

- [Introduction](#introduction)
- [Design Patterns](#design-patterns)
  - [Builder Pattern](#builder-pattern)
  - [Strategy Pattern](#strategy-pattern)
  - [Decorator Pattern](#decorator-pattern)
  - [Proxy Pattern](#proxy-pattern)
  - [Template Method Pattern](#template-method-pattern)
  - [State Pattern](#state-pattern)  
  - [Momento Pattern](#momento-pattern)
  - [Facade Pattern](#facade-pattern)
- [Getting Started](#getting-started)
- [Contributing](#contributing)
- [License](#license)

## Introduction

Design patterns are vital tools for software engineering that offer tested, reusable solutions to typical programming issues. This repository's goal is to make design pattern principles easier for developers to understand by offering concrete examples in the form of code implementations. 

## Design Patterns

### Builder Pattern

The Builder pattern is a **creational pattern** that separates the construction of a complex object from its representation, allowing the same construction process to create various representations. In this repository, you can find an example implementation of the Builder pattern, demonstrating its usage in creating complex objects step by step. I have added 2 different example with NotificationBuilder and Order Builder where my pattern class helps me to build PurchaseOrder, LC, and SpotPurchase object using this design pattern.

![image](https://github.com/srijonchakraborty/designpattern/assets/10357119/5df13642-6a41-4c30-a607-f552c455c6c9)


Check link 1: https://pasteboard.co/s8WXBt8M5LIR.png

Check Link 2: https://paste.pics/46fce1e72419322b72df72b716b21ffe

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

![image](https://github.com/srijonchakraborty/designpattern/assets/10357119/c2b071b3-5f59-4f91-b1de-75f41ac309f8)

Check Image: https://pasteboard.co/wsMGvm14aBJE.png

Check Image: https://paste.pics/06b2068edb52655a612313e8f0b394a6

#### Virtual Proxy

The Virtual Proxy delays the creation or loading of resource-intensive objects until they are actually required. This optimization enhances performance and reduces resource consumption. In the code provided, a Virtual Proxy is demonstrated by initializing complex order processing components only when an order needs to be processed. I have implemented this pattern in orderitem document. As we know that, documents are resource intensive so I have design the code to read the file only when I need to read the the file. Additionally, I have also used the memory cache to store file and item document after reading the file from then drive. So, in future I can read file from remote server, however, it might be hybrid system of Remote Proxy and Virtual Proxy.

![image](https://github.com/srijonchakraborty/designpattern/assets/10357119/e1597ff6-9a71-4e3d-855f-ba801dae23f4)

Check Link: https://paste.pics/42ff8983cdcef5978519752d91661232

Check Link: https://pasteboard.co/YV1OtUOHrmPd.png


#### Remote Proxy

The Remote Proxy enables clients to interact with remote services or objects as if they were local. It abstracts the complexities of network communication, allowing operations to be executed on a separate server while maintaining a seamless user experience. This repository showcases a Remote Proxy used for processing orders remotely. I have used "openweathermap" free package to fetch weather information depending on location. Using this type of pattern I have segregate the part of code or feature from main feature. So, I do not have to change the main code for remote weather data. If any changes required in future I have deal with that class only. There can be other remote scenario like "posting some data to 3 party api" or "fetching remote files". We might have chance to implement caching hare if needed, however, "Virtual Proxy Pattern" is mostly used for caching related functionalities.

![image](https://github.com/srijonchakraborty/designpattern/assets/10357119/19cab38e-f2ec-4f1a-b589-57df4abd091c)


Check Image: https://pasteboard.co/MhLSlWIzG0R7.png

Check Image: https://paste.pics/7f644f5584d03b563c87074ef7e92697

### Template Method Pattern
The Template Method Pattern is a **behavioral design pattern** that defines the structure of an algorithm in a base class, allowing subclasses to provide specific implementations for certain steps while keeping the overall algorithm's framework intact. The design encourages code reuse and guarantees consistency in algorithm execution across many subclasses by encapsulating the common functionality in the template method and allowing modification through abstract methods. I have create process flow where order can be processed. depending on the status, document check , other validation depending on type of order then send Email and phone alert.

![image](https://github.com/srijonchakraborty/designpattern/assets/10357119/22c1b925-3667-443a-be4f-928ecf71e623)

Check Image Link 1 : https://pasteboard.co/7UHF142Vh02a.png

Check Image Link 2 : https://paste.pics/23743bb5c89ce9ec86454d7a83018b2f

Check Link: [Template Method Pattern](https://github.com/srijonchakraborty/designpattern/tree/main/DesignPattern/TempletMethodPattern)

### State Pattern
The state pattern is a behavioral design pattern that allows an object to alter its behavior when its internal state changes. It achieves this by representing each possible state of an object as a separate class and delegating the state-specific behavior to these classes. This pattern promotes cleaner, more modular code by separating the responsibilities related to an object's state into distinct classes.

![image](https://github.com/srijonchakraborty/designpattern/assets/10357119/9f0ba8d0-6648-4ee2-82f7-8f38d3a75e4b)



I have designed approval process using state pattern. As you can see in the picture from "Draft" you can go to aprrove, cancel and Inreview status. If you try to change to other that these statuses then item status will remain in draft status. From cancel and reject status you can not go to any other status. Same for the approve status too. From InReview Status you can go to reject, approve and InViewStatus only. For each status, state of the object will be different and it behave differently.


Check Image Link 1: https://pasteboard.co/2v3N3vUX56Ui.png

Check Image Link 2:https://paste.pics/ef3d85164dd382a62c782fa9e9e2fc54

Check code link: https://github.com/srijonchakraborty/designpattern/tree/main/DesignPattern/StatePattern

### Momento Pattern

### Facade Pattern

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


