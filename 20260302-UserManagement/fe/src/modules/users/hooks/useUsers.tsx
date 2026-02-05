import {
    keepPreviousData,
    useMutation,
    useQuery,
    useQueryClient,
} from "@tanstack/react-query";
import { useCallback, useState } from "react";

import { userServices } from "../services/userServices";
import { defaultFilter, type FilterRequest } from "@/shared/types/filter";
import type { UserUpsertPayload } from "../types/user.types";

export const useUsers = (
    initialFilter: FilterRequest = defaultFilter,
    userId?: string | null,
) => {
    const queryClient = useQueryClient();

    const [filter, setFilter] = useState<FilterRequest>(initialFilter);

    const handleSearchUser = useCallback((searchValue: string) => {
        setFilter((prev) => ({
            ...prev,
            searchValue,
            pageNumber: 1,
        }));
    }, []);

    const usersQuery = useQuery({
        queryKey: ["users", filter],
        queryFn: () => userServices.getAll(filter),
        placeholderData: keepPreviousData,
    });

    const userDetailsQuery = useQuery({
        queryKey: ["users", "details", userId],
        queryFn: () => userServices.getDetails(userId as string),
        enabled: !!userId,
    });

    const createUserMutation = useMutation({
        mutationFn: (body: UserUpsertPayload) => userServices.create(body),
        onSuccess: async () => {
            await queryClient.invalidateQueries({ queryKey: ["users"] });
        },
    });

    const updateUserMutation = useMutation({
        mutationFn: (payload: { id: string; body: UserUpsertPayload }) =>
            userServices.update(payload.id, payload.body),
        onSuccess: async (_res, payload) => {
            await Promise.all([
                queryClient.invalidateQueries({ queryKey: ["users"] }),
                queryClient.invalidateQueries({
                    queryKey: ["users", "details", payload.id],
                }),
            ]);
        },
    });

    const deleteUserMutation = useMutation({
        mutationFn: (id: string) => userServices.delete(id),
        onSuccess: async () => {
            await queryClient.invalidateQueries({ queryKey: ["users"] });
        },
    });

    const updateActiveStatusMutation = useMutation({
        mutationFn: (payload: { userId: string; isActive: boolean }) =>
            userServices.updateActiveStatus(payload.userId, payload.isActive),
        onSuccess: async (_res, payload) => {
            await Promise.all([
                queryClient.invalidateQueries({ queryKey: ["users"] }),
                queryClient.invalidateQueries({
                    queryKey: ["users", "details", payload.userId],
                }),
            ]);
        },
    });

    return {
        filter,
        setFilter,
        handleSearchUser,

        createUser: createUserMutation.mutateAsync,
        updateUser: updateUserMutation.mutateAsync,
        deleteUser: deleteUserMutation.mutateAsync,
        updateActiveStatus: updateActiveStatusMutation.mutateAsync,
        isUpdatingActiveStatus: updateActiveStatusMutation.isPending,

        userList: usersQuery.data?.data,
        totalUserCount: usersQuery.data?.totalRecords,
        isLoadingUserList: usersQuery.isLoading,

        userDetails: userDetailsQuery.data?.data,
        isLoadingUserDetails: userDetailsQuery.isLoading,
    };
};
