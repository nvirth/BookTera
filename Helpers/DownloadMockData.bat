echo "Downloads the mock data for the AndroidClientProxy project. "

wget -O ..\Java\Android\AndroidClientProxy\src\main\res\raw\productmanager_getnewests.json "http://localhost:50135/EntityManagers/ProductManagerService.svc/GetNewests?numOfProducts=16&pageNumber=2&productsPerPage=8"
wget -O ..\Java\Android\AndroidClientProxy\src\main\res\raw\productmanager_getmainhighlighteds.json "http://localhost:50135/EntityManagers/ProductManagerService.svc/GetMainHighlighteds?pageNumber=1&productsPerPage=8"
wget -O ..\Java\Android\AndroidClientProxy\src\main\res\raw\productgroupmanager_search.json "http://localhost:50135/EntityManagers/ProductGroupManagerService.svc/Search?needCategory=false&pageNumber=1&searchText=fen&productsPerPage=100"