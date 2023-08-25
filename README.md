# Design Patterns Practice Repository .NET C Sharp ( C# )

Welcome to the **Design Patterns Practice** repository! This repository serves as a learning playground for exploring and implementing various design patterns in software development. Currently, it contains examples and implementations of the Builder, Strategy, and Decorator patterns.

## Table of Contents

- [Introduction](#introduction)
- [Design Patterns](#design-patterns)
  - [Builder Pattern](#builder-pattern)
  - [Strategy Pattern](#strategy-pattern)
  - [Decorator Pattern](#decorator-pattern)
- [Getting Started](#getting-started)
- [Contributing](#contributing)
- [License](#license)

## Introduction

Design patterns are vital tools for software engineering that offer tested, reusable solutions to typical programming issues. This repository's goal is to make design pattern principles easier for developers to understand by offering concrete examples in the form of code implementations. 

## Design Patterns

### Builder Pattern

The Builder pattern is a creational pattern that separates the construction of a complex object from its representation, allowing the same construction process to create various representations. In this repository, you can find an example implementation of the Builder pattern, demonstrating its usage in creating complex objects step by step. I have added 2 different example with NotificationBuilder and Order Builder where my pattern class helps me to build PurchaseOrder, LC, and SpotPurchase object using this design pattern.

### Strategy Pattern

The Strategy pattern is a behavioral pattern that defines a family of algorithms, encapsulates each algorithm, and makes them interchangeable. This repository includes a practical implementation of the Strategy pattern, showcasing how different algorithms can be selected and switched dynamically during runtime. From my point of view I belive that it is necessary to learn design pattern from the book and develop some basic concept then try to implement it. In this repo I have used this pattern to generate Excel Report with dynamic report column depending on the object we get. So, depending on object my classes have their own streategy to generate column and set value in it and export as excel file.

### Decorator Pattern

The Decorator pattern is a structural pattern that allows behavior to be added to an object, either statically or dynamically, without affecting its structure. Inside this repository, you'll discover an example of the Decorator pattern, illustrating how to wrap objects with additional behaviors and responsibilities. Using this design pattern I have implementation purchase order tax, discount , shipping fee calculation and also added responsibility to send email and mobile phone notification.
![Uploading image.png…]()

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


