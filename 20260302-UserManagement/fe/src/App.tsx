import { RouterProvider } from "react-router";
import { ToastContainer } from "react-toastify";
import AppRoutes from "./core/router/routes";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";

const queryClient = new QueryClient();

function App() {
  return (
    <>
      <QueryClientProvider client={queryClient}>
        <RouterProvider router={AppRoutes} />
        <ToastContainer autoClose={2000} />
      </QueryClientProvider>
    </>
  );
}

export default App;
