package utils.EnumHelpers;

import com.booktera.data.CommonPortable_Enums.UserGroupEnum;
import com.google.common.base.Predicate;

import java.util.Arrays;
import java.util.Optional;
import java.util.PrimitiveIterator;

public class UserGroupEnumHelper
{
	private enum Core
	{
		Nincs(0), Leech(1), Seed(2), SeedPlus(3), Author(4), Publisher(5);

		private int	code;

		public int getCode()
		{
			return code;
		}

		private Core(int code)
		{
			this.code = code;
		}
	}

	public static UserGroupEnum get(int code)
    {
        Optional<Core> core = Arrays.stream(Core.values()).filter(e -> e.getCode() == code).findFirst();

        if (!core.isPresent()) //todo log
            throw new RuntimeException("Invalid value for UserGroupEnum");

        UserGroupEnum userGroupEnum = UserGroupEnum.fromString(core.get().name());

        return userGroupEnum;
    }
}
