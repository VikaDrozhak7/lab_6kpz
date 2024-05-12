# ATM

## Introduction

This project is a banking system developed using WPF (Windows Presentation Foundation) for graphical user interface and ADO.NET for database interaction. The project uses a number of programming principles, refactoring techniques and design patterns to create clean, modular and easily extensible code.
## Functionality

This project includes the development of a banking system that provides users with the ability to perform various banking operations:

1. **User Authentication**: Users can enter their card number and PIN to login. This function is implemented in the class [`MainWindow`](./AppBank/MainWindow.xaml.cs).

2. **Balance Check**: Users can check their account balance. This function is implemented in the class [`Menu`](./AppBank/Menu.xaml.cs).

3. **Cash Deposit**: Users can deposit cash into their account. This function is implemented in the class [`tocount`](./AppBank/tocount.xaml.cs).

4. **Withdrawal**: Users can withdraw cash from their account. This function is implemented in the class[ `withdraw`](./AppBank/withdraw.xaml.cs).

5. **Transfer funds**: Users can transfer funds from their account to another account. This function is implemented in the class [`Transfer`](./AppBank/Transfer.xaml.cs).

## Run process locally

1. Clone this repository.
2. Open the project in Visual Studio.
3. Run the project by pressing `Ctrl + F5`.

## Principles of programming

This project follows the following programming principles:

1. **Single Responsibility Principle**: Each class in the system has only one responsibility. For example, the class [`DatabaseHelper`](.LibraryBank/DatabaseHelper.cs) is only responsible for interacting with the database [Account](.LibraryBank/Account.cs) is responsible for managing the bank account.

2. **Open/Closed Principle**: The system is designed in such a way that it can be easily extended without changing the existing code. For example, you can add new transaction types without changing the [`AutomatedTellerMachine`](.LibraryBank/AutomatedTellerMachine.cs) class.
3. **Barbara Liskov Substitution Principle**: The system is designed in such a way that subtypes can replace their base types without changing the correctness of the program. For example, [ `DepositCashStrategy`](.LibraryBank/DepositCashStrategy.cs) and [`WithdrawCashStrategy`](.LibraryBank/WithdrawCashStrategy.cs) can replace [ `ITransactionStrategy`](.LibraryBank/ITransactionStrategy.cs).

4. **Interface Segregation Principle**: Each class uses only the interfaces it needs. For example, the [`AutomatedTellerMachine`](.LibraryBank/AutomatedTellerMachine.cs) class uses the [ `ITransactionStrategy`](.LibraryBank/ITransactionStrategy.cs) interface.


5. **Principle of dependence on abstractions, not on specific classes (Dependency Inversion Principle)**: High-level modules do not depend on low-level modules. Both types of modules depend on abstractions. For example, the class [`AutomatedTellerMachine`](.LibraryBank/AutomatedTellerMachine.cs). depends on the [ `ITransactionStrategy`](.LibraryBank/ITransactionStrategy.cs)` abstraction, not the concrete `DepositCashStrategy` and `WithdrawCashStrategy` classes.

## Refactoring techniques

During the development of this project, the following refactoring techniques were used:

1. **Remove Code Duplication**: Code duplication has been removed by using methods and classes.

2. **Using Appropriate Names**: All classes, methods and variables have appropriate names that reflect their function.

3. **Using Exceptions for Error Handling**: Exceptions are used to handle errors during database operations.

4. **Using Encapsulation**: Class data is protected from direct access from the outside by using private fields and properties.

5. **Using Polymorphism**: Polymorphism is used to perform different types of transactions.

## Design patterns

This project uses the following design patterns:

1. **Strategy Pattern**: Used to execute various types of transactions. It includes the interface [`ITransactionStrategy`](.LibraryBank/ITransactionStrategy.cs)` and its implementations [`DepositCashStrategy`](.LibraryBank/DepositCashStrategy.cs) and [`WithdrawCashStrategy`](.LibraryBank/WithdrawCashStrategy.cs). This pattern allows you to define a family of algorithms, encapsulate each one, and make them interchangeable using these strategies via the _transactionStrategy field, which allows you to change the behavior of transactions in real-time. The strategy allows the algorithm to vary independently of the clients using it.
2. **Observer Pattern**: Used to notify about various events such as successful authentication, balance check, etc. It includes a class [`AutomatedTellerMachine`](.LibraryBank/AutomatedTellerMachine.cs) that generates events. An observer defines a one-to-many relationship between objects, so that when one object changes state, all its dependents are notified and automatically updated.
3. **Singleton Pattern**: Used to create a single instance of the class [`DatabaseHelper'](.LibraryBank/DatabaseHelper.cs) The GetInstance method checks whether an instance of the class exists, and if not, creates it. However, it ensures that the class has only one instance and provides a global access point to it.
4. **Command Pattern**: This pattern is used to encapsulate a request as an object, allowing you to parameterize clients with different requests, queues, or requests and operations. It includes the interface [ `ITransactionStrategy`](.LibraryBank/ITransactionStrategy.cs) and its implementations [ `DepositCashStrategy`](.LibraryBank/DepositCashStrategy.cs) and [`WithdrawCashStrategy`](.LibraryBank/WithdrawCashStrategy.cs)
5. **Partial Class Pattern**: This pattern is used to distribute one class to several files. This is useful for managing large classes. It includes the class [`AutomatedTellerMachine`](.LibraryBank/AutomatedTellerMachine.cs), which is spread over several files.

6. **Factory Method Pattern**: This pattern is used in the Bank class to create a new instance of [`AutomatedTellerMachine`](.LibraryBank/AutomatedTellerMachine.cs). It defines an interface for creating an object, but allows subclasses to change the type of object being created.
