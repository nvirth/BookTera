ECHO OFF
echo. 
echo After seeing this...
echo. 
echo *********************************************************************
echo --- (Running the application from SBT, auto-reloading is enabled) ---
echo. 
echo [info] play - Listening for HTTP on /0:0:0:0:0:0:0:0:9000
echo. 
echo (Server started, use Ctrl+D to stop and go back to the console...)
echo *********************************************************************
echo. 
echo ... you can browse the webapplication at:
echo. 
echo http://localhost:9000
ECHO ON

activator run | tee logs\logFromCmd