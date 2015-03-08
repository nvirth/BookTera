echo "Downloads the mock data for the AndroidClientProxy project. "

REM --- UnAuth ---
wget -O ..\Java\Android\AndroidClientProxy\src\main\res\raw\productmanager_getnewests.json "http://localhost:50135/EntityManagers/ProductManagerService.svc/GetNewests?numOfProducts=16&pageNumber=2&productsPerPage=8"
wget -O ..\Java\Android\AndroidClientProxy\src\main\res\raw\productmanager_getmainhighlighteds.json "http://localhost:50135/EntityManagers/ProductManagerService.svc/GetMainHighlighteds?pageNumber=1&productsPerPage=8"
wget -O ..\Java\Android\AndroidClientProxy\src\main\res\raw\productgroupmanager_search.json "http://localhost:50135/EntityManagers/ProductGroupManagerService.svc/Search?needCategory=false&pageNumber=1&searchText=fen&productsPerPage=100"
wget -O ..\Java\Android\AndroidClientProxy\src\main\res\raw\categorymanager_getcategorieswithproductsincategory.json "http://localhost:50135/EntityManagers/CategoryManagerService.svc/GetCategoriesWithProductsInCategory?baseCategoryFu=Ezoterika&pageNumber=1&productsPerPage=0"
wget -O ..\Java\Android\AndroidClientProxy\src\main\res\raw\productmanager_getproductsincategory.json "http://localhost:50135/EntityManagers/ProductManagerService.svc/GetProductsInCategory?pageNumber=1&productsPerPage=100&categoryFriendlyUrl=Ezoterika--Parapszichologia"
wget -O ..\Java\Android\AndroidClientProxy\src\main\res\raw\productmanager_getusersproductsbyfriendlyurl.json "http://localhost:50135/EntityManagers/ProductManagerService.svc/GetUsersProductsByFriendlyUrl?forExchange=false&pageNumber=1&friendlyUrl=Boldano&productsPerPage=100"
wget -O ..\Java\Android\AndroidClientProxy\src\main\res\raw\productgroupmanager_getfulldetailed.json "http://localhost:50135/EntityManagers/ProductGroupManagerService.svc/GetFullDetailed?pageNumber=1&friendlyUrl=Emma-lanya&productsPerPage=100"

REM --- void ---
echo. > ..\Java\Android\AndroidClientProxy\src\main\res\raw\bookteraauthentication_logout.json
echo. > ..\Java\Android\AndroidClientProxy\src\main\res\raw\registrationmanager_registeruser.json
echo. > ..\Java\Android\AndroidClientProxy\src\main\res\raw\userprofilemanager_update.json

REM --- Auth ---

REM -- Login and save the auth cookie --
wget -O ..\Java\Android\AndroidClientProxy\src\main\res\raw\bookteraauthentication_loginandgetid.json ^
     --save-cookies Temp\cookies.txt ^
     "http://localhost:50135/Authentication/BookteraAuthenticationService.svc/LoginAndGetId?userName=zomidudu&password=asdqwe123&persistent=true"

wget -O ..\Java\Android\AndroidClientProxy\src\main\res\raw\userprofilemanager_getforedit.json ^
     --load-cookies Temp\cookies.txt ^
     "http://localhost:50135/EntityManagers/UserProfileManagerService.svc/GetForEdit"
wget -O ..\Java\Android\AndroidClientProxy\src\main\res\raw\transactionmanager_getuserscartsvm_vendorid.json ^
     --load-cookies Temp\cookies.txt ^
     "http://localhost:50135/TransactionManagerService.svc/GetUsersCartsVM?vendorId=287&customerId="
wget -O ..\Java\Android\AndroidClientProxy\src\main\res\raw\transactionmanager_getusersinprogressordersvm_vendorid.json ^
     --load-cookies Temp\cookies.txt ^
     "http://localhost:50135/TransactionManagerService.svc/GetUsersInProgressOrdersVM?vendorId=287&customerId="
wget -O ..\Java\Android\AndroidClientProxy\src\main\res\raw\transactionmanager_getusersfinishedtransactionsvm_vendorid.json ^
     --load-cookies Temp\cookies.txt ^
     "http://localhost:50135/TransactionManagerService.svc/GetUsersFinishedTransactionsVM?vendorId=287&customerId="
wget -O ..\Java\Android\AndroidClientProxy\src\main\res\raw\transactionmanager_getuserscartsvm_customerid.json ^
     --load-cookies Temp\cookies.txt ^
     "http://localhost:50135/TransactionManagerService.svc/GetUsersCartsVM?vendorId=&customerId=287"
wget -O ..\Java\Android\AndroidClientProxy\src\main\res\raw\transactionmanager_getusersinprogressordersvm_customerid.json ^
     --load-cookies Temp\cookies.txt ^
     "http://localhost:50135/TransactionManagerService.svc/GetUsersInProgressOrdersVM?vendorId=&customerId=287"
wget -O ..\Java\Android\AndroidClientProxy\src\main\res\raw\transactionmanager_getusersfinishedtransactionsvm_customerid.json ^
     --load-cookies Temp\cookies.txt ^
     "http://localhost:50135/TransactionManagerService.svc/GetUsersFinishedTransactionsVM?vendorId=&customerId=287"
