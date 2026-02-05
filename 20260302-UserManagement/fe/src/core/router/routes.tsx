import { UserRoutes } from "@/modules/users";
import MainLayout from "@/shared/components/layouts/main/MainLayout";
import { createBrowserRouter } from "react-router";

export const AppRoutes = createBrowserRouter([
  {
    element: <MainLayout />,
    children: [
      ...UserRoutes,
    ],
  },
]);

export default AppRoutes;
