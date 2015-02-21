package controllers.base;

import play.mvc.Controller;
import play.mvc.With;
import utils.HostForbiddenAction;

@With(HostForbiddenAction.class)
public class BookteraControllerBase extends Controller
{

}
