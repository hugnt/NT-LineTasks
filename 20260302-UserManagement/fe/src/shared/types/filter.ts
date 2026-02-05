export type FilterRequest = {
    pageSize?: number,
    pageNumber?: number,
    totalRecords?: number,
    searchValue?: string
}

export const defaultFilter: FilterRequest = {
    pageSize: 10,
    pageNumber: 1,
    totalRecords: 0,
}
