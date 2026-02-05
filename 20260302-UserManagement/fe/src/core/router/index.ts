import { PATH } from "@/shared/constants/paths";

export const isLoginPage = () =>
    window.location.pathname == PATH.Login ||
    window.location.pathname == PATH.Register;
