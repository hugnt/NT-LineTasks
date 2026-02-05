import { Badge } from "@/shared/components/ui/badge";

import { type UserStatus, UserStatusMap } from "../types/user.types";

const userStatusClassName = {
    true: "bg-green-50 text-green-800 dark:bg-green-800 dark:text-white",
    false: "bg-red-50 text-red-800 dark:bg-red-800 dark:text-white",
};

type UserStatusBadgeProps = {
    status: UserStatus;
};

export const UserStatusBadge = ({ status }: UserStatusBadgeProps) => {
    const statusKey = String(status) as keyof typeof userStatusClassName;
    return (
        <Badge className={userStatusClassName[statusKey]}>
            {UserStatusMap[statusKey]}
        </Badge>
    );
};
