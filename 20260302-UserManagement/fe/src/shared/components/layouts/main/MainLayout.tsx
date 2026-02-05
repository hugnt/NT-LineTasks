
import {
  SidebarInset,
  SidebarProvider
} from "@/shared/components/ui/sidebar"
import { Outlet } from "react-router"
import AppHeader from "./AppHeader"
import { AppSidebar } from "./AppSidebar"


export default function MainLayout() {
  return (
    <SidebarProvider>
      <AppSidebar />
      <SidebarInset>
        <AppHeader />
        <div className="p-4 pt-0">
          <Outlet />
        </div>

      </SidebarInset>
    </SidebarProvider>
  )
}
