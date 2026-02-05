import { Pencil, UserCheck, UserX } from "lucide-react";
import { useState } from "react";

import { Button } from "@/shared/components/ui/button";
import {
    Dialog,
    DialogContent,
    DialogDescription,
    DialogFooter,
    DialogHeader,
    DialogTitle,
} from "@/shared/components/ui/dialog";
import { cn } from "@/shared/lib/utils";

import type { User } from "../types/user.types";

export const ActionCell = ({
    user,
    onEdit,
    onUpdateActiveStatus,
    isUpdatingActiveStatus,
}: {
    user: User;
    onEdit?: (user: User) => void;
    onUpdateActiveStatus?: (payload: {
        userId: string;
        isActive: boolean;
    }) => Promise<unknown>;
    isUpdatingActiveStatus?: boolean;
}) => {
    const [isConfirmOpen, setIsConfirmOpen] = useState(false);
    const [isSubmitting, setIsSubmitting] = useState(false);
    // const { activate, deactivate, isPending } = useActivateDeactivate(user.id);

    const handleOpenDialog = () => {
        setIsConfirmOpen(true);
    };

    const handleCloseDialog = () => {
        setIsConfirmOpen(false);
    };

    const confirmAction = async () => {
        if (!onUpdateActiveStatus) {
            setIsConfirmOpen(false);
            return;
        }

        try {
            setIsSubmitting(true);
            await onUpdateActiveStatus({
                userId: user.id,
                isActive: !user.isActive,
            });
            setIsConfirmOpen(false);
        } finally {
            setIsSubmitting(false);
        }
    };

    return (
        <>
            <div className="flex space-x-2">
                <Button
                    size="icon"
                    onClick={() => onEdit?.(user)}
                    className="rounded bg-blue-50 p-1.5 text-blue-600 hover:bg-blue-100 dark:bg-blue-800 dark:text-blue-100 dark:hover:bg-blue-700"
                    title="Edit user"
                >
                    <Pencil />
                </Button>

                {user.isActive && (
                    <Button
                        size="icon"
                        onClick={handleOpenDialog}
                        className="rounded bg-red-50 p-1.5 text-red-600 hover:bg-red-100 dark:bg-red-800 dark:text-red-100 dark:hover:bg-red-700"
                        title="Deactivate user"
                    >
                        <UserX />
                    </Button>
                )}

                {!user.isActive && (
                    <Button
                        size="icon"
                        onClick={handleOpenDialog}
                        className="rounded bg-green-50 p-1.5 text-green-600 hover:bg-green-100 dark:bg-green-800 dark:text-green-100 dark:hover:bg-green-700"
                        title="Activate user"
                    >
                        <UserCheck />
                    </Button>
                )}
            </div>

            <Dialog open={isConfirmOpen} onOpenChange={setIsConfirmOpen}>
                <DialogContent>
                    <DialogHeader>
                        <DialogTitle>
                            {user.isActive && "Deactivate Account"}
                            {!user.isActive && "Activate Account"}
                        </DialogTitle>
                        <DialogDescription>
                            {user.isActive &&
                                `Are you sure you want to deactivate ${user.fullname}'s account?`}
                            {!user.isActive &&
                                `Are you sure you want to activate ${user.fullname}'s account?`}
                        </DialogDescription>
                    </DialogHeader>
                    <DialogFooter>
                        <Button variant="outline" onClick={handleCloseDialog}>
                            Cancel
                        </Button>
                        <Button
                            variant={user.isActive ? "destructive" : "default"}
                            onClick={confirmAction}
                            className={cn(user.isActive && "text-white")}
                            disabled={isSubmitting || isUpdatingActiveStatus}
                        >
                            {!user.isActive ? "Activate" : "Deactivate"}
                        </Button>
                    </DialogFooter>
                </DialogContent>
            </Dialog>

        </>
    );
};
