package models.Sell;

import com.booktera.data.CommonModels_Models_ProductModels.CreatePVM;

public class CreatePvm extends CreatePVM
{
    private CreateProductVm Product;

    private CreateProductGroupVm ProductGroup;

    public CreatePvm()
    {
        this.Product = new CreateProductVm();
        this.ProductGroup = new CreateProductGroupVm();
    }

    public CreatePvm(CreateProductVm product, CreateProductGroupVm productGroup)
    {
        this.Product = product;
        this.ProductGroup = productGroup;
    }


    @Override
    public CreateProductVm getProduct()
    {
        return Product;
    }

    @Override
    public CreateProductGroupVm getProductGroup()
    {
        return ProductGroup;
    }

}
