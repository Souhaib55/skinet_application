export type ApiResponse<T> = {
    value: {
        pageIndex: number;
        pageSize: number;
        count: number;
        data: T[];
    };
};