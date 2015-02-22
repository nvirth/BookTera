package com.booktera.android.fragments.bookBlock;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import com.booktera.android.R;
import com.booktera.android.activities.CategoryActivity;
import com.booktera.android.common.bookBlock.BookBlock;
import com.booktera.android.common.bookBlock.BookBlockArrayAdapter;
import com.booktera.android.common.models.CategoriesVM;
import com.booktera.android.common.models.ProductsInCategoryVM;
import com.booktera.android.common.utils.Utils;
import com.booktera.android.fragments.bookBlock.base.BookBlocksFragment;
import com.booktera.android.fragments.bookBlock.base.ListViewFragmentBase;
import com.booktera.androidclientproxy.lib.models.ProductModels.BookBlockPLVM;
import com.booktera.androidclientproxy.lib.models.ProductModels.InBookBlockPVM;
import com.booktera.androidclientproxy.lib.models.ProductModels.InCategoryCWPLVM;
import com.booktera.androidclientproxy.lib.models.ProductModels.InCategoryPLVM;
import com.booktera.androidclientproxy.lib.models.UserOrderPLVM;
import com.booktera.androidclientproxy.lib.proxy.Services;

import java.util.ArrayList;
import java.util.List;

public class CategoriesFragment extends ListViewFragmentBase
{
    public static final String CATEGORY_FRIENDLY_URL = "CATEGORY_FRIENDLY_URL";
    private String categoryFriendlyUrl;

    public static CategoriesFragment newInstance(String categoryFriendlyUrl)
    {
        Bundle args = new Bundle();
        args.putString(CATEGORY_FRIENDLY_URL, categoryFriendlyUrl);

        CategoriesFragment fragment = new CategoriesFragment();
        fragment.setArguments(args);

        return fragment;
    }

    @Override
    public void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        if (getArguments() != null)
            categoryFriendlyUrl = getArguments().getString(CATEGORY_FRIENDLY_URL);
    }

    @Override
    protected void loadData()
    {
        InCategoryCWPLVM cached = CategoriesVM.Instance.getCategories(categoryFriendlyUrl);
        if (cached != null)
            applyData(cached);
        else
            Services.CategoryManager.getCategoriesWithProductsInCategory(1, 0, categoryFriendlyUrl,
                inCategoryCWPLVM ->
                {
                    CategoriesVM.Instance.setCategories(categoryFriendlyUrl, inCategoryCWPLVM);
                    applyData(inCategoryCWPLVM);
                }
                , null);
    }

    private void applyData(InCategoryCWPLVM dataIn)
    {
        getActivity().runOnUiThread(() ->
        {
            InCategoryCWPLVM data = dataIn; // To be able to debug within a lambda

            // -- Set Title
            if (data.getBaseCategory() == null || Utils.isNullOrEmpty(data.getBaseCategory().getDisplayName()))
                getActivity().setTitle(getActivity().getString(R.string.app_name));
            else
                getActivity().setTitle(data.getBaseCategory().getFullPath());

            // -- Fetch data
            if (data.getChildCategoriesWithProducts().size() == 1) // Leaf category
            {
                vh.noResultTextView.setVisibility(View.VISIBLE);
            }
            else
            {
                vh.noResultTextView.setVisibility(View.GONE);

                ArrayList<String> categoryNames = new ArrayList<>();
                for (InCategoryPLVM inCategoryPLVM : data.getChildCategoriesWithProducts())
                    categoryNames.add(inCategoryPLVM.getCategory().getDisplayName());

                ArrayAdapter bookBlockArrayAdapter = new ArrayAdapter<>(
                    getActivity().getApplicationContext(),
                    R.layout.row_simple_list_item,
                    categoryNames
                );

                vh.listView.setAdapter(bookBlockArrayAdapter);

                vh.listView.setOnItemClickListener(
                    (parent, view, position, id) ->
                    {
                        InCategoryPLVM inCategoryPLVM = data.getChildCategoriesWithProducts().get(position);
                        String categoryFU = inCategoryPLVM.getCategory().getFriendlyUrl();

                        Intent gotoSubcategoryIntent = new Intent(getActivity(), CategoryActivity.class);
                        gotoSubcategoryIntent.putExtra(CategoryActivity.PARAM_CATEGORY_FU, categoryFU);

                        startActivity(gotoSubcategoryIntent);
                    });
            }
        });
    }

}

