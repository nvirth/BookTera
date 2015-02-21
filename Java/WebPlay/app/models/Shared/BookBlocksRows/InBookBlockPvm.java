package models.Shared.BookBlocksRows;

import models.Shared.BookBlocksRows.Partials.MainButtonsPartialVM;
import com.booktera.data.CommonPortable_Models_ProductModels.InBookBlockPVM;
import com.booktera.data.CommonPortable_Models_ProductModels.InBookBlockPVMProductGroupVM;
import com.booktera.data.CommonPortable_Models_ProductModels.InBookBlockPVMProductVM;

public class InBookBlockPvm extends InBookBlockPVM
{
    // -- Ctors

    public InBookBlockPvm(InBookBlockPVM core)
    {
        Core = core;
    }

    public InBookBlockPvm()
    {

    }

    // -- Extended parts

    private MainButtonsPartialVM mainButtonsPartialVM;

    public MainButtonsPartialVM getMainButtonsPartialVM()
    {
        if(mainButtonsPartialVM == null)
            mainButtonsPartialVM = new MainButtonsPartialVM();

        return mainButtonsPartialVM;
    }

    private int maxLetters = 33;

    public int getMaxLetters()
    {
        return maxLetters;
    }

    public void setMaxLetters(int maxLetters)
    {
        this.maxLetters = maxLetters;
    }

    public String getImageFileName()
    {
        return getProduct().getImageUrl() == null
                ? getProductGroup().getImageUrl()
                : getProduct().getImageUrl();
    }

    public String getDescription()
    {
        return getProduct().getDescription() == null
                ? getProductGroup().getDescription()
                : getProduct().getDescription();
    }

    public String ifRanOutClass()
    {
        return getProduct().getHowMany() == 0 ? "book-block-ran-out" : "";
    }

    // -- Core with delegated methods

    private InBookBlockPVM Core;

    @Override
    public InBookBlockPVMProductVM getProduct()
    {
        return Core.getProduct();
    }

    @Override
    public InBookBlockPVMProductGroupVM getProductGroup()
    {
        return Core.getProductGroup();
    }

    @Override
    public void setProduct(InBookBlockPVMProductVM product)
    {
        Core.setProduct(product);
    }

    @Override
    public void setProductGroup(InBookBlockPVMProductGroupVM productGroup)
    {
        Core.setProductGroup(productGroup);
    }
}
