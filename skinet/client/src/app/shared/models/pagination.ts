export type Pagination<T> = {
    value: {
        pageIndex: number;
        pageSize: number;
        count: number;
        data: T[];
    };
};