import { httpClient } from "@/core/config/axios/instance.axios";
import type { FilterRequest } from "@/shared/types/filter";
import type { User, UserUpsertPayload } from "../types/user.types";

export const userServices = {
    getAll:(filter: FilterRequest) => httpClient.get<User[]>('users', { params: filter }),
    getDetails: (id: string) => httpClient.get<User>(`users/${id}`),
    create: (body: UserUpsertPayload) => httpClient.post('users', body),
    update: (id: string, body: UserUpsertPayload) => httpClient.put(`/users/${id}`, body),
    updateActiveStatus: (userId: string, isActive: boolean) => httpClient.patch(`users/${userId}/active-status`, { isActive }),
    delete: (id: string) => httpClient.delete(`users/${id}`),

};
