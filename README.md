BookTera
========

This is a book exchange application(, and my master's thesis). Has a full .NET backend (MS SQL database, Entity Framework 5 as ORM). Contains 5 executable projects:
*	ASP.NET MVC 4 based web application (.NET)
*	Play Framework 2.3.0 based web application (replica) (Java/Scala)
*	Windows 8.1 client stub (.NET)
*	Windows Phone 8 client (.NET)
*	Android 4.4 client (Java)

Getting started
---------------

See the [Installation Guidelines]

Architecture
------------

![Architecture][Architecture]

### Other diagrams about the app, and it's operation

* [Authentication system][Authentication]
* [Database diagram][Database]
* [Transactional state machine][TransactionOpportunities]
* [All the distinguished types of books][BookTypes]
* [User groups (have not been implemented)][UserGroups]
* [Speed tests: ASP.NET MVC 4 vs Play][SpeedTests]

Screenshots
-----------

The web applications' (both ASP.NET MVC and Play) start pages look like this: <br />
![WebStartPage][WebStartPage]

Here is the Windows Store stub's start page: <br />
![Win8StartPage][Win8StartPage]

And here are the mobile clients' start pages as well. First the WindowsPhone, and the Android next <br />
![WindowsPhoneStartPage][WindowsPhoneStartPage]
![AndroidStartPage][AndroidStartPage]
* [More WindowsPhone screenshots][WindowsPhone screenshots]
* [More Android screenshots][Android screenshots]



[Installation Guidelines]: https://github.com/nvirth/BookTera/blob/master/Helpers/Installation%20Guidelines/Installation%20Guidelines.docx

[Architecture]: https://github.com/nvirth/BookTera/blob/master/Helpers/Diagrams/Architecture.png "Architecture"
[Authentication]: https://github.com/nvirth/BookTera/blob/master/Helpers/Diagrams/Authentication.png "Authentication"
[BookTypes]: https://github.com/nvirth/BookTera/blob/master/Helpers/Diagrams/Book%20types.png "BookTypes"
[Database]: https://github.com/nvirth/BookTera/blob/master/Helpers/Diagrams/Database.png "Database"
[TransactionOpportunities]: https://github.com/nvirth/BookTera/blob/master/Helpers/Diagrams/Transaction%20opportunities.png "TransactionOpportunities"
[UserGroups]: https://github.com/nvirth/BookTera/blob/master/Helpers/Diagrams/UserGroups.png "UserGroups"
[SpeedTests]: https://github.com/nvirth/BookTera/blob/master/Helpers/Diagrams/SpeedTests/ "SpeedTests"

[WebStartPage]: https://github.com/nvirth/BookTera/blob/master/Helpers/Screenshots/Web%20-%20StartPage.png "WebStartPage"
[Win8StartPage]: https://github.com/nvirth/BookTera/blob/master/Helpers/Screenshots/Win8%20-%20StartPage.png "Win8StartPage"
[AndroidStartPage]: https://github.com/nvirth/BookTera/blob/master/Helpers/Screenshots/Android%20-%20StartPage.png "AndroidStartPage"
[WindowsPhoneStartPage]: https://github.com/nvirth/BookTera/blob/master/Helpers/Screenshots/WindowsPhone%20-%20StartPage.png "WindowsPhoneStartPage"

[WindowsPhone screenshots]: https://github.com/nvirth/BookTera/blob/master/Helpers/Screenshots/WindowsPhone/ "WindowsPhone screenshots"
[Android screenshots]: https://github.com/nvirth/BookTera/blob/master/Helpers/Screenshots/Android/ "Android screenshots"