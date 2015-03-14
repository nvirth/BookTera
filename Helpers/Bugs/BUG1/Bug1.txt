Once, during debugging, in BookBlock.applyData, the 2. getActivity() call returned null; but I couldn't reproduce it directly. Now catched it again (accidentally), but this time, I was prepared :D See "FoundIt.png". Also there is the concrete code here:

//---------
getActivity().runOnUiThread(() ->
{
    //...
        BookBlockArrayAdapter bookBlockArrayAdapter = new BookBlockArrayAdapter(
            getActivity().getApplicationContext(), //TODO there was here a null reference exception once!
            data
        );
//---------

I think it should be a debug time exception only, and appeared only WHEN I ROTATED THE DEVICE, WHILE THERE WAS A BREAKPOINT HIT BETWEEN THE 1. AND THE 2. getActivity() CALL. But, it's just a theory, I can't reproduce this directly still.

So, now, I remain the logs in place in case it would come again; but cache the returned Activity object by the first call, and reuse that in the 2.; because, as can be seen at the png, this way there wouln't be a Null exception. Question is only, how the cached Activity will react to the using of it.