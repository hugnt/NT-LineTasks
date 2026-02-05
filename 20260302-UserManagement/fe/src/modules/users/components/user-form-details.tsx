import { zodResolver } from "@hookform/resolvers/zod";
import { useEffect, useMemo, type FormEvent } from "react";
import { useForm } from "react-hook-form";

import { Button } from "@/shared/components/ui/button";
import {
    Form,
    FormControl,
    FormField,
    FormItem,
    FormLabel,
    FormMessage,
} from "@/shared/components/ui/form";
import { Input } from "@/shared/components/ui/input";
import {
    Select,
    SelectContent,
    SelectItem,
    SelectTrigger,
    SelectValue,
} from "@/shared/components/ui/select";
import {
    Sheet,
    SheetClose,
    SheetContent,
    SheetDescription,
    SheetFooter,
    SheetHeader,
    SheetTitle,
} from "@/shared/components/ui/sheet";
import {
    FormMode,
    type FormSetting,
    formSettingDefault,
} from "@/shared/types/form";
import type { User } from "../types/user.types";
import { RoleMap } from "../types/user.types";
import {
    userSchema,
    type UserFormInput,
    type UserFormValues,
} from "../types/schema/user.schema";


type FormDetailProps = {
    formSetting: FormSetting;
    setFormSetting: (setting: FormSetting) => void;
    data?: User;
    title?: string;
    onSubmit?: (data: UserFormValues) => void;
};

export default function UserFormDetails(props: FormDetailProps) {
    const {
        formSetting = formSettingDefault,
        setFormSetting = () => {},
        data,
        onSubmit = (_data: UserFormValues) => {},
        title = "Details",
    } = props;

    const emptyValues = useMemo(
        () => ({
            fullname: "",
            email: "",
            role: 1,
            isActive: true,
        }),
        [],
    );

    const form = useForm<UserFormInput, unknown, UserFormValues>({
        resolver: zodResolver(userSchema),
        defaultValues: emptyValues,
    });

    const disableField = useMemo(() => {
        if (formSetting.mode == FormMode.VIEW) return true;
        return false;
    }, [formSetting.mode]);

    useEffect(() => {
        if (!formSetting.open) return;

        if (formSetting.mode === FormMode.ADD) {
            form.reset(emptyValues);
            return;
        }

        if (formSetting.mode === FormMode.EDIT) {
            if (!data) {
                form.reset(emptyValues);
                return;
            }

            form.reset({
                fullname: data.fullname,
                email: data.email,
                role: data.role,
                isActive: data.isActive,
            });
        }
    }, [data, emptyValues, form, formSetting.mode, formSetting.open]);

    const handleFormSubmit = (e: FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        form.handleSubmit(onSubmit)();
    };

    return (
        <Sheet
            open={formSetting.open}
            onOpenChange={(v: boolean) => {
                setFormSetting({ ...formSetting, open: v });
                if (!v) form.reset(emptyValues);
            }}
        >
            <SheetContent
                onInteractOutside={(event: Event) => event.preventDefault()}
                className="flex flex-col"
            >
                <SheetHeader className="text-left">
                    <SheetTitle>
                        {formSetting.mode} {title}
                    </SheetTitle>
                    <SheetDescription>
                        {formSetting.mode == FormMode.EDIT &&
                            "Update details by providing necessary info."}
                        {formSetting.mode == FormMode.ADD &&
                            "Add a new record by providing necessary info."}
                        Click save when you&apos;re done.
                    </SheetDescription>
                </SheetHeader>
                <Form {...form}>
                    <form
                        id="tasks-form"
                        onSubmit={handleFormSubmit}
                        className="flex-1 space-y-5 px-4"
                    >
                        <FormField
                            control={form.control}
                            name="fullname"
                            render={({ field }) => (
                                <FormItem className="space-y-1">
                                    <FormLabel className="!text-current">
                                        Name
                                    </FormLabel>
                                    <FormControl>
                                        <Input
                                            maxLength={50}
                                            readOnly={disableField}
                                            {...field}
                                            placeholder="Enter a name"
                                        />
                                    </FormControl>
                                    <FormMessage />
                                </FormItem>
                            )}
                        />
                        <FormField
                            control={form.control}
                            name="email"
                            render={({ field }) => (
                                <FormItem className="space-y-1">
                                    <FormLabel className="!text-current">
                                        Email
                                    </FormLabel>
                                    <FormControl>
                                        <Input
                                            maxLength={250}
                                            readOnly={disableField}
                                            {...field}
                                            placeholder="Enter an email"
                                        />
                                    </FormControl>
                                    <FormMessage />
                                </FormItem>
                            )}
                        />

                        <FormField
                            control={form.control}
                            name="role"
                            render={({ field }) => (
                                <FormItem className="space-y-1">
                                    <FormLabel className="!text-current">
                                        Role
                                    </FormLabel>
                                    <FormControl>
                                        <Select
                                            disabled={disableField}
                                            value={
                                                field.value === undefined ||
                                                field.value === null
                                                    ? ""
                                                    : String(field.value)
                                            }
                                            onValueChange={(value) =>
                                                field.onChange(Number(value))
                                            }
                                        >
                                            <SelectTrigger>
                                                <SelectValue placeholder="Select a role" />
                                            </SelectTrigger>
                                            <SelectContent>
                                                <SelectItem value="0">
                                                    {RoleMap[0]}
                                                </SelectItem>
                                                <SelectItem value="1">
                                                    {RoleMap[1]}
                                                </SelectItem>
                                            </SelectContent>
                                        </Select>
                                    </FormControl>
                                    <FormMessage />
                                </FormItem>
                            )}
                        />

                        <FormField
                            control={form.control}
                            name="isActive"
                            render={({ field }) => (
                                <FormItem className="space-y-1">
                                    <FormLabel className="!text-current">
                                        Status
                                    </FormLabel>
                                    <FormControl>
                                        <Select
                                            disabled={disableField}
                                            value={
                                                field.value === undefined ||
                                                field.value === null
                                                    ? ""
                                                    : String(field.value)
                                            }
                                            onValueChange={(value) =>
                                                field.onChange(value === "true")
                                            }
                                        >
                                            <SelectTrigger>
                                                <SelectValue placeholder="Select status" />
                                            </SelectTrigger>
                                            <SelectContent>
                                                <SelectItem value="true">
                                                    Active
                                                </SelectItem>
                                                <SelectItem value="false">
                                                    Deactivated
                                                </SelectItem>
                                            </SelectContent>
                                        </Select>
                                    </FormControl>
                                    <FormMessage />
                                </FormItem>
                            )}
                        />
                    </form>
                </Form>
                <SheetFooter className="gap-2">
                    <SheetClose asChild>
                        <Button variant="outline">Close</Button>
                    </SheetClose>
                    {!disableField && (
                        <Button form="tasks-form" type="submit">
                            Save changes
                        </Button>
                    )}
                </SheetFooter>
            </SheetContent>
        </Sheet>
    );
}
