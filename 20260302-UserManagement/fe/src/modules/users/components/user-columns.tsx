import type { ColumnDef } from "@tanstack/react-table";

import { type Role, RoleMap, type User } from "../types/user.types";
import { ActionCell } from "./user-action-cell";
import { UserStatusBadge } from "./user-status-badge";

type UserColumnActions = {
    onEdit?: (user: User) => void;
    onUpdateActiveStatus?: (payload: {
        userId: string;
        isActive: boolean;
    }) => Promise<unknown>;
    isUpdatingActiveStatus?: boolean;
};

export const createUserColumns = (
    actions: UserColumnActions = {},
): ColumnDef<User>[] => [
    {
        accessorKey: "fullname",
        header: "Name",
        cell: ({ row }) => (
            <div className="w-72 truncate dark:text-gray-200">
                {row.original.fullname}
            </div>
        ),
    },
    {
        accessorKey: "email",
        header: "Email",
        cell: ({ row }) => (
            <div className="w-96 dark:text-gray-200">
                  {row.getValue("email")}
            </div>
        ),
    },
    {
        accessorKey: "role",
        header: "Role",
        cell: ({ row }) => (
            <div className="dark:text-gray-200">
                {RoleMap[row.getValue("role") as Role]}
            </div>
        ),
    },
    {
        accessorKey: "isActive",
        header: "Status",
        cell: ({ row }) => (
            <div className="dark:text-gray-200">
                <UserStatusBadge status={row.getValue("isActive")} />
            </div>
        ),
    },
    {
        id: "actions",
        header: "Actions",
        cell: ({ row }) => {
            const user = row.original;
            return (
                <ActionCell
                    user={user}
                    onEdit={actions.onEdit}
                    onUpdateActiveStatus={actions.onUpdateActiveStatus}
                    isUpdatingActiveStatus={actions.isUpdatingActiveStatus}
                />
            );
        },
    },
];
