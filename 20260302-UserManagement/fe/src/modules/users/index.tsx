import { PATH } from "@/shared/constants/paths";
import UserPage from "./pages/UserPage";

export const UserRoutes = [
    { path: PATH.Users, element: <UserPage /> },
    { path: '', element: <UserPage /> }
];
