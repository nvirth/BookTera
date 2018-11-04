package utils.EnumHelpers;

import com.booktera.data.CommonPortable_Enums.UserOrderStatus;

import static com.booktera.data.CommonPortable_Enums.UserOrderStatus.*;

public class UserOrderStatusEnumHelper
{
    public static String toDescriptionString(UserOrderStatus userOrderStatus)
    {
        // Normal
        if (userOrderStatus == Cart)
            return "Kosárban";
        if (userOrderStatus == BuyedWaiting)
            return "Válaszra vár";
        if (userOrderStatus == BuyedExchangeOffered)
            return "Csere ajánlva";
        if (userOrderStatus == FinalizedExchange)
            return "Véglegesített tranzakció cserével";
        if (userOrderStatus == FinalizedCash)
            return "Véglegesített tranzakció fizetéssel";
        if (userOrderStatus == Finished)
            return "Befejezett tranzakció";

        // Not exist in DB
        if (userOrderStatus == CartDeleting)
            return "Kosár törlés alatt";

        // default
        return userOrderStatus.toString();
    }
}
