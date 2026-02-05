export const FormMode = {
    NO_ACTION: "",
    VIEW: "Details",
    ADD: "Create",
    EDIT: "Update",
} as const;

export type FormMode = (typeof FormMode)[keyof typeof FormMode];

export type ConfirmDialogState = {
    open: boolean;
    id: string;
    name: string;
};

export const confirmDialogStateDefault: ConfirmDialogState = {
    open: false,
    id: "",
    name: "",
};

export type FormSetting = {
    mode: FormMode;
    open: boolean;
};

export const formSettingDefault: FormSetting = {
    mode: FormMode.NO_ACTION,
    open: false,
};
