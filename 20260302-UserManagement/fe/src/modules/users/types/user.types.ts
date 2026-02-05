export const UserStatusMap = {
  true: "Active",
  false: "Deactivated"
} as const;

export type UserStatus = boolean;
export type UserStatusName = (typeof UserStatusMap)[keyof typeof UserStatusMap];

export const RoleMap = {
  0: "Admin",
  1: "User"
} as const;

export type Role = 0 | 1;
export type RoleName = (typeof RoleMap)[keyof typeof RoleMap];

export type User = {
  id: string;
  fullname: string;
  email: string;
  role: Role;
  isActive: boolean;
  updatedAt: string;
};

export type UserUpsertPayload = Pick<User, "fullname" | "email" | "role" | "isActive">;