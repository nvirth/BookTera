package com.booktera.android.fragments.bookBlock.base;

import android.support.v4.app.FragmentActivity;
import android.util.Log;
import android.view.View;
import com.booktera.android.common.bookBlock.BookBlockArrayAdapter;
import com.booktera.android.fragments.base.ListViewFragmentBase;
import com.booktera.androidclientproxy.lib.models.ProductModels.BookBlockPLVM;

public abstract class BookBlocksFragmentBase extends ListViewFragmentBase
{
    /**
     * While implementing, you have to call {@link #applyData(com.booktera.androidclientproxy.lib.models.ProductModels.BookBlockPLVM)}
     * with the (asynchronously)downloaded/cached data
     */
    @Override
    protected abstract void loadData();

    protected void applyData(BookBlockPLVM data)
    {
        runOnUiThread(activity ->
        {
            if (data.getProducts().isEmpty())
            {
                vh.noResultTextView.setVisibility(View.VISIBLE);
            }
            else
            {
                BookBlockArrayAdapter bookBlockArrayAdapter = new BookBlockArrayAdapter(
                    activity.getApplicationContext(),
                    data
                );

                vh.listView.setAdapter(bookBlockArrayAdapter);
                vh.noResultTextView.setVisibility(View.GONE);
            }
        });
    }
}

