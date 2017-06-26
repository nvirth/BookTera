Speed tests: ASP.NET MVC 4 vs Play
==================================

Here you can see diagrams with speed test results of the 2 web applications. They use the same backend, (mostly) the same JS and image resources; so they only differ in the web UI layer* - so only in the web framework used to serve the resources, calculate the html responses, and so on. <br />
That's why it seemed to be a good idea to compare the 2 frameworks' perfomnace with request test, but <br />
*actually, the web servers under the frameworks are also different. Play uses JBoss Netty, while ASP.NET MVC uses IIS... <br />
So this measurement is not a valid performance comparison of the frameworks!

You can see the measurement's sketches in the [SpeedTestData.xlsx][SpeedTestData xlsx]

Per-request test
----------------

Hand-made with Firefox :)

Result: <br />
![PerRequestTest][PerRequestTest]

Dispersions: <br />
![PerRequestTest - Asp dispersion][PerRequestTest - Asp dispersion]
![PerRequestTest - Play dispersion][PerRequestTest - Play dispersion]

Stress test
-----------

Made with [UrlStress][UrlStress]. Multiple measurements were done...

... First a smaller one, set up UrlStress to 1.000 requests and 100 threads <br />
![StressTest - Little][StressTest - Little]
... Later a bigger one with 10.000 requests and 300 threads <br />
![StressTest - Big][StressTest - Big]
... And finally, after the shock was over, the first smaller type of measurement were repeated a few times. I did not want to believe that Play could be so much faster, so I started to seek my code for unoptimized solutions, and google ASP.NET MVC optimizations. Found a few, implemented them; and after each one was finished, rerun the smaller stress test. The results can be seen in one diagram: <br />
![StressTest - Little - After ASP.NET MVC optimization][StressTest - Little - After ASP.NET MVC optimization] <br />
<sup>Little note: The later optimized forms were added to the formers. So e.g. the 2. one ("asp without log") means without log and without ViewBag (which is the 1. one), and so on.</sup>


[UrlStress]: http://blogs.msdn.com/b/friis/archive/2010/12/28/urlstress-a-simple-gui-tool-with-source-code-to-stress-your-favorite-web-server.aspx
[SpeedTestData xlsx]: https://github.com/nvirth/BookTera/blob/master/Helpers/Diagrams/SpeedTests/SpeedTestData.xlsx

[PerRequestTest - Asp dispersion]: https://github.com/nvirth/BookTera/blob/master/Helpers/Diagrams/SpeedTests/PerRequestTest%20-%20Average%20-%20Asp%20dispersion.PNG
[PerRequestTest - Play dispersion]: https://github.com/nvirth/BookTera/blob/master/Helpers/Diagrams/SpeedTests/PerRequestTest%20-%20Average%20-%20Play%20dispersion.PNG
[PerRequestTest]: https://github.com/nvirth/BookTera/blob/master/Helpers/Diagrams/SpeedTests/PerRequestTest%20-%20Average.PNG
[StressTest - Big]: https://github.com/nvirth/BookTera/blob/master/Helpers/Diagrams/SpeedTests/StressTest-Big.png
[StressTest - Little - After ASP.NET MVC optimization]: https://github.com/nvirth/BookTera/blob/master/Helpers/Diagrams/SpeedTests/StressTest-Little-AfterOpt.png
[StressTest - Little]: https://github.com/nvirth/BookTera/blob/master/Helpers/Diagrams/SpeedTests/StressTest-Little.png