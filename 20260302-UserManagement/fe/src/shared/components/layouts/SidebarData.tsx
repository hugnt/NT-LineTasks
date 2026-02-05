
import { PATH } from "@/shared/constants/paths";
import { Contact } from "lucide-react";

export const SidebarData = [
  {
    title: "User",
    icon: Contact,
    url: '',
    isActive: true,
    items: [
      {
        title: "User list",
        url: PATH.Users
      }
    ],
  },
]

