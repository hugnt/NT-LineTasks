/* eslint-disable @typescript-eslint/no-explicit-any */
import { getAccessToken } from "@/shared/services/storage/localStorage";
import type { InternalAxiosRequestConfig } from "axios";


export const authRequestInterceptor = (
    config: InternalAxiosRequestConfig,
): InternalAxiosRequestConfig => {
    const token = getAccessToken();
    if (token && config.headers) {
        config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
};
