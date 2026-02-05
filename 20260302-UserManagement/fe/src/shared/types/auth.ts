export type Token = {
    accessToken: string;
    refreshToken: string;
};

export type LoginRequest = {
    email: string;
    password: string;
};

export type VerifyEmailRequest = {
    email: string;
    code: string;
};

export type RefreshTokenRequest = Token;

export type VerifyEmailResponse = Token;

export type RefreshTokenResponse = Token;

export type LoginResponse = Token & {
    isVerifyEmail: boolean;
};

