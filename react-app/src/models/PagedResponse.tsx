import DataItemModel from "./DataItemModel";

interface PagedResponse {
    items: DataItemModel[];
    hasMore: boolean;
}

export default PagedResponse;