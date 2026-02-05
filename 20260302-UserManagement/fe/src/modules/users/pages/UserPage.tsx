import type { ColumnDef } from "@tanstack/react-table";
import { useCallback, useEffect, useMemo, useState } from "react";

import DataTable from "@/shared/components/data-display/data-table";
import DataTablePagination from "@/shared/components/data-display/data-table-pagination";

import SearchInput from "@/shared/components/forms/search-input";
import PageHeader from "@/shared/components/layouts/PageHeader";
import { Button } from "@/shared/components/ui/button";
import { BUTTON_NAME } from "@/shared/constants/buttons";
import { FormMode, type FormSetting, formSettingDefault } from "@/shared/types/form";
import { Plus } from "lucide-react";
import UserFormDetails from "../components/user-form-details";
import { createUserColumns } from "../components/user-columns";
import { defaultFilter } from "@/shared/types/filter";
import { type User } from "../types/user.types";
import type { UserFormValues } from "../types/schema/user.schema";
import { useUsers } from "../hooks/useUsers";

export default function UserPage() {
  const [formSetting, setFormSetting] = useState<FormSetting>(formSettingDefault);
  const [selectedUserId, setSelectedUserId] = useState<string | null>(null);

  const {
    userList,
    totalUserCount,
    isLoadingUserList,
    filter,
    setFilter,
    handleSearchUser,
    userDetails,
    createUser,
    updateUser,
    updateActiveStatus,
    isUpdatingActiveStatus,
  } = useUsers(defaultFilter, selectedUserId);

  useEffect(() => {
    if (!formSetting.open) setSelectedUserId(null);
  }, [formSetting.open]);

  const handleOpenAdd = useCallback(() => {
    setSelectedUserId(null);
    setFormSetting({ mode: FormMode.ADD, open: true });
  }, []);

  const handleOpenEdit = useCallback((user: User) => {
    setSelectedUserId(user.id);
    setFormSetting({ mode: FormMode.EDIT, open: true });
  }, []);

  const handleSubmitUserForm = useCallback(
    async (values: UserFormValues) => {
      if (formSetting.mode === FormMode.ADD) {
        await createUser(values);
        setFormSetting({ ...formSetting, open: false });
        return;
      }

      if (formSetting.mode === FormMode.EDIT && selectedUserId) {
        await updateUser({ id: selectedUserId, body: values });
        setFormSetting({ ...formSetting, open: false });
      }
    },
    [createUser, formSetting, selectedUserId, updateUser],
  );

  const columnsWithNumbering: ColumnDef<User>[] = useMemo(
    () => [
      {
        id: "index",
        header: "No.",
        cell: ({ row }) => (
          <div>
            {((filter.pageNumber ?? 1) - 1) * (filter.pageSize ?? 10) +
              row.index +
              1}
          </div>
        ),
        enableSorting: false,
        enableHiding: false,
      },
      ...createUserColumns({ onEdit: handleOpenEdit }),
    ],
    [filter.pageNumber, filter.pageSize, handleOpenEdit],
  );

  const columnsWithNumberingAndActions: ColumnDef<User>[] = useMemo(
    () => [
      columnsWithNumbering[0],
      ...createUserColumns({
        onEdit: handleOpenEdit,
        onUpdateActiveStatus: updateActiveStatus,
        isUpdatingActiveStatus,
      }),
    ],
    [columnsWithNumbering, handleOpenEdit, isUpdatingActiveStatus, updateActiveStatus],
  );

  return (
    <div>
      <PageHeader
        title="User Management"
        subtitle="Manage application users and their roles"
      >
        <Button className="space-x-1" onClick={handleOpenAdd}>
          <span>{BUTTON_NAME.Add}</span>
          <Plus size={18} />
        </Button>
      </PageHeader>
      <SearchInput
        className="w-[300px]"
        onSearch={handleSearchUser}
        characterLimit={250}
      />
      <div className="space-y-4">
        <DataTable
          data={userList}
          columns={columnsWithNumberingAndActions}
          loading={isLoadingUserList}
        />
        <DataTablePagination
          pageSizeList={[10, 15, 20]}
          pageSize={filter?.pageSize}
          pageNumber={filter?.pageNumber}
          totalRecords={totalUserCount}
          onPageNumberChanged={(pageNumber: number) =>
            setFilter({ ...filter, pageNumber: pageNumber })
          }
          onPageSizeChanged={(pageSize: number) =>
            setFilter({ ...filter, pageNumber: 1, pageSize: pageSize })
          }
        />
      </div>

      <UserFormDetails
        formSetting={formSetting}
        setFormSetting={setFormSetting}
        data={formSetting.mode === FormMode.EDIT ? userDetails : undefined}
        title="User"
        onSubmit={handleSubmitUserForm}
      />
    </div>
  );
}
