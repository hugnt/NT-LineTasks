import { z } from "zod";

export const userSchema = z.object({
    fullname: z
        .string()
        .trim()
        .min(1, "Name is required")
        .max(50, "Name must be at most 50 characters"),
    email: z
        .string()
        .trim()
        .min(1, "Email is required")
        .email("Invalid email"),
    role: z
        .coerce
        .number()
        .int("Role is invalid")
        .refine((v) => v === 0 || v === 1, "Role is invalid")
        .default(1),
    isActive: z.coerce.boolean().default(true),
});

export type UserFormInput = z.input<typeof userSchema>;
export type UserFormValues = z.output<typeof userSchema>;
